namespace igLibrary.Core
{
	public class igObjectRefMetaField<T> : igRawRefMetaField where T : igObject
	{
		public override Type OutputType() => typeof(T);
		public override object ReadRawMemory(igIGZ igz, bool is64Bit)
		{
			bool isExid = igz._runtimeFields._externals.Any(x => x == (ulong)igz._stream.BaseStream.Position);
			bool isOffset = igz._runtimeFields._offsets.Any(x => x == (ulong)igz._stream.BaseStream.Position);
			bool isNamedExternal = igz._runtimeFields._namedExternals.Any(x => x == (ulong)igz._stream.BaseStream.Position);
			ulong raw = igz.ReadRawOffset();
			igObject? ret = null;
			if(raw == 0) return null;
			if(isNamedExternal)
			{
				try
				{
					ret = igz._namedExternalList[(int)(raw & 0x7FFFFFFF)];
				}
				catch(Exception e)
				{
					Console.WriteLine($"NamedExternal Error: {e.Message} @ {igz._stream.BaseStream.Position - igCore.GetSizeOfPointer(igz._platform)}");
					ret = null;
				}
			}
			else if(isOffset)
			{
				ret = igz._offsetObjectList[igz.DeserializeOffset(raw)];
				igz._stream.Seek(igz.DeserializeOffset(raw));
				ret.ReadFields(igz);
			}
			else if(isExid)
			{
				ret = igz._externalList[(int)(raw & 0x7FFFFFFF)].GetObject<T>();
			}
			else
			{
				Console.WriteLine("uhhhhhhhhhhhhhhhhh");
			}
			if(ret is T t) return t;
			else return null;
		}
		public override void WriteRawMemory(igIGZSaver igz, igIGZSaver.igIGZSaverSection section, bool is64Bit, object? data)
		{
			uint basePos = section._stream.Tell();
			ulong freeMemory = igz.GetFreeMemory(section);
			section._stream.Seek(basePos);
			section._runtimeFields._offsets.Add(section._stream.Tell64());
			section._stream.WriteUInt32((uint)freeMemory);
			section._stream.Seek(freeMemory);
			((igObject)data).WriteFields(igz, section._index);
		}
	}
}