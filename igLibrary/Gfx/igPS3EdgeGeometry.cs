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

		public void ExtractGeometry(out uint[][] indices, out float[][] vPositions, out float[][] vTexCoords, out float[][] vColours)
		{
			indices = new uint[_count][];
			vPositions = new float[_count][];
			vTexCoords = new float[_count][];
			vColours = new float[_count][];

			for(int i = 0; i < _count; i++)
			{
				igPS3EdgeGeometrySegment segment = this[i] as igPS3EdgeGeometrySegment;

				//use _spuConfigInfo

				StreamHelper spuConfigInfo = new StreamHelper(new MemoryStream(segment._spuConfigInfo.buffer), endianness);

				spuConfigInfo.Seek(0x08);
				uint vertexCount = spuConfigInfo.ReadUInt16();
				uint indexCount = spuConfigInfo.ReadUInt16();

				//Decompress Indices
				//use _indexes

				DecompressIndices(segment, indexCount, out indices[i]);

				//Read Vertices

				//_spuVertexes0

				StreamHelper spuVertexes0 = new StreamHelper(new MemoryStream(segment._spuVertexes0.buffer), StreamHelper.Endianness.Big);
				if(segment._spuInputStreamDescs0.size == 0)
				{
					igPS3EdgeGeometrySegment.StreamDescHeader header = new igPS3EdgeGeometrySegment.StreamDescHeader();
					header.count1 = 1;
					header.count2 = 1;
					header.stride = 0xC;
					igPS3EdgeGeometrySegment.StreamDescAttribute attr = new igPS3EdgeGeometrySegment.StreamDescAttribute();
					attr.offset = 0;
					attr.size = 0xC;
					attr.type = igPS3EdgeGeometrySegment.EdgeGeometryVertexType.FLOAT3;
					attr.usage = igPS3EdgeGeometrySegment.EdgeGeometryVertexUsage.POSITION;
					PopulateBuffer(spuVertexes0, out vPositions[i], vertexCount, header, attr);
				}
				else
				{
					StreamHelper spuInputStreamDescs0 = new StreamHelper(new MemoryStream(segment._spuInputStreamDescs0.buffer), StreamHelper.Endianness.Big);
					igPS3EdgeGeometrySegment.StreamDescHeader spuInputStreamDescs0Header = spuInputStreamDescs0.ReadStruct<igPS3EdgeGeometrySegment.StreamDescHeader>();
					igPS3EdgeGeometrySegment.StreamDescAttribute[] spuInputStreamDescs0Attributes = spuInputStreamDescs0.ReadStructArray<igPS3EdgeGeometrySegment.StreamDescAttribute>(spuInputStreamDescs0Header.count1);
					PopulateBuffer(spuVertexes0, out vPositions[i], vertexCount, spuInputStreamDescs0Header, spuInputStreamDescs0Attributes.First(x => x.usage == igPS3EdgeGeometrySegment.EdgeGeometryVertexUsage.POSITION));
				}

				spuVertexes0.Dispose();
				spuVertexes0.Close();

				//_rsxOnlyVertexes

				StreamHelper rsxOnlyVertexes = new StreamHelper(new MemoryStream(segment._rsxOnlyVertexes.buffer), StreamHelper.Endianness.Big);
				if(segment._rsxOnlyVertexes.size > 0)
				{
					StreamHelper rsxOnlyStreamDesc = new StreamHelper(new MemoryStream(segment._rsxOnlyStreamDesc.buffer), StreamHelper.Endianness.Big);
					igPS3EdgeGeometrySegment.StreamDescHeader rsxOnlyStreamDescHeader = rsxOnlyStreamDesc.ReadStruct<igPS3EdgeGeometrySegment.StreamDescHeader>();
					igPS3EdgeGeometrySegment.StreamDescAttribute[] rsxOnlyStreamDescAttributes = rsxOnlyStreamDesc.ReadStructArray<igPS3EdgeGeometrySegment.StreamDescAttribute>(rsxOnlyStreamDescHeader.count1);
					int UV0Attr = Array.FindIndex<igPS3EdgeGeometrySegment.StreamDescAttribute>(rsxOnlyStreamDescAttributes, x => x.usage == igPS3EdgeGeometrySegment.EdgeGeometryVertexUsage.UV0);
					int ColourAttr = Array.FindIndex<igPS3EdgeGeometrySegment.StreamDescAttribute>(rsxOnlyStreamDescAttributes, x => x.usage == igPS3EdgeGeometrySegment.EdgeGeometryVertexUsage.COLOR);
					if(UV0Attr >= 0) PopulateBuffer(rsxOnlyVertexes, out vTexCoords[i], vertexCount, rsxOnlyStreamDescHeader, rsxOnlyStreamDescAttributes[UV0Attr]);
					if(ColourAttr >= 0) PopulateBuffer(rsxOnlyVertexes, out vColours[i], vertexCount, rsxOnlyStreamDescHeader, rsxOnlyStreamDescAttributes[ColourAttr]);
				}

				rsxOnlyVertexes.Dispose();
				rsxOnlyVertexes.Close();
			}
		}
		private void PopulateBuffer(StreamHelper sh, out float[] vertices, uint vertexCount, igPS3EdgeGeometrySegment.StreamDescHeader header, igPS3EdgeGeometrySegment.StreamDescAttribute attr)
		{
			vertices = new float[4 * vertexCount];
			MethodInfo? unpackFunction = typeof(igVertexConversion).GetMethod($"unpack_{attr.type.ToString()}");
			if(unpackFunction == null) throw new NotImplementedException($"Edge Vertex Type {attr.type.ToString()} is not supported");
			object[] unpackParams = new object[1]{sh};
			for(uint i = 0; i < vertexCount; i++)
			{
				sh.Seek(header.stride * i + attr.offset);

				Vector4 v4 = (Vector4)unpackFunction.Invoke(null, unpackParams);
				vertices[i * 4 + 0] = v4.X;
				vertices[i * 4 + 1] = v4.Y;
				vertices[i * 4 + 2] = v4.Z;
				vertices[i * 4 + 3] = v4.W;

				if(attr.usage == igPS3EdgeGeometrySegment.EdgeGeometryVertexUsage.POSITION)
				{
					if(attr.type == igPS3EdgeGeometrySegment.EdgeGeometryVertexType.SHORT4N)
					{
						vertices[i * 4 + 0] = v4.X / v4.W;
						vertices[i * 4 + 1] = v4.Y / v4.W;
						vertices[i * 4 + 2] = v4.Z / v4.W;
						vertices[i * 4 + 3] = 1.0f;
					}
				}
				else if(attr.usage == igPS3EdgeGeometrySegment.EdgeGeometryVertexUsage.COLOR)
				{
					vertices[i * 4 + 0] = v4.W;
					vertices[i * 4 + 1] = v4.Z;
					vertices[i * 4 + 2] = v4.Y;
					vertices[i * 4 + 3] = v4.X;
				}
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