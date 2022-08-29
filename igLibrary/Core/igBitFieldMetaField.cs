namespace igLibrary.Core
{
	public class igBitFieldMetaField<T> : igMetaField where T : struct
	{
		public ushort _shift;
		public ushort _bits;

		public override Type OutputType() => typeof(T);
		public override ushort Size(bool is64Bit) => (ushort)Marshal.SizeOf<T>();

		public override object ReadRawMemory(igIGZ igz, bool is64Bit)
		{
			igz._stream.bitPosition = 0;
			for(int i = 0; i < _shift; i++)
			{
				igz._stream.ReadBit();
			}

			ulong raw = igz._stream.ReadUIntN((byte)_bits);

			Type t = typeof(T);

			if(typeof(T).IsEnum) t = typeof(T).GetEnumUnderlyingType(); 

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

			if(typeof(T).IsEnum) ret = (T)ret;
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