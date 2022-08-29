namespace igLibrary.Core
{
	class igEnumMetaField<T> : igMetaField where T : Enum
	{
		public override ushort Size(bool is64Bit) => (ushort)Marshal.SizeOf(typeof(T).GetEnumUnderlyingType());
		public override Type OutputType() => typeof(T);

		public override object? ReadRawMemory(igIGZ igz, bool is64Bit)
		{
			     if(typeof(T).GetEnumUnderlyingType() == typeof(uint))   return igz._stream.ReadUInt32();
			else if(typeof(T).GetEnumUnderlyingType() == typeof(int))    return igz._stream.ReadInt32();
			else if(typeof(T).GetEnumUnderlyingType() == typeof(ushort)) return igz._stream.ReadUInt16();
			else if(typeof(T).GetEnumUnderlyingType() == typeof(short))  return igz._stream.ReadInt16();
			else if(typeof(T).GetEnumUnderlyingType() == typeof(ulong))  return igz._stream.ReadUInt64();
			else if(typeof(T).GetEnumUnderlyingType() == typeof(long))   return igz._stream.ReadInt64();
			else if(typeof(T).GetEnumUnderlyingType() == typeof(byte))   return igz._stream.ReadByte();
			else throw new NotImplementedException($"{typeof(T).GetEnumUnderlyingType()} is not a supported underlying type for enums");
		}
	}
}