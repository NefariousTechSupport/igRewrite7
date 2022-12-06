namespace igLibrary.Core
{
	[System.AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
	public class igMetaEnumMember : System.Attribute
	{
		public uint _version;
		public uint _value;
		public string _name;

		public igMetaEnumMember(uint applicableVersion, uint value, string name)
		{
			_version = applicableVersion;
			_value = value;
			_name = name;
		}

		public static TEnum GetEnumFromValue<TEnum>(long value, uint version) where TEnum : struct, Enum
		{
			FieldInfo[] members = typeof(TEnum).GetFields();
			TEnum[] enumValues = Enum.GetValues<TEnum>();

			for(uint i = 1; i < members.Length; i++)	//There's a hidden field for some reason, so we start at 1
			{
				igMetaEnumMember[] values = members[i].GetCustomAttributes<igMetaEnumMember>().ToArray();
				for(uint j = 0; j < values.Length; j++)
				{
					if(values[j]._version != version && values[j]._version != 0xFF) continue;

					if(values[j]._value == value) return enumValues[i-1];
				}
			}

			return enumValues[0];
		}
		public static long GetValueFromEnum<TEnum>(TEnum member, uint version) where TEnum : struct, Enum
		{
			FieldInfo[] members = typeof(TEnum).GetFields();
			TEnum[] enumValues = Enum.GetValues<TEnum>();

			for(uint i = 1; i < members.Length; i++)	//There's a hidden field for some reason, so we start at 1
			{
				if(!enumValues[i-1].Equals(member)) continue;

				igMetaEnumMember[] values = members[i].GetCustomAttributes<igMetaEnumMember>().ToArray();

				for(uint j = 0; j < values.Length; j++)
				{
					if(values[j]._version != version && values[j]._version != 0xFF) continue;

					return values[j]._value;
				}
			}

			return 0;
		}
	}
}