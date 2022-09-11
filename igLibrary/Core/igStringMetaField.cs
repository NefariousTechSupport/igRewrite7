namespace igLibrary.Core
{
	public class igStringMetaField : igRawRefMetaField
	{
		public override Type OutputType() => typeof(string);
		public override object ReadRawMemory(igIGZ igz, bool is64Bit)
		{
			bool isValidString = igz._runtimeStrings.Any(x => x == (ulong)igz._stream.BaseStream.Position);
			ulong raw = igz.ReadRawOffset();
			if(!isValidString) return null;
			if((int)raw < igz._stringList.Count)
			{
				return igz._stringList[(int)raw];
			}
			else
			{
				igz._stream.Seek(igz.DeserializeOffset(raw));
				return igz._stream.ReadString();
			}
		}
	}
}