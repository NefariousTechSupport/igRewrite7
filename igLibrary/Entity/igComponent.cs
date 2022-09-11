namespace igLibrary.Entity
{
	//technically inherits from DotNet.Object but i can't really use that name
	public class igComponent : igDynamicObject
	{
		[igField(typeof(igObjectRefMetaField<igComponentData>), 0x09, 0x00, 0x0C, 0x18, "_data")]
		public igComponentData _data;
		[igField(typeof(igObjectRefMetaField<igEntity>), 0x09, 0x01, 0x10, 0x20, "_entity")]
		public igEntity _entity;
		[igField(typeof(igUnsignedIntMetaField), 0x09, 0x02, 0x14, 0x28, "_bitfield")]
		public uint _bitfield;

		[igField(typeof(igBitFieldMetaField<bool>), 0x09, 0x03, 0x14, 0x28, "_isStarted", new object[]{00, 01})]
		public bool _isStarted;
		[igField(typeof(igBitFieldMetaField<bool>), 0x09, 0x04, 0x14, 0x28, "_hasEverStarted", new object[]{01, 01})]
		public bool _hasEverStarted;
		[igField(typeof(igBitFieldMetaField<bool>), 0x09, 0x05, 0x14, 0x28, "_isThreadSafe", new object[]{02, 01})]
		public bool _isThreadSafe;
		[igField(typeof(igBitFieldMetaField<bool>), 0x09, 0x06, 0x14, 0x28, "_isCrashed", new object[]{03, 01})]
		public bool _isCrashed;
		[igField(typeof(igBitFieldMetaField<bool>), 0x09, 0x07, 0x14, 0x28, "_isPendingRemove", new object[]{04, 01})]
		public bool _isPendingRemove;
		[igField(typeof(igBitFieldMetaField<bool>), 0x09, 0x08, 0x14, 0x28, "_hasReceivedCreateMessage", new object[]{05, 01})]
		public bool _hasReceivedCreateMessage;
		[igField(typeof(igBitFieldMetaField<bool>), 0x09, 0x09, 0x14, 0x28, "_enabled", new object[]{06, 01})]
		public bool _enabled;
		[igField(typeof(igBitFieldMetaField<int>),  0x09, 0x0A, 0x14, 0x28, "_enableCount", new object[]{07, 08})]
		public int _enableCount;
		[igField(typeof(igBitFieldMetaField<bool>), 0x09, 0x0B, 0x14, 0x28, "_enabledByVisualScript", new object[]{15, 01})]
		public bool _enabledByVisualScript;
		[igField(typeof(igBitFieldMetaField<int>),  0x09, 0x0C, 0x14, 0x28, "_userFlags", new object[]{16, 16})]
		public int _userFlags;

	}
}