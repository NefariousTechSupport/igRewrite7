namespace igLibrary.Core
{
	public class igStringMetaField : igRawRefMetaField
	{
		public override Type OutputType() => typeof(string);
		public override object ReadRawMemory(igIGZ igz, bool is64Bit)
		{
			ulong raw = igz.ReadRawOffset();
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