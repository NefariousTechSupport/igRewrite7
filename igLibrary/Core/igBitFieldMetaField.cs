namespace igLibrary.Core
{
	public class igBitFieldMetaField<T1, T2> : igMetaField where T1 : struct where T2 : igMetaField, new()
	{
		public ushort _shift;
		public ushort _bits;

		public override Type OutputType() => typeof(T1);
		public override ushort Size(bool is64Bit) => (ushort)Marshal.SizeOf<T1>();

		public override object ReadRawMemory(igIGZ igz, bool is64Bit)
		{
			T2 metafield = new T2();
			uint raw = (uint)Convert.ChangeType(metafield.ReadRawMemory(igz, is64Bit), typeof(uint));
			uint shifted = raw >> _shift;
			uint anded = shifted & (0xFFFFFFFF >> (32 - _bits));

			raw = anded;

			Type t = typeof(T1);

			if(typeof(T1).IsEnum) t = typeof(T1).GetEnumUnderlyingType(); 

			object ret;

			     if(t == typeof(uint))   ret = (uint)raw;
			else if(t == typeof(int))    ret = (int)raw;
			else if(t == typeof(ushort)) ret = (ushort)raw;
			else if(t == typeof(short))  ret = (short)raw;
			else if(t == typeof(ulong))  ret = raw;
			else if(t == typeof(long))   ret = (long)raw;
			else if(t == typeof(bool))   ret = raw > 0;
			else if(t == typeof(byte))   ret = (byte)raw;
			else throw new NotImplementedException($"{t.Name} is not a supported type for bitfields");

			if(typeof(T1).IsEnum) ret = (T1)ret;
			return ret;
		}

		public override void SetExtraData(object[]? extraData)
		{
			if(extraData == null) throw new ArgumentException("extraData must be non-null");
			_shift = (ushort)(int)extraData[0];
			_bits = (ushort)(int)extraData[1];
		}
	}
}