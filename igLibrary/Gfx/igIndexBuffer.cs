namespace igLibrary.Gfx
{
	public class igIndexBuffer : igObject
	{
		[igField(typeof(igUnsignedIntMetaField), 0x09, 0x00, 0x08, 0x0C, "_indexCount")]
		public uint _indexCount;
		[igField(typeof(igMemoryRefMetaField), 0x09, 0x01, 0x0C, 0x10, "_indexCountArray")]
		public igMemory _indexCountArray;
		[igField(typeof(igMemoryRefHandleMetaField), 0x09, 0x02, 0x14, 0x20, "_data")]
		public igMemory _data;
		//[igObjectRefMetaField(0x09, 0x03, 0x18, 0x28, "_format", typeof(igIndexFormat))]
		//public igIndexFormat _format;
		//[igEnumMetaField(0x09, 0x04, 0x1C, 0x30, "_primitiveType", typeof(IG_GFX_DRAW))]
		//public IG_GFX_DRAW _primitiveType;
		//[igObjectRefMetaField(0x09, 0x05, 0x20, 0x38, "_vertexFormat", typeof(igVertexFormat))]
		//public igVertexFormat _vertexFormat;
		//[igObjectRefMetaField(0x09, 0x06, 0x24, 0x40, "_indexArray", typeof(igIndexArray2))]
		//public igIndexArray2 _indexArray;
		//[igIntMetaField(0x09, 0x07, 0x28, 0x48, "_indexArrayRefCount")]
		//public int _indexArrayRefCount;

		private StreamHelper.Endianness endianness;

		public void GetBuffer(out uint[] indices, uint vertexCount)
		{
			indices = new uint[_indexCount];

			StreamHelper sh = new StreamHelper(new MemoryStream(_data.buffer), endianness);

			for(int i = 0; i < _indexCount; i++)
			{
				if(vertexCount <= 0xFFFF) indices[i] = sh.ReadUInt16();
				else                      indices[i] = sh.ReadUInt32();
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