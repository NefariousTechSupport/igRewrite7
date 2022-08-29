namespace igLibrary.Core
{
	public class igUnsignedShortMetaField : igMetaField
	{
		public override Type OutputType() => typeof(ushort);
		public override ushort Size(bool is64Bit) => 2;

		public override object ReadRawMemory(igIGZ igz, bool is64Bit) => igz._stream.ReadUInt16();
	}
}