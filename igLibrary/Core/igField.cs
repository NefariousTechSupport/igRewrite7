namespace igLibrary.Core
{
	[AttributeUsage(AttributeTargets.Field, Inherited = true, AllowMultiple = true)]
	public class igField : Attribute
	{
		public igMetaField _metaField;

		public igField(Type t, uint version, ushort ordinal, ushort offset32, ushort offset64, string name, object[]? extraData = null, params IG_CORE_PLATFORM[] overrides)
		{
			_metaField = (igMetaField)Activator.CreateInstance(t);
			_metaField._version = version;
			_metaField._ordinal = ordinal;
			_metaField._offset32 = offset32;
			_metaField._offset64 = offset64;
			_metaField._name = name;
			_metaField._overrides = overrides;
			_metaField.SetExtraData(extraData);
		}

		public virtual object? ReadIGZMemory(igIGZ igz, bool is64Bit)
		{
			return _metaField.ReadRawMemory(igz, is64Bit);
		}

		public static IEnumerable<igField> GetFieldBcyName<T>(string name)
		{
			FieldInfo[] fields = typeof(T).GetFields();
			for(int i = 0; i < fields.Length; i++)
			{
				IEnumerable<igField> igfields = fields[i].GetCustomAttributes<igField>();
				if(igfields.Any(x => x._metaField._name == name)) return igfields.Where(x => x._metaField._name == name);
			}
			return null;
		}
		public static void ApplyChangeToFields<T>(Func<igField, bool> checker, Action<igField> action)
		{
			FieldInfo[] fields = typeof(T).GetFields();
			for(int i = 0; i < fields.Length; i++)
			{
				IEnumerable<igField> igfields = fields[i].GetCustomAttributes<igField>();
				igfields = igfields.Where(checker);
				foreach(igField igfield in igfields)
				{
					action.Invoke(igfield);
				}
			}
		}
	}
}