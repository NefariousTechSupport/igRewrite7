namespace igLibrary.Core
{
	public class igIGZSaver
	{
		public igObjectDirectory _dir;
		public List<Type> _vtableList = new List<Type>();
		public StreamHelper _stream;
		public List<igIGZSaverSection> _sections = new List<igIGZSaverSection>();
		public IG_CORE_PLATFORM _platform;
		public uint _version;

		public class igIGZSaverSection
		{
			public StreamHelper _stream;
			public List<ulong> _runtimeOffsets;
			public igIGZSaverSection(StreamHelper.Endianness endianness)
			{
				_stream = new StreamHelper(new MemoryStream(), endianness);
				_runtimeOffsets = new List<ulong>();
			}
		}

		public igIGZSaver(igObjectDirectory dir)
		{
			_dir = dir;
		}
		public void Save(string output, IG_CORE_PLATFORM platform, uint version)
		{
			_platform = platform;
			_version = version;
			_stream = new StreamHelper(File.Create(output));
			if(igCore.IsPlatformBigEndian(_platform)) _stream._endianness = StreamHelper.Endianness.Big;
			else                                      _stream._endianness = StreamHelper.Endianness.Little;

			for(int i = 0; i < 0x20; i++)
			{
				_sections.Add(new igIGZSaverSection(_stream._endianness));
			}

			SaveObject(_sections[0], _dir._objectList);

			SaveHeader();
			WriteFixups();
			for(int i = 0; i < _sections.Count; i++)
			{
				WriteSection(i);
			}

			_stream.BaseStream.Flush();
		}
		private void SaveHeader()
		{
			_stream.Seek(0);
			_stream.WriteUInt32(0x015A4749);
			_stream.WriteUInt32(_version);
			_stream.WriteUInt32(0);
			_stream.WriteUInt32(0);
			_stream.WriteUInt32(0);
		}
		private void WriteFixups()
		{
			_stream.Seek(0x800);
			//TDEP
			//TSTR
			//TMET
			MemoryStream tmetMs = new MemoryStream();
			for(int i = 0; i < _vtableList.Count; i++)
			{
				long basePos = _stream.BaseStream.Position;
				string data = _vtableList[i].Name;
				Console.WriteLine($"Writing TMET {data}");
				tmetMs.Write(System.Text.Encoding.ASCII.GetBytes(data));
				int bits = (_version > 7) ? 2 : 1;
				tmetMs.Seek(basePos + bits + (data.Length & (uint)(-bits)), SeekOrigin.Begin);
			}
			tmetMs.Flush();
			WriteFixupData(0, _vtableList.Count, (int)tmetMs.Length, tmetMs.GetBuffer(), 1);
			//EXID
			//MTSZ
			//TMHN
			//RVTB
			//RSTR
			//ROFS
			//REXT
			//RMHN
			//ROOT
			//ONAM

			_stream.Seek(0x7FC);
			_stream.WriteUInt32(0);
		}
		private void WriteFixupData(uint oldMagic, int count, int length, byte[] buffer, uint requiredAlignment)
		{
			if(_version > 6)
			{
				switch(oldMagic)
				{
					case 0x00: oldMagic = 0x54454D54; break;	//TMET
					case 0x01: oldMagic = 0x54535452; break;	//TSTR
					case 0x02: oldMagic = 0x45584944; break;	//EXID
					case 0x03: oldMagic = 0x45584E4D; break;	//EXNM
					//case 0x04: oldMagic = ????????; break;
					case 0x05: oldMagic = 0x52565442; break;	//RVTB
					//case 0x06: oldMagic = ????????; break;
					//case 0x07: oldMagic = ????????; break;
					//case 0x08: oldMagic = ????????; break;
					//case 0x09: oldMagic = ????????; break;
					case 0x0A: oldMagic = 0x544D484E; break;	//TMHN
					//case 0x0B: oldMagic = ????????; break;
					case 0x0C: oldMagic = 0x4D54535A; break;	//MTSZ
				}
			}
			_stream.WriteUInt32(oldMagic);
			if(_version <= 6) _stream.Seek(8, SeekOrigin.Current);
			_stream.WriteUInt32((uint)count);
			_stream.WriteUInt32((uint)length + 0x10u);
			_stream.WriteUInt32(0x10);
			_stream.BaseStream.Write(buffer, 0, length);	//Length is past like this because MemoryStream capacity can be large
		}
		private void WriteSection(int index)
		{
			uint ogOffset = (uint)(((_stream.BaseStream.Length + 7) / 8) * 8);
			_stream.Seek(0x24 + 0x10 * index);
			_stream.WriteUInt32(0);
			_stream.WriteUInt32(ogOffset);
			_stream.WriteUInt32((uint)_sections[index]._stream.BaseStream.Length);
			_stream.WriteUInt32(1);
			_stream.Seek(ogOffset);
			_sections[index]._stream.BaseStream.Flush();
			_sections[index]._stream.BaseStream.Seek(0, SeekOrigin.Begin);
			_sections[index]._stream.BaseStream.CopyTo(_stream.BaseStream);
		}
		private void SaveObject(igIGZSaverSection section, igObject obj)
		{
			AlignStream(section._stream, igCore.GetSizeOfPointer(_platform));
			long objPos = section._stream.BaseStream.Position;
			IEnumerable<sizeofSize> sizeAttrs = obj.GetType().GetCustomAttributes<sizeofSize>();
			sizeofSize? sizeAttr = null;
			for(int i = 0; i < sizeAttrs.Count(); i++)
			{
				if(sizeAttrs.ElementAt(i)._applicableVersion == 0xFF || sizeAttrs.ElementAt(i)._applicableVersion == _version)
				{
					if(sizeAttrs.ElementAt(i)._platform.Length > 0)
					{
						if(sizeAttrs.ElementAt(i)._platform.Any(x => x == _platform))
						{
							sizeAttr = sizeAttrs.ElementAt(i);
						}
					}
					else sizeAttr = sizeAttrs.ElementAt(i);
				}
				if(sizeAttr != null) break;
			}
			if(sizeAttr == null) throw new NotImplementedException($"sizeofSize for type {obj.GetType().Name}, version {_version}, platform IG_CORE_PLATFORM_{_platform} not implemented");
			if(igCore.IsPlatform64Bit(_platform)) _stream.BaseStream.Write(new byte[sizeAttr._size64]);
			else _stream.BaseStream.Write(new byte[sizeAttr._size32]);
			section._stream.Seek(objPos);
			WriteRawOffset(section._stream, GetVtableIndex(obj.GetType()));
			section._stream.WriteUInt32(0xFF);
			section._stream.Seek(objPos);
			//obj.WriteFields(this, section._stream);
		}
		public void AlignStream(StreamHelper sh, uint alignment)
		{
			if(sh.BaseStream.Position == 0) return;
			sh.Seek((((sh.BaseStream.Position - 1) / alignment) + 1) * alignment);
		}
		public void GetFreeMemory(igIGZSaverSection section)
		{
			section._stream.Seek(section._stream.BaseStream.Length);
			AlignStream(section._stream, igCore.GetSizeOfPointer(_platform));
		}
		public void WriteRawOffset(StreamHelper sh, ulong offset)
		{
			if(igCore.GetSizeOfPointer(_platform) == 4) sh.WriteUInt32((uint)offset);
			else throw new NotImplementedException();
		}
		public ulong GetVtableIndex(Type vtable)
		{
			if(_vtableList.Contains(vtable))
			{
				return (ulong)_vtableList.FindIndex(x => x == vtable);
			}
			_vtableList.Add(vtable);
			return (ulong)_vtableList.Count - 1;
		}
	}
}