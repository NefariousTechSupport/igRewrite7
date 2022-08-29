namespace igLibrary.Core
{
	public class igUnsignedCharMetaField : igMetaField
	{
		public override Type OutputType() => typeof(byte);
		public override ushort Size(bool is64Bit) => 1;
		public override object ReadRawMemory(igIGZ igz, bool is64Bit) => igz._stream.ReadByte();
	}
}