namespace igLibrary.Core
{
	public class igMemoryRefMetaField<T> : igMetaField where T : igMetaField, new()
	{
		public override ushort Size(bool is64Bit)
		{
			if(is64Bit) return 0x10;
			return 0x08;
		}
		public override Type OutputType() => typeof(igMemory);
		public override object ReadRawMemory(igIGZ igz, bool is64Bit)
		{
			igMemory mem;
			mem.size = igz.ReadRawOffset() & 0x07FFFFFF;
			ulong raw = igz.ReadRawOffset();
			long end = igz._stream.BaseStream.Position;
			mem.offset = igz.DeserializeOffset(raw);
			
			igz._stream.Seek(mem.offset);

			byte[] realBuffer = igz._stream.ReadBytes((int)mem.size);

			T metaField = new T();
			if(metaField.OutputType().IsClass) throw new NotImplementedException("uh nah classes don't work here sorry");
			int fakeSize = Marshal.SizeOf(metaField.OutputType());
			uint count = (uint)mem.size / metaField.Size(is64Bit);
			mem.buffer = new byte[count * fakeSize];
			IntPtr ptr = Marshal.AllocHGlobal(fakeSize);
			for(uint i = 0; i < count; i++)
			{
				igz._stream.Seek(mem.offset + i * metaField.Size(is64Bit));
				object item = metaField.ReadRawMemory(igz, is64Bit);
				//typeof(Marshal).GetMethod("StructureToPtr", 1, new Type[2]{typeof(IntPtr), typeof(bool)}).MakeGenericMethod(metaField.OutputType()).Invoke(null, new object[3]{item, ptr, true});
				Marshal.StructureToPtr(item, ptr, true);
				Marshal.Copy(ptr, mem.buffer, (int)i * fakeSize, fakeSize);
			}

			Marshal.FreeHGlobal(ptr);

			igz._stream.Seek(end);
			return mem;
		}
		public override void WriteRawMemory(igIGZSaver igz, igIGZSaver.igIGZSaverSection section, bool is64Bit, object? data)
		{
			byte[]? bytes = (byte[]?)data;
			if(bytes == null)
			{
				section._stream.WriteUInt64(0);
				if(is64Bit)
				{
					section._stream.WriteUInt64(0);
				}
			}
			else
			{
				section._stream.WriteUInt32((uint)bytes.Length);
				igz.AlignStream(section._stream, is64Bit ? 8u : 4u);
				ulong memOffset = (ulong)section._stream.BaseStream.Position;
				ulong offset = igz.GetFreeMemory(section);
				section._stream.BaseStream.Write(bytes);
				section._stream.Seek(memOffset);
				section._stream.WriteUInt32((uint)offset);
				section._runtimeFields._offsets.Add(memOffset);
			}
		}
	}
	public class igMemoryRefMetaField : igMemoryRefMetaField<igUnsignedCharMetaField>{}
}