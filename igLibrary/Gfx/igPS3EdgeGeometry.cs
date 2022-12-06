namespace igLibrary.Gfx
{
	[sizeofSize(0xFF, 0x20, 0x00)]
	public class igPS3EdgeGeometry : igPS3EdgeGeometrySegmentList
	{
		[igField(typeof(igBoolMetaField), 0xFF, 0x00, 0x18, 0x00, "_isMorphed")]
		public bool _isMorphed;

		[igField(typeof(igBoolMetaField), 0xFF, 0x01, 0x19, 0x00, "_isSkinned")]
		public bool _isSkinned;

		[igField(typeof(igUnsignedIntMetaField), 0xFF, 0x02, 0x1C, 0x00, "_hashCode")]
		public uint _hashCode;

		public override void ReadFields(igIGZ igz)
		{
			base.ReadFields(igz);

			//endianness = igz._stream._endianness;
			//version = igz._version;
		}
	}
}