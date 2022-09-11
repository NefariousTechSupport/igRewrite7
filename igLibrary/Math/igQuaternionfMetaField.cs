using System.Numerics;

namespace igLibrary.Math
{
	public class igQuaternionfMetaField : igMetaField
	{
		public override object ReadRawMemory(igIGZ igz, bool is64Bit)
		{
			Quaternion quat;
			quat.X = igz._stream.ReadSingle();
			quat.Y = igz._stream.ReadSingle();
			quat.Z = igz._stream.ReadSingle();
			quat.W = igz._stream.ReadSingle();
			return quat;
		}
	}
}