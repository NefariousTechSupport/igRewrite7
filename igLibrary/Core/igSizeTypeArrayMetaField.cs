namespace igLibrary.Core
{
	public class igSizeTypeArrayMetaField : igSizeTypeMetaField
	{
		public override ushort Size(bool is64Bit)
		{
			if(is64Bit) return (ushort)(0x08 * _num);
			return (ushort)(0x04 * _num);
		}

		public int _num;

		public override Type OutputType() => typeof(ulong[]);
		public override object ReadRawMemory(igIGZ igz, bool is64Bit)
		{
			ulong[] array = new ulong[_num];
			for(int i = 0; i < _num; i++)
			{
				array[i] = (ulong)base.ReadRawMemory(igz, is64Bit);
			}
			return array;
		}
	}
}