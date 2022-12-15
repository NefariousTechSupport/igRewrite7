namespace igLibrary.Core
{
	public abstract class igMetaField : igObject
	{
		public uint _version;
		public ushort _offset32;
		public ushort _offset64;
		public string _name;
		public ushort _ordinal;
		public IG_CORE_PLATFORM[] _overrides;

		public static T CreateMetaField<T>(uint version, ushort ordinal, ushort offset32, ushort offset64, string name, IG_CORE_PLATFORM[] overrides) where T : igMetaField, new()
		{
			T field = new T();
			field._version = version;
			field._ordinal = ordinal;
			field._offset32 = offset32;
			field._offset64 = offset64;
			field._name = name;
			field._overrides = overrides;
			return field;
		}

		public virtual ushort Size(bool is64Bit) => 0;
		public virtual Type OutputType() => null;
		public virtual object? ReadRawMemory(igIGZ igz, bool is64Bit) => null;
		public virtual void WriteRawMemory(igIGZSaver igz, igIGZSaver.igIGZSaverSection section, bool is64Bit, object? data){}
		public virtual void SetExtraData(object[]? extraData){}
	}
}