namespace igLibrary.Core
{
	public class igVectorMetaField<T> : igMetaField
	{
		public override Type OutputType() => typeof(byte);
		public override ushort Size(bool is64Bit)
		{
			if(is64Bit) return 0x18;	//should be different for when version's greater than 9
			return 0x0C;
		}

		public override object ReadRawMemory(igIGZ igz, bool is64Bit)
		{
			List<T> list = new List<T>();

			int typeSize;
			if(typeof(T).IsAssignableTo(typeof(igObject)) || typeof(T) == typeof(string))
			{
				typeSize = igCore.GetSizeOfPointer(igz._platform);
			}
			else
			{
				typeSize = Marshal.SizeOf<T>();
			}

			ulong count;
			ulong size;
			if(igz._version == 0x09 && is64Bit)
			{
				count = igz._stream.ReadUInt64();
				size = igz._stream.ReadUInt64() & 0x00FFFFFF;
			}
			else
			{
				count = igz._stream.ReadUInt32();
				size = igz._stream.ReadUInt32() & 0x00FFFFFF;
			}
			ulong offset = igz.DeserializeOffset(igz.ReadRawOffset());

			for(int i = 0; i < (int)count; i++)
			{
				object? appender = null;
				igz._stream.Seek(offset + (ulong)(typeSize * i));
				if(typeof(T).IsAssignableTo(typeof(igObject)))
				{
					ulong objOffset = igz.DeserializeOffset(igz.ReadRawOffset());
					igz._stream.Seek(objOffset);
					if(igz._offsetObjectList[objOffset].GetType().IsAssignableTo(typeof(T)))
					{
						igz._offsetObjectList[objOffset].ReadFields(igz);
						appender = igz._offsetObjectList[objOffset];
					}
					else
					{
						appender = null;
					}
				}
				else if(typeof(T) == typeof(uint))      appender = igz._stream.ReadUInt32();
				else if(typeof(T) == typeof(int))       appender = igz._stream.ReadInt32();
				else if(typeof(T) == typeof(ushort))    appender = igz._stream.ReadUInt16();
				else if(typeof(T) == typeof(short))     appender = igz._stream.ReadInt16();
				else if(typeof(T) == typeof(ulong))     appender = igz._stream.ReadUInt64();
				else if(typeof(T) == typeof(long))      appender = igz._stream.ReadInt64();
				else if(typeof(T) == typeof(float))     appender = igz._stream.ReadSingle();
				else if(typeof(T) == typeof(double))    appender = igz._stream.ReadDouble();
				else if(typeof(T) == typeof(string))    appender = igz._stream.ReadString();
				else if(typeof(T) == typeof(Vector3))   appender = new Vector3(igz._stream.ReadSingle(), igz._stream.ReadSingle(), igz._stream.ReadSingle());
				else if(typeof(T) == typeof(Matrix4x4)) appender = new Matrix4x4(
					igz._stream.ReadSingle(), igz._stream.ReadSingle(), igz._stream.ReadSingle(), igz._stream.ReadSingle(),
					igz._stream.ReadSingle(), igz._stream.ReadSingle(), igz._stream.ReadSingle(), igz._stream.ReadSingle(),
					igz._stream.ReadSingle(), igz._stream.ReadSingle(), igz._stream.ReadSingle(), igz._stream.ReadSingle(),
					igz._stream.ReadSingle(), igz._stream.ReadSingle(), igz._stream.ReadSingle(), igz._stream.ReadSingle()
					);
				else if(typeof(T).IsValueType)  appender = igz._stream.ReadStruct(typeof(T));
				list.Add((T)appender);
			}

			return list;
		}
	}
}