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

		public override void ReadFields(igIGZ igz)
		{
			_offset = (ulong)igz._stream.BaseStream.Position;
			int index = (int)igz.ReadRawOffset();
			_dir = igz._dir;
			_sizeofSize = igz._metaSizes[index];
			_typeName = igz._vtableNameList[index];

			ulong[] tempOffsetList = igz._runtimeOffsetList.Where(x => x >= _offset && x < _offset + _sizeofSize).ToArray();
			for(uint i = 0 ; i < tempOffsetList.Length; i++)
			{
				_runtimeFields._offsets.Add((ushort)(tempOffsetList[i] - _offset));
			}
			//Add checks for igMemory
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
	}
}