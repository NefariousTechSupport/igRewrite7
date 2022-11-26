namespace igLibrary.Core
{
	public class igUnsignedIntMetaField : igMetaField
	{
		public override Type OutputType() => typeof(uint);
		public override ushort Size(bool is64Bit) => 4;
		public override object ReadRawMemory(igIGZ igz, bool is64Bit) => igz._stream.ReadUInt32();
		public override void WriteRawMemory(igIGZSaver igz, igIGZSaver.igIGZSaverSection section, bool is64Bit, object? data)
		{
			section._stream.WriteUInt32((uint)data);
			Console.WriteLine($"Wrote uint @ {section._stream.BaseStream.Position.ToString("X08")}");
		}
	}
}