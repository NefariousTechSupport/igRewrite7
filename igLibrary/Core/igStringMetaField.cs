namespace igLibrary.Core
{
	public class igStringMetaField : igRawRefMetaField
	{
		public override Type OutputType() => typeof(string);
		public override object ReadRawMemory(igIGZ igz, bool is64Bit)
		{
			if(igz._runtimeStringTables.Any(x => x == (ulong)igz._stream.BaseStream.Position))
			{
				ulong raw = igz.ReadRawOffset();
				return igz._stringList[(int)raw];
			}
			else if(igz._runtimeStringRefs.Any(x => x == (ulong)igz._stream.BaseStream.Position))
			{
				ulong raw = igz.ReadRawOffset();
				igz._stream.Seek(igz.DeserializeOffset(raw));
				return igz._stream.ReadString();
			}
			else return null;
		}
	}
}