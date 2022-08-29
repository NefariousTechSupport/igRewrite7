namespace igLibrary.Core
{
	public class igDataList<T1, T2> : igObject where T2 : igMetaField, new()
	{
		[igField(typeof(igUnsignedIntMetaField), 0xFF, 0, 0x08, 0x0C, "_count")]
		public uint _count;

		[igField(typeof(igUnsignedIntMetaField), 0xFF, 1, 0x0C, 0x10, "_capacity")]
		public uint _capacity;

		[igField(typeof(igMemoryRefMetaField), 0xFF, 2, 0x10, 0x18, "_data")]
		public igMemory _data;

		private List<T1> list = new List<T1>();

		public T1 this[int index]
		{
			get
			{
				return list[index];
			}
			set
			{
				list[index] = value;
			}
		}

		public T1 Append(T1 item)
		{
			list.Add(item);
			_count++;
			return item;
		}

		public void SetCapacity(uint capacity)
		{
			_capacity = capacity;
			list.Capacity = (int)_capacity;
		}

		public void Clear()
		{
			_count = 0;
			list.Clear();
		}

		public virtual void FromMemory(igIGZ igz, bool is64Bit)
		{
			this.SetCapacity(_capacity);
			list.Clear();
			int initialCount = (int)_count;
			_count = 0;

			T2 metafield = new T2();

			int typeSize = metafield.Size(is64Bit);
			/*if(typeof(T1).IsAssignableTo(typeof(igObject)) || typeof(T1) == typeof(string))
			{
				typeSize = igCore.GetSizeOfPointer(igz._platform);
			}
			else
			{
				typeSize = Marshal.SizeOf<T1>();
			}*/
			for(int i = 0; i < initialCount; i++)
			{
				object? appender = null;
				igz._stream.Seek(_data.offset + (ulong)(typeSize * i));
				/*if(typeof(T1).IsAssignableTo(typeof(igObject)))
				{
					ulong offset = igz.DeserializeOffset(igz.ReadRawOffset());
					igz._stream.Seek(offset);
					if(igz._offsetObjectList[offset].GetType().IsAssignableTo(typeof(T1)))
					{
						igz._offsetObjectList[offset].ReadFields(igz);
						appender = igz._offsetObjectList[offset];
					}
					else
					{
						appender = null;
					}
				}
				else if(typeof(T1) == typeof(uint))      appender = igz._stream.ReadUInt32();
				else if(typeof(T1) == typeof(int))       appender = igz._stream.ReadInt32();
				else if(typeof(T1) == typeof(ushort))    appender = igz._stream.ReadUInt16();
				else if(typeof(T1) == typeof(short))     appender = igz._stream.ReadInt16();
				else if(typeof(T1) == typeof(ulong))     appender = igz._stream.ReadUInt64();
				else if(typeof(T1) == typeof(long))      appender = igz._stream.ReadInt64();
				else if(typeof(T1) == typeof(float))     appender = igz._stream.ReadSingle();
				else if(typeof(T1) == typeof(double))    appender = igz._stream.ReadDouble();
				else if(typeof(T1) == typeof(string))    appender = igz._stream.ReadString();
				else if(typeof(T1) == typeof(Vector3))   appender = new Vector3(igz._stream.ReadSingle(), igz._stream.ReadSingle(), igz._stream.ReadSingle());
				else if(typeof(T1) == typeof(Matrix4x4)) appender = new Matrix4x4(
					igz._stream.ReadSingle(), igz._stream.ReadSingle(), igz._stream.ReadSingle(), igz._stream.ReadSingle(),
					igz._stream.ReadSingle(), igz._stream.ReadSingle(), igz._stream.ReadSingle(), igz._stream.ReadSingle(),
					igz._stream.ReadSingle(), igz._stream.ReadSingle(), igz._stream.ReadSingle(), igz._stream.ReadSingle(),
					igz._stream.ReadSingle(), igz._stream.ReadSingle(), igz._stream.ReadSingle(), igz._stream.ReadSingle()
					);
				else if(typeof(T1).IsValueType)  appender = igz._stream.ReadStruct(typeof(T1));*/

				appender = metafield.ReadRawMemory(igz, is64Bit);

				this.Append((T1)appender);
			}
		}

		public override void ReadFields(igIGZ igz)
		{
			ulong offset = (ulong)igz._stream.BaseStream.Position;
			base.ReadFields(igz);
			igz._stream.Seek(offset);
			this.FromMemory(igz, igCore.IsPlatform64Bit(igz._platform));
		}

		public igDataList() : base(){}
	}
	public class igDataList : igDataList<byte, igUnsignedCharMetaField>{}
}