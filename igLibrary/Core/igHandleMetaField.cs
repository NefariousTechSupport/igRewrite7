namespace igLibrary.Core
{
	public class igHandleMetaField<T> : igMetaField
	{
		public override ushort Size(bool is64Bit)
		{
			if(is64Bit) return 0x08;
			return 0x04;
		}
		public override Type OutputType() => typeof(T);
		public override object ReadRawMemory(igIGZ igz, bool is64Bit)
		{
			ulong pos = (ulong)igz._stream.BaseStream.Position;
			if(!igz._runtimeHandleList.Any(x => x == pos)) throw new FileLoadException("igHandleMetaField not in RHND, this could be normal");	//check
			uint raw = igz._stream.ReadUInt32();		//idk why this is a uint, if any bugs occur on 64bit big endian platforms this could be why
			if((raw & 0x80000000) != 0)
			{
				return igz._namedHandleList[(int)(raw & 0x3FFFFFFF)];
			}
			else
			{
				return igz._externalList[(int)(raw & 0x3FFFFFFF)];
			}
		}
	}
}