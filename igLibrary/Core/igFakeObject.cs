namespace igLibrary.Core
{
	[sizeofSize(0xFF, 0x00, 0x00)]
	public class igFakeObject : igObject
	{
		public string _typeName;
		public ushort _sizeofSize;
		public igRuntimeFields _runtimeFields = new igRuntimeFields();
		public igObjectDirectory _dir;
		private ulong _offset;
		public byte[] _data;
		private ulong _fakeSize;
		public List<string> _strings = new List<string>();
		public List<igObject> _objects = new List<igObject>();
		public List<igHandle> _handles = new List<igHandle>();
		public List<igMemory> _memoryHandles = new List<igMemory>();

		public override void ReadFields(igIGZ igz)
		{
			_offset = (ulong)igz._stream.BaseStream.Position;
			int index = (int)igz.ReadRawOffset();
			_dir = igz._dir;
			_sizeofSize = igz._metaSizes[index];
			_typeName = igz._vtableNameList[index];

			if(igz._offsetObjectList.Last().Key == _offset)
			{
				_fakeSize = (ulong)igz._stream.BaseStream.Length - _offset;
			}
			else
			{
				KeyValuePair<ulong, igObject> nextObject = igz._offsetObjectList.First(x => x.Key > _offset);
				_fakeSize = nextObject.Key - _offset;
			}
			_data = igz._stream.ReadBytes((uint)_fakeSize);

			bool is64Bit = igCore.IsPlatform64Bit(igz._platform);

			//For strings we're saving the runtimes to the same list to save time
			igStringMetaField strMf = new igStringMetaField();
			AddRuntime(igz._runtimeFields._stringRefs, _runtimeFields._stringRefs);
			AddRuntime(igz._runtimeFields._stringTables, _runtimeFields._stringRefs);
			for(int i = 0; i < _runtimeFields._stringRefs.Count; i++)
			{
				igz._stream.Seek(_runtimeFields._stringRefs[i] + _offset);
				string referencedString = (string)strMf.ReadRawMemory(igz, is64Bit);
				int stringIndex = _strings.FindIndex(x => x == referencedString);
				if(stringIndex < 0)
				{
					stringIndex = _strings.Count;
					_strings.Add(referencedString);
				}
			}
			AddRuntime(igz._runtimeFields._offsets, _runtimeFields._offsets);
			AddRuntime(igz._runtimeFields._PIDs, _runtimeFields._PIDs);
			AddRuntime(igz._runtimeFields._handles, _runtimeFields._handles);
			AddRuntime(igz._runtimeFields._namedExternals, _runtimeFields._namedExternals);
			AddRuntime(igz._runtimeFields._externals, _runtimeFields._externals);
			AddRuntime(igz._runtimeFields._memoryHandles, _runtimeFields._memoryHandles);
		}

		public override igObject[] GetReferencedObjects()
		{
			List<igObject> objects = new List<igObject>();

			KeyValuePair<ulong, igObject>[] offsetObjectList = _dir._loader._offsetObjectList.ToArray();
			for(int i = 0; i < _runtimeFields._offsets.Count; i++)
			{
				_dir._loader._stream.Seek(_offset + _runtimeFields._offsets[i]);
				ulong runtimeOffset = _dir._loader.ReadRawOffset();
				int index = Array.FindIndex<KeyValuePair<ulong, igObject>>(offsetObjectList, x => x.Key == runtimeOffset);
				if(index >= 0) objects.Add(offsetObjectList[index].Value);
			}
			return objects.ToArray();
		}
		public override ushort GetSizeofSize(uint version, IG_CORE_PLATFORM platform)
		{
			return _sizeofSize;
		}
		private void AddRuntime(List<ulong> source, List<ulong> dest)
		{
			ulong[] temp = source.Where(x => x >= _offset && x < _offset + _fakeSize).ToArray();
			for(uint i = 0 ; i < temp.Length; i++)
			{
				dest.Add(temp[i] - _offset);
			}
		}
	}
}