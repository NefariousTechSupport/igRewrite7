namespace igLibrary.Graphics
{
	[sizeofSize(0xFF, 0x38, 0x60, IG_CORE_PLATFORM.ASPEN, IG_CORE_PLATFORM.ASPEN64)]
	[sizeofSize(0xFF, 0x40, 0x60)]
	public class igGraphicsMaterial : igMaterial
	{
		//On not iOS, a long must be aligned to 8 bytes, on iOS, it must be aligned to 4 bytes, hence this
		[igField(typeof(igUnsignedLongMetaField), 0x09, 0x00, 0x0C, 0x18, "_globalTechniqueMask", null, IG_CORE_PLATFORM.ASPEN, IG_CORE_PLATFORM.ASPEN64)]
		[igField(typeof(igUnsignedLongMetaField), 0x09, 0x00, 0x10, 0x18, "_globalTechniqueMask")]
		public ulong _globalTechniqueMask;
		[igField(typeof(igUnsignedIntMetaField), 0x09, 0x01, 0x14, 0x20, "_materialBitField", null, IG_CORE_PLATFORM.ASPEN, IG_CORE_PLATFORM.ASPEN64)]
		[igField(typeof(igUnsignedIntMetaField), 0x09, 0x01, 0x18, 0x20, "_materialBitField")]
		public uint _materialBitField;
		[igField(typeof(igFloatMetaField), 0x09, 0x02, 0x18, 0x24, "_sortDepthOffset", null, IG_CORE_PLATFORM.ASPEN, IG_CORE_PLATFORM.ASPEN64)]
		[igField(typeof(igFloatMetaField), 0x09, 0x02, 0x1C, 0x24, "_sortDepthOffset")]
		public float _sortDepthOffset;
		[igField(typeof(igHandleMetaField<igObject>), 0x09, 0x03, 0x1C, 0x28, "_effectHandle", null, IG_CORE_PLATFORM.ASPEN, IG_CORE_PLATFORM.ASPEN64)]		//igGraphicsEffect
		[igField(typeof(igHandleMetaField<igObject>), 0x09, 0x03, 0x20, 0x28, "_effectHandle")]																//igGraphicsEffect
		public igHandle _effectHandle;
		[igField(typeof(igObjectRefMetaField<igObject>), 0x09, 0x04, 0x20, 0x30, "_commonState", null, IG_CORE_PLATFORM.ASPEN, IG_CORE_PLATFORM.ASPEN64)]	//igMemoryCommandStream
		[igField(typeof(igObjectRefMetaField<igObject>), 0x09, 0x04, 0x24, 0x30, "_commonState")]															//igMemoryCommandStream
		public igObject _commonState;
		[igField(typeof(igVectorMetaField<igObject, igObjectRefMetaField<igObject>>), 0x09, 0x05, 0x24, 0x38, "_techniques", null, IG_CORE_PLATFORM.ASPEN, IG_CORE_PLATFORM.ASPEN64)]	//igMemoryCommandStream
		[igField(typeof(igVectorMetaField<igObject, igObjectRefMetaField<igObject>>), 0x09, 0x05, 0x28, 0x38, "_techniques")]															//igMemoryCommandStream
		public List<igObject> _techniques;
		[igField(typeof(igObjectRefMetaField<igObject>), 0x09, 0x06, 0x30, 0x50, "_animations", null, IG_CORE_PLATFORM.ASPEN, IG_CORE_PLATFORM.ASPEN64)]	//igGraphicsMaterialAnimationList
		[igField(typeof(igObjectRefMetaField<igObject>), 0x09, 0x06, 0x34, 0x50, "_animations")]															//igGraphicsMaterialAnimationList
		public igObject _animations;
		[igField(typeof(igObjectRefMetaField<igGraphicsObjectSet>), 0x09, 0x07, 0x34, 0x58, "_graphicsObjects", null, IG_CORE_PLATFORM.ASPEN, IG_CORE_PLATFORM.ASPEN64)]
		[igField(typeof(igObjectRefMetaField<igGraphicsObjectSet>), 0x09, 0x07, 0x38, 0x58, "_graphicsObjects")]
		public igGraphicsObjectSet _graphicsObjects;
		[igField(typeof(igBitFieldMetaField<byte, igUnsignedIntMetaField>), 0x09, 0x08, 0x14, 0x20, "_sortKey", new object[2]{0, 4}, IG_CORE_PLATFORM.ASPEN, IG_CORE_PLATFORM.ASPEN64)]
		[igField(typeof(igBitFieldMetaField<byte, igUnsignedIntMetaField>), 0x09, 0x08, 0x18, 0x20, "_sortKey", new object[2]{0, 4})]
		public byte _sortKey;
		[igField(typeof(igBitFieldMetaField<igDrawType, igUnsignedIntMetaField>), 0x09, 0x09, 0x14, 0x20, "_drawType", new object[2]{4, 2}, IG_CORE_PLATFORM.ASPEN, IG_CORE_PLATFORM.ASPEN64)]
		[igField(typeof(igBitFieldMetaField<igDrawType, igUnsignedIntMetaField>), 0x09, 0x09, 0x18, 0x20, "_drawType", new object[2]{4, 2})]
		public igDrawType _drawType;
		[igField(typeof(igBitFieldMetaField<igGraphicsMaterialAnimationTimeSource, igUnsignedIntMetaField>), 0x09, 0x0A, 0x14, 0x20, "_timeSource", new object[2]{6, 2}, IG_CORE_PLATFORM.ASPEN, IG_CORE_PLATFORM.ASPEN64)]
		[igField(typeof(igBitFieldMetaField<igGraphicsMaterialAnimationTimeSource, igUnsignedIntMetaField>), 0x09, 0x0A, 0x18, 0x20, "_timeSource", new object[2]{6, 2})]
		public igGraphicsMaterialAnimationTimeSource _timeSource;
	}
}