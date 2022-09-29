namespace igLibrary.Core
{
	[sizeofSize(0xFF, 0x08, 0x10)]
	public struct igName
	{
		public static void arkRegisterCompoundFields(igMetaFieldList metaFields)
		{
			IG_CORE_PLATFORM[] emptyPlatformOverride = new IG_CORE_PLATFORM[0];

			igStringMetaField _string = new igStringMetaField();
			_string._name = "_string";
			_string._offset32 = 0;
			_string._offset64 = 0;
			_string._version = 0xFF;
			_string._ordinal = 0x0;
			_string._overrides = emptyPlatformOverride;
			metaFields.Append(_string);

			igUnsignedIntMetaField _hash = new igUnsignedIntMetaField();
			_hash._name = "_hash";
			_hash._offset32 = 4;
			_hash._offset64 = 8;
			_hash._version = 0xFF;
			_hash._ordinal = 0x1;
			_hash._overrides = emptyPlatformOverride;
			metaFields.Append(_hash);
		}
		public string _string = string.Empty;
		public uint _hash = 0;
		public igName(){}
		public igName(string name)
		{
			SetString(name);
		}
		public void SetString(string newString)
		{
			_string = newString;
			_hash = igHash.Hash(newString.ToLower());
		}
	}
}