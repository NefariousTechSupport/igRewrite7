namespace igLibrary.Graphics
{
	public class igGraphicsMaterial : igMaterial
	{
		[igField(typeof(igUnsignedLongMetaField), 0x09, 0x00, 0x0C, 0x18, "_globalTechniqueMask")]
		public ulong _globalTechniqueMask;
		[igField(typeof(igUnsignedIntMetaField), 0x09, 0x01, 0x14, 0x20, "_materialBitField")]
		public uint _materialBitField;
		[igField(typeof(igFloatMetaField), 0x09, 0x02, 0x18, 0x24, "_sortDepthOffset")]
		public float _sortDepthOffset;
		[igField(typeof(igHandleMetaField<igObject>), 0x09, 0x03, 0x1C, 0x28, "_effectHandle")]		//igGraphicsEffect
		public igHandle _effectHandle;
		[igField(typeof(igObjectRefMetaField<igObject>), 0x09, 0x04, 0x20, 0x30, "_commonState")]	//igMemoryCommandStream
		public igObject _commonState;
		[igField(typeof(igVectorMetaField<igObject, igObjectRefMetaField<igObject>>), 0x09, 0x05, 0x24, 0x38, "_techniques")]		//igMemoryCommandStream
		public List<igObject> _techniques;
		[igField(typeof(igObjectRefMetaField<igObject>), 0x09, 0x06, 0x30, 0x50, "_animations")]	//igGraphicsMaterialAnimationList
		public igObject _animations;
		[igField(typeof(igObjectRefMetaField<igGraphicsObjectSet>), 0x09, 0x07, 0x34, 0x58, "_graphicsObjects")]
		public igGraphicsObjectSet _graphicsObjects;
		[igField(typeof(igBitFieldMetaField<byte>), 0x09, 0x08, 0x14, 0x20, "_sortKey", new object[2]{0, 4})]
		public byte _sortKey;
		[igField(typeof(igBitFieldMetaField<igDrawType>), 0x09, 0x09, 0x14, 0x20, "_drawType", new object[2]{4, 2})]
		public igDrawType _drawType;
		[igField(typeof(igBitFieldMetaField<igGraphicsMaterialAnimationTimeSource>), 0x09, 0x0A, 0x14, 0x20, "_timeSource", new object[2]{6, 2})]
		public igGraphicsMaterialAnimationTimeSource _timeSource;
	}
}