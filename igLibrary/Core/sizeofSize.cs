namespace igLibrary.Core
{
	[AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = false)]
	sealed class sizeofSize : Attribute
	{
		public uint _applicableVersion;
		public ushort _size32;
		public ushort _size64;
		public IG_CORE_PLATFORM[] _platform;
		
		// This is a positional argument
		public sizeofSize(uint applicableVersion, ushort size32, ushort size64, params IG_CORE_PLATFORM[] platform)
		{
			this._size32 = size32;
			this._size64 = size64;
			this._applicableVersion = applicableVersion;
			this._platform = platform;
		}
		public static ushort GetSizeOfType(Type t, uint version, IG_CORE_PLATFORM platform)
		{
			sizeofSize[] sizes = t.GetCustomAttributes<sizeofSize>().ToArray();
			for(int i = 0; i < sizes.Length; i++)
			{
				if(sizes[i]._applicableVersion != 0xFF && sizes[i]._applicableVersion != version) continue;
				if(sizes[i]._platform.Length > 0 && !sizes[i]._platform.Any(x => x == platform)) continue;

				return igCore.IsPlatform64Bit(platform) ? sizes[i]._size64 : sizes[i]._size32;
			}
			return 0;

		}
	}
}