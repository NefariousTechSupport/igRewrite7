using System.Numerics;

namespace igLibrary.Math
{
	public class igVec3fMetaField : igMetaField
	{
		public override object ReadRawMemory(igIGZ igz, bool is64Bit)
		{
			Vector3 vec3;
			vec3.X = igz._stream.ReadSingle();
			vec3.Y = igz._stream.ReadSingle();
			vec3.Z = igz._stream.ReadSingle();
			return vec3;
		}
	}
}