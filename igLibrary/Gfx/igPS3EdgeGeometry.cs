namespace igLibrary.Gfx
{
	public class igPS3EdgeGeometry : igPS3EdgeGeometrySegmentList
	{
		[igField(typeof(igBoolMetaField), 0xFF, 0x00, 0x18, 0x00, "_isMorphed")]
		public bool _isMorphed;

		[igField(typeof(igBoolMetaField), 0xFF, 0x01, 0x19, 0x00, "_isSkinned")]
		public bool _isSkinned;

		[igField(typeof(igUnsignedIntMetaField), 0xFF, 0x02, 0x1C, 0x00, "_hashCode")]
		public uint _hashCode;

		private StreamHelper.Endianness endianness;
		private uint version;

		public void ExtractGeometry(out uint[][] indices, out float[][] vPositions, out float[][] vTexCoords)
		{
			indices = new uint[_count][];
			vPositions = new float[_count][];
			vTexCoords = new float[_count][];

			for(int i = 0; i < _count; i++)
			{
				igPS3EdgeGeometrySegment segment = this[i] as igPS3EdgeGeometrySegment;

				//use _spuConfigInfo

				StreamHelper spuConfigInfo = new StreamHelper(new MemoryStream(segment._spuConfigInfo.buffer), endianness);

				spuConfigInfo.Seek(0x08);
				uint vertexCount = spuConfigInfo.ReadUInt16();
				uint indexCount = spuConfigInfo.ReadUInt16();

				vPositions[i] = new float[vertexCount * 4];
				vTexCoords[i] = new float[vertexCount * 4];

				//Decompress Indices
				//use _indexes

				DecompressIndices(segment, indexCount, out indices[i]);

				//Read Vertices
				//use _spuVertexes0

				Console.WriteLine($"{vertexCount.ToString("X08")} vertices");
				Console.WriteLine($"{indexCount.ToString("X08")} indices");

				uint stride = (uint)segment._spuVertexes0.size / vertexCount;

				//Console.WriteLine($"_spuVertexes0    at {segment._spuVertexes0.dataOffset.ToString("X08")}, Length {segment._spuVertexes0.dataLength.ToString("X08")}, stride {(segment._spuVertexes0.dataLength / vertexCount).ToString("X08")}");
				//Console.WriteLine($"_spuVertexes1    at {segment._spuVertexes1.dataOffset.ToString("X08")}, Length {segment._spuVertexes1.dataLength.ToString("X08")}, stride {(segment._spuVertexes1.dataLength / vertexCount).ToString("X08")}");
				//Console.WriteLine($"_rsxOnlyVertexes at {segment._rsxOnlyVertexes.dataOffset.ToString("X08")}, Length {segment._rsxOnlyVertexes.dataLength.ToString("X08")}, stride {(segment._rsxOnlyVertexes.dataLength / vertexCount).ToString("X08")}");

				StreamHelper posvertexsh = null;
				posvertexsh = new StreamHelper(new MemoryStream(segment._spuVertexes0.buffer), StreamHelper.Endianness.Big);
				StreamHelper uvvertexsh = new StreamHelper(new MemoryStream(segment._rsxOnlyVertexes.buffer), StreamHelper.Endianness.Big);
				//StreamHelper normalvertexsh = new StreamHelper(new MemoryStream(segment._spuVertexes1.buffer), StreamHelper.Endianness.Big);

				string vertext = string.Empty;	//I like to think i'm funny by naming this vertext
				string faceText = string.Empty;

				bool useNormals = false;
				if(segment._spuVertexes1.size / vertexCount < 0x06)
				{
					useNormals = false;
					Console.WriteLine("WARNING, UNIMPLEMENTED NORMALS, SKIPPING NORMALS");
				}
				for(uint j = 0; j < vertexCount; j++)
				{
					//Console.WriteLine($"Reading verts, at {vertexsh.BaseStream.Position.ToString("X08")} / {segment._rsxOnlyVertexes.dataLength.ToString("X08")}");
					posvertexsh.Seek(stride * j);
					if(version == 0x09 && stride != 0x0C)
					{
						Vector4 pos = igVertexConversion.unpack_SHORT4N(posvertexsh);
						vPositions[i][j * 4 + 0] = pos.X / pos.W;
						vPositions[i][j * 4 + 1] = pos.Y / pos.W;
						vPositions[i][j * 4 + 2] = pos.Z / pos.W;
						vPositions[i][j * 4 + 3] = 1.0f;
					}
					else
					{
						Vector4 pos = igVertexConversion.unpack_FLOAT3(posvertexsh);
						vPositions[i][j * 4 + 0] = pos.X;
						vPositions[i][j * 4 + 1] = pos.Y;
						vPositions[i][j * 4 + 2] = pos.Z;
						vPositions[i][j * 4 + 3] = 1.0f;
					}

					if(version == 0x07)
					{
						//DKDave on the xentax discord helped me out with uvs
						uvvertexsh.Seek(0x0C * j + 0x08);
					}
					else
					{
						uvvertexsh.Seek((segment._rsxOnlyVertexes.size / vertexCount) * j);
					}

					Vector4 uv = igVertexConversion.unpack_HALF2(uvvertexsh);
					vTexCoords[i][j * 4 + 0] = uv.X;
					vTexCoords[i][j * 4 + 1] = uv.Y;
					vTexCoords[i][j * 4 + 2] = uv.Z;
					vTexCoords[i][j * 4 + 3] = uv.W;
				}

				posvertexsh.Close();
				posvertexsh.Dispose();
				uvvertexsh.Close();
				uvvertexsh.Dispose();
			}
		}
		//Thanks to chroxx for reverse engineering this. (https://github.com/Danilodum/noesis-plugins-official/blob/master/chrrox/import/beta/psa.py)
		private void DecompressIndices(igPS3EdgeGeometrySegment segment, uint indexCount, out uint[] indexBuffer)
		{
			StreamHelper indexes = new StreamHelper(new MemoryStream(segment._indexes.buffer), endianness);
			indexes.Seek(0);
			uint numIndices = indexes.ReadUInt16();
			int indexBase = (int)indexes.ReadUInt16();
			uint sequenceSize = indexes.ReadUInt16();
			byte indexBitSize = indexes.ReadByte();

			indexes.Seek(0x08);

			uint sequenceCount = sequenceSize * 8;
			byte[] sequenceBytes = indexes.ReadBytes((int)sequenceSize);	//array of 1 bit values
			StreamHelper sequenceStream = new StreamHelper(new MemoryStream(sequenceBytes), StreamHelper.Endianness.Big);

			uint triangleCount = indexCount / 3;
			uint triangleSize = ((triangleCount * 2) + 7) / 8;
			byte[] triangleBytes = indexes.ReadBytes((int)triangleSize);	//array of 2 bit values
			StreamHelper triangleStream = new StreamHelper(new MemoryStream(triangleBytes), StreamHelper.Endianness.Big);

			uint indicesSize = (numIndices * indexBitSize) + 7 / 8;
			byte[] indicesBytes = indexes.ReadBytes((int)indicesSize);	//array of indexBitSize bit values
			StreamHelper indicesStream = new StreamHelper(new MemoryStream(indicesBytes), StreamHelper.Endianness.Big);

			int[] deltaIndices = new int[numIndices];
			for(uint i = 0; i < numIndices; i++)
			{
				int value = (int)indicesStream.ReadUIntN(indexBitSize);
				value -= indexBase;
				if(i > 7)
				{
					value += deltaIndices[i - 8];
				}
				deltaIndices[i] = value;
			}

			//create sequence indices

			uint[] inputIndices = new uint[sequenceCount];
			uint sequencedIndex = 0;
			uint unorderedIndex = 0;
			for(int i = 0; i < sequenceCount; i++)
			{
				bool value = sequenceStream.ReadBit();
				if(!value)
				{
					inputIndices[i] = sequencedIndex;
					sequencedIndex++;
				}
				else
				{
					inputIndices[i] = (uint)deltaIndices[unorderedIndex];
					unorderedIndex++;
				}
			}

			//create triangle indices

			uint[] outputIndices = new uint[triangleCount * 3];
			uint currentIndex = 0;
			uint[] triangleIndices = new uint[3];
			for(int i = 0; i < triangleCount; i++)
			{
				uint value = (uint)triangleStream.ReadUIntN(2);

				switch(value)
				{
					case 0:
					case 1:
						triangleIndices[1 - value] = triangleIndices[2];
						triangleIndices[2] = inputIndices[currentIndex];
						currentIndex++;
						break;
					case 2:
						uint tempIndex = triangleIndices[0];
						triangleIndices[0] = triangleIndices[1];
						triangleIndices[1] = tempIndex;
						triangleIndices[2] = inputIndices[currentIndex];
						currentIndex++;
						break;
					case 3:
						triangleIndices[0] = inputIndices[currentIndex];
						currentIndex++;
						triangleIndices[1] = inputIndices[currentIndex];
						currentIndex++;
						triangleIndices[2] = inputIndices[currentIndex];
						currentIndex++;
						break;
				}

				outputIndices[i * 3 + 0] = triangleIndices[0];
				outputIndices[i * 3 + 1] = triangleIndices[1];
				outputIndices[i * 3 + 2] = triangleIndices[2];
			}
			indexBuffer = outputIndices;

			//Debug stuff
			byte[] ints = new byte[outputIndices.Length * 4];
			Buffer.BlockCopy(outputIndices, 0, ints, 0, ints.Length);
			for(int i = 0; i < ints.Length; i += 4)
			{
				Array.Reverse(ints, i, 4);
			}
			//File.WriteAllBytes($"{segment.offset.ToString("X08")}_indices.dat", ints);
		}

		public override void ReadFields(igIGZ igz)
		{
			base.ReadFields(igz);

			endianness = igz._stream._endianness;
			version = igz._version;
		}
	}
}