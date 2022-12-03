namespace igLibrary.Core
{
	public class igRuntimeFields
	{
		public List<ulong> _stringRefs = new List<ulong>();
		public List<ulong> _stringTables = new List<ulong>();
		public List<ulong> _offsets = new List<ulong>();
		public List<ulong> _vtables = new List<ulong>();
		public List<ulong> _PIDs = new List<ulong>();
		public List<ulong> _handles = new List<ulong>();
		public List<ulong> _namedExternals = new List<ulong>();
		public List<ulong> _externals = new List<ulong>();
		public List<ulong> _memoryHandles = new List<ulong>();
		public List<ulong> _objectLists = new List<ulong>();
	}
}