namespace igLibrary.Core
{
	public class igUnsignedShortArrayMetaField : igMetaField
	{
		public override Type OutputType() => typeof(ushort[]);
		public override ushort Size(bool is64Bit) => (ushort)(2 * count);

		public int count;

		public override object ReadRawMemory(igIGZ igz, bool is64Bit)
		{
			ushort[] ret = new ushort[count];
			for(int i = 0; i < count; i++)
			{
				ret[i] = igz._stream.ReadUInt16();
			}
			return ret;
		}

		public override void SetExtraData(object[]? extraData) => count = (int)extraData[0];
	}
}