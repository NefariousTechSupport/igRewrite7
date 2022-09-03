namespace igLibrary.Core
{
	public class igVectorMetaField<T1, T2> : igMetaField where T2 : igMetaField, new()
	{
		public override Type OutputType() => typeof(byte);
		public override ushort Size(bool is64Bit)
		{
			if(is64Bit) return 0x18;	//should be different for when version's greater than 9
			return 0x0C;
		}

		public override object ReadRawMemory(igIGZ igz, bool is64Bit)
		{
			ulong count;
			igMemory mem;
			igMemoryRefMetaField memMetaField = new igMemoryRefMetaField();
			if(igz._version == 0x09 && is64Bit)
			{
				count = igz._stream.ReadUInt64();
			}
			else
			{
				count = igz._stream.ReadUInt32();
			}

			mem = (igMemory)memMetaField.ReadRawMemory(igz, is64Bit);

			List<T1> list = new List<T1>((int)count);

			int initialCount = (int)count;

			T2 metafield = new T2();

			int typeSize = metafield.Size(is64Bit);
			for(int i = 0; i < initialCount; i++)
			{
				object? appender = null;
				igz._stream.Seek(mem.offset + (ulong)(typeSize * i));
				appender = metafield.ReadRawMemory(igz, is64Bit);

				if(appender != null)
				{
					if(typeof(T1).IsAssignableFrom(appender.GetType()))
					{
						list.Add((T1)appender);
						continue;
					}
				}
				if(typeof(T1).IsValueType)
				{
					list.Add((T1)Activator.CreateInstance(typeof(T1)));
				}
				else
				{
					appender = null;
					list.Add((T1)appender);
				}
			}

			return list;
		}
	}
}