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

		public virtual ushort Size(bool is64Bit) => 0;
		public virtual Type OutputType() => null;
		public virtual object? ReadRawMemory(igIGZ igz, bool is64Bit) => null;
		public virtual void WriteRawMemory(igIGZSaver igz, StreamHelper sh, bool is64Bit, object? data){}
		public virtual void SetExtraData(object[]? extraData){}
	}
}