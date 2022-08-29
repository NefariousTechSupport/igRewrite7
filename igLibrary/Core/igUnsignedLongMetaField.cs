namespace igLibrary.Core
{
	public class igUnsignedLongMetaField : igMetaField
	{
		public override Type OutputType() => typeof(ulong);
		public override ushort Size(bool is64Bit) => 8;

		public override object ReadRawMemory(igIGZ igz, bool is64Bit) => igz._stream.ReadUInt64();
	}
}