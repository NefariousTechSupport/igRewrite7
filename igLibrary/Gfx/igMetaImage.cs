namespace igLibrary.Gfx
{
	public class igMetaImage : igObject
	{
		public igMetaImage _canonical;
		public bool _isTile;
		public bool _isCanonical;
		public bool _isCompressed;
		public bool _hasPalette;
		public bool _isSrgb;
		public bool _isFloatingPoint;
		public string _name;
		public byte _bitsPerPixel;
		public List<igMetaImage> _formats = new List<igMetaImage>();
		public List<Func<igMemory, ushort, ushort, ushort, byte[]>> _functions = new List<Func<igMemory, ushort, ushort, ushort, byte[]>>();

		public enum SimpleMetaImageFormat
		{
			DXT1,
			DXT1_SWIZZLE_WII,
			DXT1_SWIZZLE_WIIU,
			DXT3,
			DXT3_SWIZZLE_WIIU,
			DXT5,
			DXT5_SWIZZLE_WIIU,
			PVRTC2,
			PVRTC4,
		}

		public SimpleMetaImageFormat GetSimpleMetaImageFormat()
		{
			if(_name.StartsWith("dxt1"))
			{
				if(_name.EndsWith("_big_wii"))   return SimpleMetaImageFormat.DXT1_SWIZZLE_WII;
				else if(_name.EndsWith("_cafe")) return SimpleMetaImageFormat.DXT1_SWIZZLE_WIIU;
				else                             return SimpleMetaImageFormat.DXT1;
			}
			else if(_name.StartsWith("dxt3"))
			{
				if(_name.EndsWith("_cafe"))      return SimpleMetaImageFormat.DXT3_SWIZZLE_WIIU;
				else                             return SimpleMetaImageFormat.DXT3;
			}
			else if(_name.StartsWith("dxt5"))
			{
				if(_name.EndsWith("_cafe"))      return SimpleMetaImageFormat.DXT5_SWIZZLE_WIIU;
				else                             return SimpleMetaImageFormat.DXT5;				
			}
			else if(_name.StartsWith("pvrtc2"))  return SimpleMetaImageFormat.PVRTC2;
			else if(_name.StartsWith("pvrtc4"))  return SimpleMetaImageFormat.PVRTC4;
			else throw new NotImplementedException();
		}

		public static byte[] igImage2Conversion_pvrtc2_generic(igMemory memory, ushort width, ushort height, ushort levelCount)
		{
			Pvrtc.PvrtcDecoder dec = new Pvrtc.PvrtcDecoder();
			return dec.DecompressPVRTC(memory.buffer, width, height, true);
		}
		public static byte[] igImage2Conversion_dxt1_generic(igMemory memory, ushort width, ushort height, ushort levelCount)
		{
			byte[] buffer = new byte[4 * width * height];
			Dxt.DxtDecoder.DecompressDXT1(memory.buffer, width, height, buffer);
			for(int i = 0; i < buffer.Length >> 2; i++)
			{
				Array.Reverse(buffer, i << 2, 3);
			}
			return buffer;
		}
		public static byte[] igImage2Conversion_dxt3_generic(igMemory memory, ushort width, ushort height, ushort levelCount)
		{
			byte[] buffer = new byte[4 * width * height];
			Dxt.DxtDecoder.DecompressDXT3(memory.buffer, width, height, buffer);
			for(int i = 0; i < buffer.Length >> 2; i++)
			{
				Array.Reverse(buffer, i << 2, 3);
			}
			return buffer;
		}
		public static byte[] igImage2Conversion_dxt5_generic(igMemory memory, ushort width, ushort height, ushort levelCount)
		{
			byte[] buffer = new byte[4 * width * height];
			Dxt.DxtDecoder.DecompressDXT5(memory.buffer, width, height, buffer);
			for(int i = 0; i < buffer.Length >> 2; i++)
			{
				Array.Reverse(buffer, i << 2, 3);
			}
			return buffer;
		}
	}
}