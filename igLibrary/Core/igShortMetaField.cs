namespace igLibrary.Core
{
	public class igShortMetaField : igMetaField
	{
		public override Type OutputType() => typeof(short);
		public override ushort Size(bool is64Bit) => 2;
		public override object ReadRawMemory(igIGZ igz, bool is64Bit) => igz._stream.ReadInt16();
	}
}