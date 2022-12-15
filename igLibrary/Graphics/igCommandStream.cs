namespace igLibrary.Graphics
{
	[sizeofSize(0xFF, 0x20, 0x40)]
	public class igCommandStream : igObject
	{
		[igField(typeof(igRawRefMetaField), 0x09, 0x00, 0x08, 0x10, "_writeHead")]
		public ulong _writeHead;
		[igField(typeof(igRawRefMetaField), 0x09, 0x01, 0x0C, 0x18, "_writeChunkBegin")]
		public ulong _writeChunkBegin;
		[igField(typeof(igRawRefMetaField), 0x09, 0x02, 0x10, 0x20, "_writeChunkEnd")]
		public ulong _writeChunkEnd;
		[igField(typeof(igRawRefMetaField), 0x09, 0x03, 0x14, 0x28, "_readHead")]
		public ulong _readHead;
		[igField(typeof(igRawRefMetaField), 0x09, 0x04, 0x18, 0x30, "_readChunkBegin")]
		public ulong _readChunkBegin;
		[igField(typeof(igRawRefMetaField), 0x09, 0x05, 0x1C, 0x38, "_readChunkEnd")]
		public ulong _readChunkEnd;
	}
}