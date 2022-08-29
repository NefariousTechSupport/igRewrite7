namespace igLibrary.Core
{
	public class igSizeTypeMetaField : igMetaField
	{
		public override ushort Size(bool is64Bit)
		{
			if(is64Bit) return 0x08;
			return 0x04;
		}

		public override Type OutputType() => typeof(ulong);

		public override object ReadRawMemory(igIGZ igz, bool is64Bit) => igz.ReadRawOffset();
	}
}