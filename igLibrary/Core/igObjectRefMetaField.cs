namespace igLibrary.Core
{
	public class igObjectRefMetaField<T> : igRawRefMetaField
	{
		public override Type OutputType() => typeof(T);
		public override object ReadRawMemory(igIGZ igz, bool is64Bit)
		{
			bool isExid = igz._runtimeExternals.Any(x => x == (ulong)igz._stream.BaseStream.Position);
			ulong raw = igz.ReadRawOffset();
			igObject? ret = null;
			if(raw == 0) return null;
			if(isExid)
			{
				return igz._namedExternalList[(int)(raw & 0x7FFFFFFF)];
			}
			else
			{
				ret = igz._offsetObjectList[igz.DeserializeOffset(raw)];
				igz._stream.Seek(igz.DeserializeOffset(raw));
				ret.ReadFields(igz);
			}
			return ret;
		}
	}
}