namespace igLibrary.Core
{
	public class igRawRefMetaField : igMetaField
	{
		public override ushort Size(bool is64Bit)
		{
			if(is64Bit) return 0x08;
			return 0x04;
		}
		public override object ReadRawMemory(igIGZ igz, bool is64Bit) => igz.DeserializeOffset(igz.ReadRawOffset());
	}
}