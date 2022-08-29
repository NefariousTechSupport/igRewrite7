namespace igLibrary.Core
{
	public class igFloatMetaField : igMetaField
	{
		public override Type OutputType() => typeof(float);
		public override ushort Size(bool is64Bit) => 4;
		public override object ReadRawMemory(igIGZ igz, bool is64Bit) => igz._stream.ReadSingle();
	}
}