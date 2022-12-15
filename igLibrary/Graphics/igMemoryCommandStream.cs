namespace igLibrary.Graphics
{
	[sizeofSize(0xFF, 0x20, 0x58)]
	public class igMemoryCommandStream : igCommandStream
	{
		[igField(typeof(igMemoryRefMetaField), 0x09, 0x00, 0x20, 0x40, "_memory")]
		public igMemory _memory;
		[igField(typeof(igUnsignedIntMetaField), 0x09, 0x01, 0x24, 0x50, "_bytesWritten")]
		public uint _bytesWritten;

		public igIGZ _igz;

		public override void ReadFields(igIGZ igz)
		{
			base.ReadFields(igz);

			_readHead = _memory.offset;
			_readChunkBegin = _memory.offset;
			_readChunkEnd = _memory.offset + _memory.size;
		}
	}
}