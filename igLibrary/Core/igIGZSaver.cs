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
		private uint _numFixups = 0;
		private uint _fixupSectionLength = 0;

		public class igIGZSaverSection
		{
			public StreamHelper _stream;
			public igRuntimeFields _runtimeFields = new igRuntimeFields();
			public int _index { get; private set; }
			public igIGZSaverSection(StreamHelper.Endianness endianness, int index)
			{
				_stream = new StreamHelper(new MemoryStream(), endianness);
				_index = index;
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
				_sections.Add(new igIGZSaverSection(_stream._endianness, i));
			}

			SaveObject(_sections[0], _dir._objectList);
			_sections[0]._runtimeFields._objectLists.Add(_version < 0x09 ? 4u : 0u);

			WriteFixups();
			SaveHeader();
			for(int i = -1; i < _sections.Count; i++)
			{
				WriteSection(i);
			}

			_stream.BaseStream.Flush();
		}
		private void SaveHeader()
		{
			_stream.Seek(0);
			_stream.WriteUInt32(0x49475A01);
			_stream.WriteUInt32(_version);
			_stream.WriteUInt32(0);
			_stream.WriteUInt32((uint)igMetaEnumMember.GetValueFromEnum<IG_CORE_PLATFORM>(_platform, _version));
			_stream.WriteUInt32(_numFixups);
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
				long basePos = tmetMs.Position;
				string data = _vtableList[i].Name;
				Console.WriteLine($"Writing TMET {data}");
				tmetMs.Write(System.Text.Encoding.ASCII.GetBytes(data));
				int bits = (_version > 7) ? 2 : 1;
				tmetMs.Seek(basePos + bits + (data.Length & (uint)(-bits)), SeekOrigin.Begin);
			}
			tmetMs.Flush();
			WriteFixupData(0x00, _vtableList.Count, (int)tmetMs.Length, tmetMs.GetBuffer(), 4);
			//EXID
			//MTSZ
			StreamHelper mtszMs = new StreamHelper(new MemoryStream(_vtableList.Count * 4), _stream._endianness);
			for(int i = 0; i < _vtableList.Count; i++)
			{
				mtszMs.WriteUInt32(sizeofSize.GetSizeOfType(_vtableList[i], _version, _platform));
			}
			WriteFixupData(0x0C, _vtableList.Count, (int)mtszMs.BaseStream.Length, ((MemoryStream)mtszMs.BaseStream).GetBuffer(), 4);
			//TMHN
			//RVTB
			WriteRuntimeFixup(0x05, x => x._vtables);
			//RSTR
			WriteRuntimeFixup(0x52545352, x => x._stringRefs);
			//RSTT
			WriteRuntimeFixup(0x54545352, x => x._stringTables);
			//ROFS
			WriteRuntimeFixup(0x53464F52, x => x._offsets);
			//REXT
			WriteRuntimeFixup(0x54584552, x => x._externals);
			//RMHN
			WriteRuntimeFixup(0x4E484D52, x => x._memoryHandles);
			//ROOT
			WriteRuntimeFixup(0x544F4F52, x => x._objectLists);
			//ONAM

			//Note: replace the new magic numbers with old ones once we know them

			_stream.Seek(0x7FC);
			_stream.WriteUInt32(0);
		}
		private void WriteFixupData(uint oldMagic, int count, int length, byte[] buffer, uint requiredAlignment)
		{
			if(count == 0) return;
			if(_version > 6)
			{
				switch(oldMagic)
				{
					case 0x00: oldMagic = 0x54454D54; break;	//TMET
					case 0x01: oldMagic = 0x52545354; break;	//TSTR
					case 0x02: oldMagic = 0x44495845; break;	//EXID
					case 0x03: oldMagic = 0x4D4E5845; break;	//EXNM
					//case 0x04: oldMagic = ????????; break;
					case 0x05: oldMagic = 0x42545652; break;	//RVTB
					//case 0x06: oldMagic = ????????; break;
					//case 0x07: oldMagic = ????????; break;
					//case 0x08: oldMagic = ????????; break;
					//case 0x09: oldMagic = ????????; break;
					case 0x0A: oldMagic = 0x4E484D54; break;	//TMHN
					//case 0x0B: oldMagic = ????????; break;
					case 0x0C: oldMagic = 0x5A53544D; break;	//MTSZ
				}
			}
			uint basePos = _stream.Tell();

			_stream.WriteUInt32(oldMagic);
			if(_version <= 6) _stream.Seek(8, SeekOrigin.Current);
			_stream.WriteUInt32((uint)count);

			uint dataStart = _version <= 0x06 ? 0x18u : 0x10u + basePos;
			dataStart = ((dataStart + (requiredAlignment - 1)) / requiredAlignment) * requiredAlignment;
			dataStart -= basePos;

			uint fixupLength = (uint)(((length + 3) / 4) * 4) + dataStart;
			_stream.WriteUInt32(fixupLength);
			_stream.WriteUInt32(dataStart);
			_stream.Seek(basePos + dataStart);
			_stream.BaseStream.Write(buffer, 0, length);	//Length is past like this because MemoryStream capacity can be large
			AlignStream(_stream, 4);
			_numFixups++;
			_fixupSectionLength += fixupLength;
		}
		private void WriteRuntimeFixup(uint magic, Func<igRuntimeFields, List<ulong>> runtimeField)
		{
			List<ulong> uncompressed = GetAllRuntimes(runtimeField);
			byte[] compressed = PackUncompressedIntegers(uncompressed.Count, uncompressed);
			WriteFixupData(magic, uncompressed.Count, compressed.Length, compressed, 4);
		}
		private List<ulong> GetAllRuntimes(Func<igRuntimeFields, List<ulong>> runtimeField)
		{
			List<ulong> allRuntimes = new List<ulong>();
			for(int i = 0; i < _sections.Count; i++)
			{
				List<ulong> sectionRuntimes = runtimeField.Invoke(_sections[i]._runtimeFields);
				sectionRuntimes.Sort();
				for(int j = 0; j < sectionRuntimes.Count; j++)
				{
					if(_version <= 0x06) allRuntimes.Add(sectionRuntimes[j] + ((uint)i << 0x18));
					else                 allRuntimes.Add(sectionRuntimes[j] + ((uint)i << 0x1B));
				}
			}
			return allRuntimes;
		}
		private void WriteSection(int index)
		{
			if(index == -1)
			{
				_stream.Seek(0x14);
				_stream.WriteUInt32(0);
				_stream.WriteUInt32(0x800);
				_stream.WriteUInt32(_fixupSectionLength);
				_stream.WriteUInt32(1);
				return;
			}
			uint ogOffset = (uint)(((_stream.BaseStream.Length + 7) / 8) * 8);
			_stream.Seek(0x24 + 0x10 * index);
			_stream.WriteUInt32(0);
			_stream.WriteUInt32(ogOffset);
			_stream.WriteUInt32((uint)_sections[index]._stream.BaseStream.Length);
			_stream.WriteUInt32(1);
			_stream.Seek(ogOffset);

			for(int i = 0; i < _sections[index]._runtimeFields._offsets.Count; i++)
			{
				_sections[index]._stream.Seek(_sections[index]._runtimeFields._offsets[i]);
				uint rawOffset = _sections[index]._stream.ReadUInt32();
				rawOffset |= (uint)(index << 0x1B);
				_sections[index]._stream.Seek(_sections[index]._runtimeFields._offsets[i]);
				_sections[index]._stream.WriteUInt32(rawOffset);
			}

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
			obj.WriteFields(this, section._index);
		}
		public void AlignStream(StreamHelper sh, uint alignment)
		{
			if(sh.BaseStream.Position == 0) return;
			sh.Seek(((sh.BaseStream.Position + alignment - 1) / alignment) * alignment);
		}
		public ulong GetFreeMemory(igIGZSaverSection section)
		{
			section._stream.Seek(section._stream.BaseStream.Length);
			AlignStream(section._stream, igCore.GetSizeOfPointer(_platform));
			return (ulong)section._stream.BaseStream.Position;
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
		byte[] PackUncompressedIntegers(int count, List<ulong> offsets)
		{
			List<byte> compressedData = new List<byte>();

			ulong previousInt = 0x00;
			bool shiftMoveOrMask = false;
			byte currentByte = 0x00;
			int shiftAmount = 0x00;

			for(int i = 0; i < count; i++)
			{
				bool firstPass = true;
				ulong deltaInt = (offsets[i] - previousInt) / 4 - (_version < 0x09 ? 1u : 0u);
				previousInt = offsets[i];
				while(true)
				{
					byte delta = (byte)((deltaInt >> shiftAmount) & 0b0111);
					ulong remaining = ((deltaInt >> shiftAmount) & ~0b0111u);
					if(remaining > 0 || delta > 0 || firstPass)
					{
						if(remaining != 0)
						{
							delta |= 0x08;
						}
						shiftAmount += 3;
						if(shiftMoveOrMask)
						{
							currentByte |= (byte)(delta << 4);
							compressedData.Add(currentByte);
							currentByte = 0x00;
						}
						else
						{
							currentByte |= delta;
						}
						firstPass = false;
						shiftMoveOrMask = !shiftMoveOrMask;
					}
					else
					{
						shiftAmount = 0;
						previousInt = offsets[i];
						break;
					}
				}
			}
			if(shiftMoveOrMask)
			{
				compressedData.Add(currentByte);
			}

			return compressedData.ToArray();
		}
	}
}