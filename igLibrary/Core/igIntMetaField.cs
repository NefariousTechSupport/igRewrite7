namespace igLibrary.Core
{
	public class igIntMetaField : igMetaField
	{
		public override Type OutputType() => typeof(int);
		public override ushort Size(bool is64Bit) => 4;

		public override object ReadRawMemory(igIGZ igz, bool is64Bit) => igz._stream.ReadInt32();
		public override void WriteRawMemory(igIGZSaver igz, igIGZSaver.igIGZSaverSection section, bool is64Bit, object? data)
		{
			if(data == null) throw new ArgumentNullException("What the h*ck is a null int???");
			else             section._stream.WriteInt32((int)data);
		}
	}
}