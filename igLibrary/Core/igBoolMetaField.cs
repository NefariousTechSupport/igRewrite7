namespace igLibrary.Core
{
	public class igBoolMetaField : igMetaField
	{
		public override ushort Size(bool is64Bit) => 1;
		public override Type OutputType() => typeof(bool);
		public override object ReadRawMemory(igIGZ igz, bool is64Bit) => igz._stream.ReadBoolean();
	}
}