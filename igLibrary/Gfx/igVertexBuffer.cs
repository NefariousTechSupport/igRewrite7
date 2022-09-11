namespace igLibrary.Gfx
{
	public class igVertexBuffer : igObject
	{
		[igField(typeof(igUnsignedIntMetaField), 0x09, 0x00, 0x08, 0x0C, "_vertexCount")]
		public uint _vertexCount;
		[igField(typeof(igMemoryRefMetaField), 0x09, 0x01, 0x0C, 0x10, "_vertexCountArray")]
		public igMemory _vertexCountArray;
		[igField(typeof(igMemoryRefHandleMetaField), 0x09, 0x02, 0x14, 0x20, "_data")]
		public igMemory _data;
		[igField(typeof(igObjectRefMetaField<igVertexFormat>), 0x09, 0x03, 0x18, 0x28, "_format")]
		public igVertexFormat _format;
		[igField(typeof(igEnumMetaField<IG_GFX_DRAW>), 0x09, 0x04, 0x1C, 0x30, "_primitiveType")]
		public IG_GFX_DRAW _primitiveType;
		[igField(typeof(igMemoryRefMetaField), 0x09, 0x05, 0x20, 0x38, "_packData")]
		public igMemory _packData;
		//[igField(typeof(igObjectRefMetaField<igVertexArray>), 0x09, 0x06, 0x24, 0x40, "_vertexArray")]
		//public igVertexArray _vertexArray;
		[igField(typeof(igIntMetaField), 0x09, 0x07, 0x28, 0x48, "_vertexArrayRefCount")]
		public int _vertexArrayRefCount;

		private StreamHelper.Endianness endianness;

		private bool sscFunkiness;

		public void GetBuffer(out float[]? buffer, IG_VERTEX_USAGE usage)
		{
			buffer = new float[_vertexCount * 4];

			StreamHelper sh = new StreamHelper(new MemoryStream(_data.buffer), endianness);

			igVertexElement element = _format.GetElementFromUsage(usage);

			if(element._type == IG_VERTEX_TYPE.UNDEFINED_0 || element._type == IG_VERTEX_TYPE.UNDEFINED_1 || element._type == IG_VERTEX_TYPE.MAX || element._type == IG_VERTEX_TYPE.UNUSED)
			{
				buffer = null;
				return;
			}

			MethodInfo? unpackFunction = typeof(igVertexConversion).GetMethod($"unpack_{element._type.ToString()}");
			if(unpackFunction == null)
			{
				throw new NotImplementedException($"vertexType IG_VERTEX_TYPE_{element._type.ToString()} is not supported");
			}

			object[] unpackParams = new object[1]{sh};

			for(int i = 0; i < _vertexCount; i++)
			{
				sh.Seek(_format._vertexSize * i + element._offset);
				Vector4 v4 = (Vector4)unpackFunction.Invoke(null, unpackParams);
				if(element._usage == IG_VERTEX_USAGE.POSITION)
				{
					if(element._type == IG_VERTEX_TYPE.SHORT4N)
					{
						buffer[i * 4 + 0] = v4.X / v4.W;
						buffer[i * 4 + 1] = v4.Y / v4.W;
						buffer[i * 4 + 2] = v4.Z / v4.W;
						buffer[i * 4 + 3] = 1.0f;
					}

					//buffer[i * 4 + 0] = v4.X;
					//buffer[i * 4 + 1] = v4.Z;
					//buffer[i * 4 + 2] = v4.Y;
					//buffer[i * 4 + 3] = v4.W;
				}
				else
				{
					buffer[i * 4 + 0] = v4.X;
					buffer[i * 4 + 1] = v4.Y;
					buffer[i * 4 + 2] = v4.Z;
					buffer[i * 4 + 3] = v4.W;
				}
			}

			sh.Close();
		}

		public override void ReadFields(igIGZ igz)
		{
			base.ReadFields(igz);

			endianness = igz._stream._endianness;
		}
	}
}