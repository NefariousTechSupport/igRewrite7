namespace igLibrary
{
	internal static class Utils
	{
		public static ulong Align(ulong offset, ulong alignment) => ((offset + alignment - 1) / alignment) * alignment;
	}
}