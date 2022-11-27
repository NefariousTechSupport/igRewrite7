namespace igLibrary
{
	internal static class Utils
	{
		public static ulong Align(ulong offset, ulong alignment) => ((offset + alignment - 1) / alignment) * alignment;
		public static FieldInfo[] GetAllInstanceFields(Type t)
		{
			if(t == typeof(igObject)) return new FieldInfo[0];

			List<FieldInfo> fields = new List<FieldInfo>();
			fields.AddRange(GetAllInstanceFields(t.BaseType));
			fields.AddRange(t.GetFields(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance));
			return fields.ToArray();
		}
	}
}