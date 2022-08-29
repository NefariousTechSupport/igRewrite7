namespace igLibrary.Core
{
	public class igLongMetaField : igMetaField
	{
		public override Type OutputType() => typeof(long);
		public override ushort Size(bool is64Bit) => 8;

		public override object ReadRawMemory(igIGZ igz, bool is64Bit) => igz._stream.ReadInt64();
	}
}