namespace igLibrary.Core
{
	public class igUnsignedIntMetaField : igMetaField
	{
		public override Type OutputType() => typeof(uint);
		public override ushort Size(bool is64Bit) => 4;
		public override object ReadRawMemory(igIGZ igz, bool is64Bit) => igz._stream.ReadUInt32();
	}
}