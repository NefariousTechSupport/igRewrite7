namespace igLibrary.Core
{
	[AttributeUsage(AttributeTargets.Struct, AllowMultiple = true)]
	sealed class igStruct : Attribute
	{
		public uint _applicableVersion;
		public uint _size32;
		public uint _size64;
		
		// This is a positional argument
		public igStruct(uint applicableVersion, uint size32, uint size64)
		{
			this._size32 = size32;
			this._size64 = size64;
			this._applicableVersion = applicableVersion;
		}
	}
}