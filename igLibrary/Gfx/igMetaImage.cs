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
	}
}