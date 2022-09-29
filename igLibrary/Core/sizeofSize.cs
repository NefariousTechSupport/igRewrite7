namespace igLibrary.Core
{
	[AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = false)]
	sealed class sizeofSize : Attribute
	{
		public uint _applicableVersion;
		public uint _size32;
		public uint _size64;
		public IG_CORE_PLATFORM[] _platform;
		
		// This is a positional argument
		public sizeofSize(uint applicableVersion, uint size32, uint size64, params IG_CORE_PLATFORM[] platform)
		{
			this._size32 = size32;
			this._size64 = size64;
			this._applicableVersion = applicableVersion;
			this._platform = platform;
		}
	}
}