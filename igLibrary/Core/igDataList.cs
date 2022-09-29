namespace igLibrary.Core
{
	[sizeofSize(0xFF, 0x18, 0x28)]
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
			for(int i = 0; i < initialCount; i++)
			{
				object? appender = null;
				igz._stream.Seek(_data.offset + (ulong)(typeSize * i));
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

		public List<T1> ToCSList()
		{
			return list;
		}

		public igDataList() : base(){}
	}
	public class igDataList : igDataList<byte, igUnsignedCharMetaField>{}
}