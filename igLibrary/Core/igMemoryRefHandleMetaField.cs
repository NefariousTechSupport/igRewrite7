namespace igLibrary.Core
{
	public class igMemoryRefHandleMetaField<T> : igMetaField
	{
		public override Type OutputType() => typeof(igMemory);
		public override ushort Size(bool is64Bit)
		{
			if(is64Bit) return 0x08;
			return 0x04;
		}

		public override object ReadRawMemory(igIGZ igz, bool is64Bit)
		{
			ulong raw = igz.ReadRawOffset();
			return igz._thumbnails[(int)raw];
		}
	}
	public class igMemoryRefHandleMetaField : igMemoryRefHandleMetaField<byte>{}
}