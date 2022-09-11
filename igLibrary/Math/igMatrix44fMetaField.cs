using System.Numerics;

namespace igLibrary.Math
{
	public class igMatrix44fMetaField : igMetaField
	{
		public override object ReadRawMemory(igIGZ igz, bool is64Bit)
		{
			Matrix4x4 mat4;
			mat4.M11 = igz._stream.ReadSingle();
			mat4.M12 = igz._stream.ReadSingle();
			mat4.M13 = igz._stream.ReadSingle();
			mat4.M14 = igz._stream.ReadSingle();
			mat4.M21 = igz._stream.ReadSingle();
			mat4.M22 = igz._stream.ReadSingle();
			mat4.M23 = igz._stream.ReadSingle();
			mat4.M24 = igz._stream.ReadSingle();
			mat4.M31 = igz._stream.ReadSingle();
			mat4.M32 = igz._stream.ReadSingle();
			mat4.M33 = igz._stream.ReadSingle();
			mat4.M34 = igz._stream.ReadSingle();
			mat4.M41 = igz._stream.ReadSingle();
			mat4.M42 = igz._stream.ReadSingle();
			mat4.M43 = igz._stream.ReadSingle();
			mat4.M44 = igz._stream.ReadSingle();
			return mat4;
		}
	}
}