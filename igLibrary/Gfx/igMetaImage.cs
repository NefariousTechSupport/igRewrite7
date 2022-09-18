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