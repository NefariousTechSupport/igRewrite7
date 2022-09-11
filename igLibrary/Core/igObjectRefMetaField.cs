namespace igLibrary.Core
{
	public class igObjectRefMetaField<T> : igRawRefMetaField where T : igObject
	{
		public override Type OutputType() => typeof(T);
		public override object ReadRawMemory(igIGZ igz, bool is64Bit)
		{
			bool isExid = igz._runtimeExternals.Any(x => x == (ulong)igz._stream.BaseStream.Position);
			bool isOffset = igz._runtimeOffsetList.Any(x => x == (ulong)igz._stream.BaseStream.Position);
			//bool isPID = igz._runtimePID.Any(x => x == (ulong)igz._stream.BaseStream.Position);
			bool isNamedExternal = igz._runtimeNamedExternals.Any(x => x == (ulong)igz._stream.BaseStream.Position);
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
	}
}