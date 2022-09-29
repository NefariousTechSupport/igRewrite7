namespace igLibrary.Gfx
{
	[sizeofSize(0x09, 0x60, 0x90)]
	public class igImage2 : igNamedObject
	{
		[igField(typeof(igUnsignedShortMetaField), 0x09, 0x00, 0x34, 0x48, "_width")]
		public ushort _width;
		[igField(typeof(igUnsignedShortMetaField), 0x09, 0x01, 0x36, 0x4A, "_height")]
		public ushort _height;
		[igField(typeof(igUnsignedShortMetaField), 0x09, 0x02, 0x38, 0x4C, "_depth")]
		public ushort _depth;
		[igField(typeof(igUnsignedShortMetaField), 0x09, 0x03, 0x3A, 0x4E, "_levelCount")]
		public ushort _levelCount;
		[igField(typeof(igUnsignedShortMetaField), 0x09, 0x04, 0x3C, 0x50, "_imageCount")]
		public ushort _imageCount;
		[igField(typeof(igObjectRefMetaField<igMetaImage>), 0x09, 0x05, 0x40, 0x58, "_format")]
		public igMetaImage _format;
		[igField(typeof(igIntMetaField), 0x09, 0x06, 0x44, 0x60, "_usageDeprecated")]
		public int _usageDeprecated;
		[igField(typeof(igUnsignedShortMetaField), 0x09, 0x07, 0x48, 0x64, "_paddingDeprecated")]
		public ushort _paddingDeprecated;
		[igField(typeof(igMemoryRefHandleMetaField), 0x09, 0x08, 0x4C, 0x68, "_data")]
		public igMemory _data;
		[igField(typeof(igIntMetaField), 0x09, 0x09, 0x50, 0x70, "_lockCount")]
		public int _lockCount;
		[igField(typeof(igIntMetaField), 0x09, 0x0A, 0x54, 0x74, "_texHandle")]
		public int _texHandle;
		[igField(typeof(igRawRefMetaField), 0x09, 0x0B, 0x58, 0x78, "_lockedMemory")]
		public ulong _lockedMemory;
		[igField(typeof(igBoolMetaField), 0x09, 0x0C, 0x5C, 0x80, "_oglDiscardOriginalImage")]
		public bool _oglDiscardOriginalImage;
		[igField(typeof(igVec4fMetaField), 0x09, 0x0F, 0x10, 0x20, "_colorScale")]
		public Vector4 _colorScale;
		[igField(typeof(igVec4fMetaField), 0x09, 0x10, 0x20, 0x30, "_colorBias")]
		public Vector4 _colorBias;
		[igField(typeof(igObjectRefMetaField<igObject>), 0x09, 0x11, 0x30, 0x40, "_graphicsHelper")]
		public igObject _graphicsHelper;

		public byte[]? ConvertToRGBA()
		{
			if(_format != null)
			{
				return _format._functions[0].Invoke(_data, _width, _height, _levelCount);
			}
			return null;
		}
	}
}