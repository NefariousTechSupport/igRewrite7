namespace igLibrary.Core
{
	public class igIGZ
	{
		public List<string> _stringList = new List<string>();
		public List<string> _vtableList = new List<string>();
		public List<ulong> _runtimeVtableList = new List<ulong>();
		public Dictionary<ulong, igObject> _offsetObjectList = new Dictionary<ulong, igObject>();
		public List<ulong> _runtimeObjectListList = new List<ulong>();
		public List<ulong> _runtimeHandleList = new List<ulong>();
		public List<ulong> _runtimeExternals = new List<ulong>();
		public List<igHandle> _externalList = new List<igHandle>();
		public List<igHandle> _namedHandleList = new List<igHandle>();
		public List<igHandle> _unresolvedNames = new List<igHandle>();
		public igObjectList _namedExternalList = new igObjectList();
		public List<igMemory> _thumbnails = new List<igMemory>();
		public uint _version;
		public uint _typeHash;
		public IG_CORE_PLATFORM _platform;
		public uint _numFixups;
		public igFileDescriptor _file;
		public StreamHelper _stream;
		public uint _fixups;
		public uint[] _loadedPointers = new uint[0x1F];
		private ulong nameListOffset = 0;
		
		public igIGZ(igObjectDirectory dir, igFileDescriptor file)
		{
			if(file._stream.BaseStream.Length < 0x800) throw new InvalidDataException($"file {file._path} is not large enough with only {file._stream.BaseStream.Length.ToString("X08")} instead pf 0x00000800.");
			_file = file;
			_stream = _file._stream;
			_stream.Seek(0);
			Directory.CreateDirectory($"debug/{Path.GetDirectoryName(file._path)}");
			File.WriteAllBytes("debug/" + file._path, (file._stream.BaseStream as MemoryStream).GetBuffer());

			uint magic = _stream.ReadUInt32();
			if(magic == 0x015A4749) _stream._endianness = StreamHelper.Endianness.Big;

			_version = _stream.ReadUInt32();
			_typeHash = _stream.ReadUInt32();
			_platform = igCore.GetPlatform(_version, _stream.ReadUInt32());
			_numFixups = _stream.ReadUInt32();

			ParseSections();
			ProcessFixupSections(dir);

			ProcessObjectList(dir);
		}

		public void ParseSections()
		{
			for(int i = 0; i < 0x20; i++)
			{
				_stream.Seek(0x14 + 0x10 * i);
				uint unknown = _stream.ReadUInt32();
				uint offset = _stream.ReadUInt32();
				uint length = _stream.ReadUInt32();
				uint alignment = _stream.ReadUInt32();

				if(i > 0) _loadedPointers[i - 1] = offset;
				else      _fixups = offset;
			}
		}

		public void ProcessFixupSections(igObjectDirectory dir)
		{
			uint bytesProcessed = 0;

			for(int i = 0; i < _numFixups; i++)
			{
				_stream.Seek(_fixups + bytesProcessed);
				uint magic = _stream.ReadUInt32();
				uint count = _stream.ReadUInt32();
				uint length = _stream.ReadUInt32();
				uint start = _stream.ReadUInt32();
				_stream.Seek(_fixups + bytesProcessed + start);

				switch(magic)
				{
					case 0x54454D54:
						_vtableList.Capacity = (int)count;
						for(uint j = 0; j < count; j++)
						{
							long basePos = _stream.BaseStream.Position;
							string data = _stream.ReadString();
							_vtableList.Add(data);
							int bits = (_version > 7) ? 2 : 1;
							_stream.Seek(basePos + bits + (data.Length & (uint)(-bits)));
						}
						break;
					case 0x52545354:
						_stringList.Capacity = (int)count;
						for(uint j = 0; j < count; j++)
						{
							long basePos = _stream.BaseStream.Position;
							string data = _stream.ReadString();
							_stringList.Add(data);
							int bits = (_version > 7) ? 2 : 1;
							_stream.Seek(basePos + bits + (data.Length & (uint)(-bits)));
						}
						break;
					case 0x50454454:
						dir._dependancies.Capacity = (int)count;
						for(uint j = 0; j < count; j++)
						{
							Tuple<string, string> dependancy = new Tuple<string, string>(_stream.ReadString(), _stream.ReadString());
							dir._dependancies.Add(igObjectStreamManager.Singleton.GetDirectoryByName(dependancy.Item2));
						}
						break;
					case 0x44495845:
						_namedExternalList.SetCapacity(count);
						for(uint j = 0; j < count; j++)
						{
							igHandleName depName = new igHandleName();
							uint rawDepNameHash = _stream.ReadUInt32();
							uint rawDepNSHash = _stream.ReadUInt32();
							depName._name._hash = rawDepNameHash;
							depName._ns._hash = rawDepNSHash;

							igObject? obj = null;
							if(!igObjectStreamManager.Singleton._directories.Any(x => x.Value._name._hash == depName._ns._hash))
							{
								Console.WriteLine($"igIGZ EXID load: Failed to find {depName._ns._hash.ToString("X08")}");
								goto finish;
							}
							Console.WriteLine($"igIGZ EXID load: Successfully found {depName._ns._hash.ToString("X08")}");
							igObjectDirectory dependantDir = igObjectStreamManager.Singleton._directories.First(x => x.Value._name._hash == depName._ns._hash).Value;
							if(dependantDir._useNameList)
							{
								for(int k = 0; k < dependantDir._nameList._count; k++)
								{
									if(dependantDir._nameList[k]._hash == depName._name._hash)
									{
										obj = dependantDir._objectList[k];
										break;
									}
								}
							}
							finish:
								_namedExternalList.Append(obj);
						}
						break;
					case 0x4D4E5845:
						for(uint j = 0; j < count; j++)
						{
							igHandleName depHandleName = new igHandleName();
							uint rawDepHNameName = 0;
							uint rawDepHNameNS = 0;
							uint h1 = _stream.ReadUInt32();
							uint h2 = _stream.ReadUInt32();
							if((h2 & 0x80000000) != 0)
							{
								rawDepHNameName = h1;
								rawDepHNameNS = h2;
							}
							else
							{
								rawDepHNameNS = h1;
								rawDepHNameName = h2;
							}
							depHandleName._name.SetString(_stringList[(int)(rawDepHNameName & 0x7FFFFFFF)]);
							depHandleName._ns.SetString(_stringList[(int)(rawDepHNameNS & 0x7FFFFFFF)]);

							igObject? obj = null;
							if(!dir._dependancies.Any(x => x._name._hash == depHandleName._ns._hash))
							{
								Console.WriteLine($"igIGZ EXNM load: Failed to find namespace {depHandleName._ns._string}");
							}
							else
							{
								Console.WriteLine($"igIGZ EXNM load: Successfully found namespace {depHandleName._ns._string}");
								igObjectDirectory dependantDir = dir._dependancies.First(x => x._name._hash == depHandleName._ns._hash);
								if(dependantDir._useNameList)
								{
									for(int k = 0; k < dependantDir._nameList._count; k++)
									{
										if(dependantDir._nameList[k]._hash == depHandleName._name._hash)
										{
											obj = dependantDir._objectList[k];
											break;
										}
									}
								}
							}

							if((rawDepHNameNS & 0x80000000) != 0)
							{
								_namedHandleList.Add(new igHandle(depHandleName));
							}
							else
							{
								if(obj == null)
								{
									_unresolvedNames.Add(new igHandle(depHandleName));
									Console.WriteLine($"{depHandleName._ns._string}:/{depHandleName._name._string} is unresolved");
								}
								else
								{
									_namedHandleList.Add(new igHandle(depHandleName));
								}
							}
						}
						break;
					case 0x4E484D54:
						_thumbnails.Capacity = (int)count;
						for(uint j = 0; j < count; j++)
						{
							igMemoryRefMetaField metafield = new igMemoryRefMetaField();
							igMemory mem = (igMemory)metafield.ReadRawMemory(this, igCore.IsPlatform64Bit(_platform));
							_thumbnails.Add(mem);
						}
						break;
					case 0x4D414E4F:
						dir._useNameList = true;
						nameListOffset = DeserializeOffset(_stream.ReadUInt32());
						igNameList nameList = _offsetObjectList[nameListOffset] as igNameList;
						_stream.Seek(nameListOffset);
						nameList.ReadFields(this);
						dir._nameList = nameList;
						break;
					case 0x42545652:
						UnpackCompressedInts(_runtimeVtableList, _stream.ReadBytes(length - start), count);
						InstantiateAndAppendObjects();
						break;
					case 0x544F4F52:
						UnpackCompressedInts(_runtimeObjectListList, _stream.ReadBytes(length - start), count);
						break;
					case 0x444E4852:
						UnpackCompressedInts(_runtimeHandleList, _stream.ReadBytes(length - start), count);
						break;
					case 0x54584552:
						UnpackCompressedInts(_runtimeExternals, _stream.ReadBytes(length - start), count);
						break;

				}

				bytesProcessed += length;
			}
		}

		public void UnpackCompressedInts(List<ulong> list, byte[] bytes, uint count)
		{
			list.Capacity = (int)count;
			uint previousInt = 0;

			bool shiftMoveOrMask = false;

			unsafe
			{
				fixed(byte *fixedData = bytes)
				{
					byte* data = fixedData;
					for (int i = 0; i < count; i++)
					{
						uint currentByte;

						if (!shiftMoveOrMask)
						{
							currentByte = (uint)*data & 0xf;
							shiftMoveOrMask = true;
						}
						else
						{
							currentByte = (uint)(*data >> 4);
							data++;
							shiftMoveOrMask = false;
						}
						byte shiftAmount = 3;
						uint unpackedInt = currentByte & 7;
						while ((currentByte & 8) != 0)
						{
							if (!shiftMoveOrMask)
							{
								currentByte = (uint)*data & 0xf;
								shiftMoveOrMask = true;
							}
							else
							{
								currentByte = (uint)(*data >> 4);
								data++;
								shiftMoveOrMask = false;
							}
							unpackedInt = unpackedInt | (currentByte & 7) << (byte)(shiftAmount & 0x1f);
							shiftAmount += 3;
						}

						previousInt = (uint)(previousInt + (unpackedInt * 4) + (_version < 9 ? 4 : 0));
						list.Add(DeserializeOffset(previousInt));
					}
				}
			}
		}

		public ulong DeserializeOffset(ulong offset)
		{
			if(_version <= 0x06) return (_loadedPointers[(offset >> 0x18)] + (offset & 0x00FFFFFF));
			                     return (_loadedPointers[(offset >> 0x1B)] + (offset & 0x07FFFFFF));
		}

		public ulong ReadRawOffset()
		{
			if(igCore.IsPlatform64Bit(_platform)) return _stream.ReadUInt64();
			                                      return _stream.ReadUInt32();
		}

		public void InstantiateAndAppendObjects()
		{
			for(int i = 0; i < _runtimeVtableList.Count; i++)
			{
				_offsetObjectList.Add(_runtimeVtableList[i], InstantiateObject(_runtimeVtableList[i]));
			}
		}
		public void ProcessObjectList(igObjectDirectory objDir)
		{
			for(int i = 0; i < _runtimeObjectListList.Count; i++)
			{
				igObjectList objList = (igObjectList)_offsetObjectList[_runtimeObjectListList[i]];
				_stream.Seek(_runtimeObjectListList[i]);
				objList.ReadFields(this);
				for(int j = 0; j < objList._count; j++)
				{
					objDir._objectList.Append(objList[j]);
				}
			}
		}
		public igObject InstantiateObject(ulong offset)
		{
			_stream.Seek(offset);
			string vtableName = _vtableList[(int)ReadRawOffset()];
			if(igCore.RegisteredTypes.ContainsKey(vtableName))
			{
				return (igObject)Activator.CreateInstance(igCore.RegisteredTypes[vtableName]);
			}
			else
			{
				return new igObject();
			}
		}
	}
}