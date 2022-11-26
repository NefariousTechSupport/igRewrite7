namespace igLibrary.Gfx
{
	public class igVertexConversion : igObject
	{
		[igField(typeof(igBoolMetaField), 0xFF, 0x00, 0x08, 0x0C, "_expose")]
		public bool _expose;

		public static Vector4 unpack_FLOAT1(StreamHelper sh) =>                 new Vector4(sh.ReadSingle(), 0, 0, 1);
		public static Vector4 unpack_FLOAT2(StreamHelper sh) =>                 new Vector4(sh.ReadSingle(), sh.ReadSingle(), 0, 1);
		public static Vector4 unpack_FLOAT3(StreamHelper sh) =>                 new Vector4(sh.ReadSingle(), sh.ReadSingle(), sh.ReadSingle(), 1);
		public static Vector4 unpack_FLOAT4(StreamHelper sh) =>                 new Vector4(sh.ReadSingle(), sh.ReadSingle(), sh.ReadSingle(), sh.ReadSingle());
		public static Vector4 unpack_UBYTE4N_COLOR(StreamHelper sh) =>          new Vector4(sh.ReadByte() / 255f, sh.ReadByte() / 255f, sh.ReadByte() / 255f, sh.ReadByte() / 255f);
		public static Vector4 unpack_UBYTE4N_COLOR_ARGB(StreamHelper sh) =>     new Vector4(sh.ReadByte() / 255f, sh.ReadByte() / 255f, sh.ReadByte() / 255f, sh.ReadByte() / 255f);
		public static Vector4 unpack_UBYTE4N_COLOR_RGBA(StreamHelper sh) =>     new Vector4(sh.ReadByte() / 255f, sh.ReadByte() / 255f, sh.ReadByte() / 255f, sh.ReadByte() / 255f);
		public static Vector4 unpack_UBYTE2N_COLOR_5650(StreamHelper sh)
		{
			ushort color = sh.ReadUInt16();
			return new Vector4((color & 31) / 31f, ((color >> 5) & 63) / 63f, (color >> 11) / 31f, 1);
		}
		public static Vector4 unpack_UBYTE2N_COLOR_5551(StreamHelper sh)
		{
			ushort color = sh.ReadUInt16();
			return new Vector4((color & 31) / 31f, ((color >> 5) & 31) / 31f, ((color >> 10) & 31) / 31f, color >> 15);
		}
		public static Vector4 unpack_UBYTE2N_COLOR_4444(StreamHelper sh)
		{
			ushort color = sh.ReadUInt16();
			return new Vector4((color & 15) / 15f, ((color >> 4) & 15) / 15f, ((color >> 8) & 15) / 15f, ((color >> 12) & 15) / 15f);
		}
		public static Vector4 unpack_INT1(StreamHelper sh) =>                   new Vector4(sh.ReadInt32(), 0, 0, 1);
		public static Vector4 unpack_INT2(StreamHelper sh) =>                   new Vector4(sh.ReadInt32(), sh.ReadInt32(), 0, 1);
		public static Vector4 unpack_INT4(StreamHelper sh) =>                   new Vector4(sh.ReadInt32(), sh.ReadInt32(), sh.ReadInt32(), sh.ReadInt32());
		public static Vector4 unpack_UINT1(StreamHelper sh) =>                  new Vector4(sh.ReadUInt32(), 0, 0, 1);
		public static Vector4 unpack_UINT2(StreamHelper sh) =>                  new Vector4(sh.ReadUInt32(), sh.ReadUInt32(), 0, 1);
		public static Vector4 unpack_UINT4(StreamHelper sh) =>                  new Vector4(sh.ReadUInt32(), sh.ReadUInt32(), sh.ReadUInt32(), sh.ReadUInt32());
		public static Vector4 unpack_INT1N(StreamHelper sh) =>                  new Vector4(sh.ReadInt32() / 2147483647f, 0, 0, 1);
		public static Vector4 unpack_INT2N(StreamHelper sh) =>                  new Vector4(sh.ReadInt32() / 2147483647f, sh.ReadInt32() / 2147483647f, 0, 1);
		public static Vector4 unpack_INT4N(StreamHelper sh) =>                  new Vector4(sh.ReadInt32() / 2147483647f, sh.ReadInt32() / 2147483647f, sh.ReadInt32() / 2147483647f, sh.ReadInt32() / 2147483647f);
		public static Vector4 unpack_UINT1N(StreamHelper sh) =>                 new Vector4(sh.ReadUInt32() / 4294967295f, 0, 0, 1);
		public static Vector4 unpack_UINT2N(StreamHelper sh) =>                 new Vector4(sh.ReadUInt32() / 4294967295f, sh.ReadUInt32() / 4294967295f, 0, 1);
		public static Vector4 unpack_UINT4N(StreamHelper sh) =>                 new Vector4(sh.ReadUInt32() / 4294967295f, sh.ReadUInt32() / 4294967295f, sh.ReadUInt32() / 4294967295f, sh.ReadUInt32() / 4294967295f);
		public static Vector4 unpack_UBYTE4(StreamHelper sh)
		{
			uint bytes = sh.ReadUInt32();
			return new Vector4(bytes & 0xFF, (bytes >> 8) & 0xFF, (bytes >> 16) & 0xFF, (bytes >> 24) & 0xFF);
		}
		//public static Vector4 unpack_UBYTE4_X4(StreamHelper sh) =>              new Vector4(sh.ReadSingle(), 0, 0, 1);
		public static Vector4 unpack_BYTE4(StreamHelper sh)
		{
			uint bytes = sh.ReadUInt32();
			Vector4 ret;
			ret.X = unchecked((sbyte)(byte)(bytes & 0x7F));
			ret.Y = unchecked((sbyte)(byte)((bytes >> 8) & 0x7F));
			ret.Z = unchecked((sbyte)(byte)((bytes >> 16) & 0x7F));
			ret.W = unchecked((sbyte)(byte)((bytes >> 24) & 0x7F));
			return ret;
		}
		public static Vector4 unpack_UBYTE4N(StreamHelper sh)
		{
			Vector4 ret = unpack_UBYTE4(sh);
			ret.X /= 0xFF;
			ret.Y /= 0xFF;
			ret.Z /= 0xFF;
			ret.W /= 0xFF;
			return ret;
		}
		public static Vector4 unpack_BYTE4N(StreamHelper sh)
		{
			Vector4 ret = unpack_BYTE4(sh);
			ret.X /= 0x7F;
			ret.Y /= 0x7F;
			ret.Z /= 0x7F;
			ret.W /= 0x7F;
			return ret;
		}
		public static Vector4 unpack_SHORT2(StreamHelper sh) =>                 new Vector4(sh.ReadInt16(), sh.ReadInt16(), 0, 1);
		public static Vector4 unpack_SHORT4(StreamHelper sh) =>                 new Vector4(sh.ReadInt16(), sh.ReadInt16(), sh.ReadInt16(), sh.ReadInt16());
		public static Vector4 unpack_USHORT2(StreamHelper sh) =>                new Vector4(sh.ReadUInt16(), sh.ReadUInt16(), 0, 1);
		public static Vector4 unpack_USHORT4(StreamHelper sh) =>                new Vector4(sh.ReadUInt16(), sh.ReadUInt16(), sh.ReadUInt16(), sh.ReadUInt16());
		public static Vector4 unpack_SHORT2N(StreamHelper sh) =>                new Vector4(sh.ReadInt16() / 32767f, sh.ReadInt16() / 32767f, 0, 1);
		public static Vector4 unpack_SHORT3N(StreamHelper sh) =>                new Vector4(sh.ReadInt16() / 32767f, sh.ReadInt16() / 32767f, sh.ReadInt16() / 32767f, 1);
		public static Vector4 unpack_SHORT4N(StreamHelper sh) =>                new Vector4(sh.ReadInt16() / 32767f, sh.ReadInt16() / 32767f, sh.ReadInt16() / 32767f, sh.ReadInt16() / 32767f);
		public static Vector4 unpack_USHORT2N(StreamHelper sh) =>               new Vector4(sh.ReadUInt16() / 65535f, sh.ReadUInt16() / 65535f, 0, 1);
		public static Vector4 unpack_USHORT3N(StreamHelper sh) =>               new Vector4(sh.ReadUInt16() / 65535f, sh.ReadUInt16() / 65535f, sh.ReadUInt16() / 65535f, 1);
		public static Vector4 unpack_USHORT4N(StreamHelper sh) =>               new Vector4(sh.ReadUInt16() / 65535f, sh.ReadUInt16() / 65535f, sh.ReadUInt16() / 65535f, sh.ReadUInt16() / 65535f);
		//public static Vector4 unpack_UDEC3(StreamHelper sh) =>                  new Vector4(sh.ReadSingle(), 0, 0, 1);
		//public static Vector4 unpack_DEC3N(StreamHelper sh) =>                  new Vector4(sh.ReadSingle(), 0, 0, 1);
		//public static Vector4 unpack_DEC3N_S11_11_10(StreamHelper sh) =>        new Vector4(sh.ReadSingle(), 0, 0, 1);
		public static Vector4 unpack_HALF2(StreamHelper sh) =>                  new Vector4((float)sh.ReadHalf(), (float)sh.ReadHalf(), 0, 1);
		public static Vector4 unpack_HALF4(StreamHelper sh) =>                  new Vector4((float)sh.ReadHalf(), (float)sh.ReadHalf(), (float)sh.ReadHalf(), (float)sh.ReadHalf());
		//public static Vector4 unpack_UNUSED(StreamHelper sh) =>                 new Vector4(sh.ReadSingle(), 0, 0, 1);
		/*public static Vector4 unpack_BYTE3N(StreamHelper sh)
		{
			byte b1 = sh.ReadByte();
			byte b2 = sh.ReadByte();
			byte b3 = sh.ReadByte();
			Vector4 ret;
			ret.X = unchecked((sbyte)(byte)(bytes & 0x7F));
			ret.Y = unchecked((sbyte)(byte)((bytes >> 8) & 0x7F));
			ret.Z = unchecked((sbyte)b2 + );
			ret.W = 1.0f;
			return ret;
		}*/
		public static Vector4 unpack_SHORT3(StreamHelper sh) =>                 new Vector4(sh.ReadInt16(), sh.ReadInt16(), sh.ReadInt16(), 1);
		public static Vector4 unpack_USHORT3(StreamHelper sh) =>                new Vector4(sh.ReadUInt16(), sh.ReadUInt16(), sh.ReadUInt16(), 1);
		public static Vector4 unpack_UBYTE4_ENDIAN(StreamHelper sh)
		{
			uint bytes = sh.ReadUInt32();
			return new Vector4((bytes >> 24) & 0xFF, (bytes >> 16) & 0xFF, (bytes >> 8) & 0xFF, bytes & 0xFF);
		}
		//public static Vector4 unpack_UBYTE4_COLOR(StreamHelper sh) =>           new Vector4(sh.ReadSingle(), 0, 0, 1);
		//public static Vector4 unpack_BYTE3(StreamHelper sh) =>                  new Vector4(sh.ReadSingle(), 0, 0, 1);
		public static Vector4 unpack_UBYTE2N_COLOR_5650_RGB(StreamHelper sh)
		{
			ushort color = sh.ReadUInt16();
			return new Vector4((color >> 11) / 31f, ((color >> 5) & 63) / 63f, (color & 31) / 31f, 1);
		}
		//public static Vector4 unpack_UDEC3_OES(StreamHelper sh) =>              new Vector4(sh.ReadSingle(), 0, 0, 1);
		//public static Vector4 unpack_DEC3N_OES(StreamHelper sh) =>              new Vector4(sh.ReadSingle(), 0, 0, 1);
		public static Vector4 unpack_SHORT4N_EDGE(StreamHelper sh) =>           unpack_SHORT4N(sh);
	}
}