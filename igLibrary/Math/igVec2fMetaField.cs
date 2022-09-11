using System.Numerics;

namespace igLibrary.Math
{
	public class igVec2fMetaField : igMetaField
	{
		public override object ReadRawMemory(igIGZ igz, bool is64Bit)
		{
			Vector2 vec2;
			vec2.X = igz._stream.ReadSingle();
			vec2.Y = igz._stream.ReadSingle();
			return vec2;
		}
	}
}