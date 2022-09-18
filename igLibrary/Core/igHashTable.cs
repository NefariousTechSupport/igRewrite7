namespace igLibrary.Core
{
	public class igHashTable<T, TM, U, UM> : igContainer
		where TM : igMetaField, new()
		where UM : igMetaField, new()
	{
		[igField(typeof(igMemoryRefMetaField), 0xFF, 0x00, 0x08, 0x10, "_values")]
		public igMemory _values;
		[igField(typeof(igMemoryRefMetaField), 0xFF, 0x01, 0x10, 0x20, "_keys")]
		public igMemory _keys;
		[igField(typeof(igIntMetaField), 0xFF, 0x02, 0x18, 0x30, "_hashItemCount")]
		public int _hashItemCount;
		[igField(typeof(igBoolMetaField), 0xFF, 0x03, 0x1C, 0x34, "_autoRehash")]
		public bool _autoRehash;
		[igField(typeof(igFloatMetaField), 0xFF, 0x04, 0x20, 0x38, "_loadFactor")]
		public float _loadFactor;

		public Dictionary<T, U> internalHashTable = new Dictionary<T, U>();

		public override void ReadFields(igIGZ igz)
		{
			base.ReadFields(igz);
			bool is64Bit = igCore.IsPlatform64Bit(igz._platform);
			internalHashTable.Clear();
			int initialCount = (int)_hashItemCount;
			_hashItemCount = 0;
			TM keyMetaField = new TM();
			int keySize = keyMetaField.Size(is64Bit);

			UM valueMetaField = new UM();
			int valueSize = valueMetaField.Size(is64Bit);

			for(int i = 0; i < initialCount; i++)
			{
				T appenderKey;
				igz._stream.Seek(_keys.offset + (ulong)(keySize * i));
				if((ulong)(keySize * i) >= _keys.size) break;
				appenderKey = (T)keyMetaField.ReadRawMemory(igz, is64Bit);

				if(appenderKey == null) continue;

				U appenderValue;
				igz._stream.Seek(_values.offset + (ulong)(valueSize * i));
				appenderValue = (U)valueMetaField.ReadRawMemory(igz, is64Bit);

				//internalHashTable.Add(appenderKey, appenderValue);
			}
		}
	}
}