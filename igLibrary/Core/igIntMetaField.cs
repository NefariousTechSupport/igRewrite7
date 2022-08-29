namespace igLibrary.Core
{
	public class igIntMetaField : igMetaField
	{
		public override Type OutputType() => typeof(int);
		public override ushort Size(bool is64Bit) => 4;

		public override object ReadRawMemory(igIGZ igz, bool is64Bit) => igz._stream.ReadInt32();
	}
}