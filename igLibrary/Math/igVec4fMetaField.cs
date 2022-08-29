using System.Numerics;

namespace igLibrary.Math
{
	public class igVec4fMetaField : igMetaField
	{
		public override object ReadRawMemory(igIGZ igz, bool is64Bit)
		{
			Vector4 vec4;
			vec4.X = igz._stream.ReadSingle();
			vec4.Y = igz._stream.ReadSingle();
			vec4.Z = igz._stream.ReadSingle();
			vec4.W = igz._stream.ReadSingle();
			return vec4;
		}
	}
}