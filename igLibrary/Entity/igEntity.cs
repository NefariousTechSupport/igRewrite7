namespace igLibrary.Entity
{
	[sizeofSize(0xFF, 0x28, 0x48)]
	public class igEntity : igObject
	{
		[igField(typeof(igObjectRefMetaField<igEntityData>), 0x09, 0x00, 0x24, 0x40, "_entityData")]
		public igEntityData _entityData;

		//[igField(typeof(igObjectRefMetaField<igEntityBolt>), 0x09, 0x01, 0x08, 0x10, "_bolt")]
		//public igEntityBolt _bolt;

		[igField(typeof(igObjectRefMetaField<igComponentList>), 0x09, 0x02, 0x0C, 0x18, "_components")]
		public igComponentList _components;

		[igField(typeof(igVec3fMetaField), 0x09, 0x03, 0x10, 0x20, "_parentSpacePosition")]
		public Vector3 _parentSpacePosition;

		[igField(typeof(igObjectRefMetaField<igEntityTransform>), 0x09, 0x04, 0x1C, 0x30, "_transform")]
		public igEntityTransform _transform;

		[igField(typeof(igUnsignedIntMetaField), 0x09, 0x05, 0x20, 0x38, "_bitfield")]
		public uint _bitfield;
		[igField(typeof(igBitFieldMetaField<bool, igUnsignedIntMetaField>), 0x09, 0x06, 0x20, 0x38, "_canSpawn", new object[]{00, 1})]
		public bool _canSpawn;

		[igField(typeof(igBitFieldMetaField<bool, igUnsignedIntMetaField>), 0x09, 0x07, 0x20, 0x38, "_isArchetype", new object[]{01, 1})]
		public bool _isArchetype;

		[igField(typeof(igBitFieldMetaField<bool, igUnsignedIntMetaField>), 0x09, 0x08, 0x20, 0x38, "_spawned", new object[]{02, 1})]
		public bool _spawned;

		[igField(typeof(igBitFieldMetaField<uint, igUnsignedIntMetaField>), 0x09, 0x09, 0x20, 0x38, "_disableStack", new object[]{03, 4})]
		public uint _disableStack;

		[igField(typeof(igBitFieldMetaField<bool, igUnsignedIntMetaField>), 0x09, 0x0A, 0x20, 0x38, "_enabledByVisualScript", new object[]{07, 1})]
		public bool _enabledByVisualScript;

		[igField(typeof(igBitFieldMetaField<bool, igUnsignedIntMetaField>), 0x09, 0x0B, 0x20, 0x38, "_enabled", new object[]{08, 1})]
		public bool _enabled;

		[igField(typeof(igBitFieldMetaField<bool, igUnsignedIntMetaField>), 0x09, 0x0C, 0x20, 0x38, "_isFading", new object[]{09, 1})]
		public bool _isFading;

		[igField(typeof(igBitFieldMetaField<bool, igUnsignedIntMetaField>), 0x09, 0x0D, 0x20, 0x38, "_isPositionDirty", new object[]{10, 1})]
		public bool _isPositionDirty;

		[igField(typeof(igBitFieldMetaField<bool, igUnsignedIntMetaField>), 0x09, 0x0E, 0x20, 0x38, "_isRotationDirty", new object[]{11, 1})]
		public bool _isRotationDirty;

		[igField(typeof(igBitFieldMetaField<bool, igUnsignedIntMetaField>), 0x09, 0x0F, 0x20, 0x38, "_isScaleDirty", new object[]{12, 1})]
		public bool _isScaleDirty;

		[igField(typeof(igBitFieldMetaField<bool, igUnsignedIntMetaField>), 0x09, 0x10, 0x20, 0x38, "_isMoving", new object[]{13, 1})]
		public bool _isMoving;

		[igField(typeof(igBitFieldMetaField<bool, igUnsignedIntMetaField>), 0x09, 0x11, 0x20, 0x38, "_isVisible", new object[]{14, 1})]
		public bool _isVisible;

		[igField(typeof(igBitFieldMetaField<bool, igUnsignedIntMetaField>), 0x09, 0x12, 0x20, 0x38, "_isHidden", new object[]{15, 1})]
		public bool _isHidden;

		[igField(typeof(igBitFieldMetaField<bool, igUnsignedIntMetaField>), 0x09, 0x13, 0x20, 0x38, "_isVolumeCulled", new object[]{16, 1})]
		public bool _isVolumeCulled;

		[igField(typeof(igBitFieldMetaField<bool, igUnsignedIntMetaField>), 0x09, 0x14, 0x20, 0x38, "_canVolumeCull", new object[]{17, 1})]
		public bool _canVolumeCull;

		[igField(typeof(igBitFieldMetaField<uint, igUnsignedIntMetaField>), 0x09, 0x15, 0x20, 0x38, "_disableVolumeCullStack", new object[]{18, 5})]
		public uint _disableVolumeCullStack;

		[igField(typeof(igBitFieldMetaField<bool, igUnsignedIntMetaField>), 0x09, 0x16, 0x20, 0x38, "_disableVolumeCullByScript", new object[]{23, 1})]
		public bool _disableVolumeCullByScript;

		[igField(typeof(igBitFieldMetaField<int, igUnsignedIntMetaField>),  0x09, 0x17, 0x20, 0x38, "_userFlags", new object[]{24, 8})]
		public int _userFlags;

		//[igField(typeof(igPropertyMetaField), 0x09, 0x18, 0x00, 0x00, "_parentSpaceRotation")]
		//[igField(typeof(igPropertyMetaField), 0x09, 0x19, 0x00, 0x00, "_runtimeParentSpaceScale")]
		//[igField(typeof(igPropertyMetaField), 0x09, 0x1A, 0x00, 0x00, "_nonUniformPersistentParentScale")]
		//[igField(typeof(igBoolMetaField), 0x09, 0x1B, 0x00, 0x00, "_isSelected")]
	}
}