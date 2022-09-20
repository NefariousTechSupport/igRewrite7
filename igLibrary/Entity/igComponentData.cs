namespace igLibrary.Entity
{
	//technically inherits from DotNet.Object but i can't really use that name
	public class igComponentData : igDynamicObject
	{
		[igField(typeof(igUnsignedIntMetaField), 0x09, 0x00, 0x0C, 0x18, "_bitfield")]
		public uint _bitfield;
		[igField(typeof(igBitFieldMetaField<bool, igUnsignedIntMetaField>), 0x09, 0x01, 0x0C, 0x18, "_isEnabled", new object[]{00, 1})]
		public bool _isEnabled;
		[igField(typeof(igBitFieldMetaField<bool, igUnsignedIntMetaField>), 0x09, 0x01, 0x0C, 0x18, "_isThreadSafe", new object[]{01, 1})]
		public bool _isThreadSafe;

	}
}
