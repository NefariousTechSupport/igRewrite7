namespace igLibrary.Core
{
	public class igFloatArrayMetaField : igFloatMetaField
	{
		public override ushort Size(bool is64Bit)
		{
			return (ushort)(0x04 * _num);
		}

		public int _num;

		public override Type OutputType() => typeof(float[]);
		public override object ReadRawMemory(igIGZ igz, bool is64Bit)
		{
			float[] array = new float[_num];
			for(int i = 0; i < _num; i++)
			{
				array[i] = (float)base.ReadRawMemory(igz, is64Bit);
			}
			return array;
		}
	}
}