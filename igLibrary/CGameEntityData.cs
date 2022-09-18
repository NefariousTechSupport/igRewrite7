namespace igLibrary
{
	public class CGameEntityData : CEntityData
	{
		[igField(typeof(igUnsignedIntMetaField), 0x09, 0x00, 0x24, 0x38, "_gameEntityFlags")]
		public uint _gameEntityFlags;
		//[igField(typeof(igEnumMetaField<DistanceCullImportance>), 0x09, 0x01, 0x28, 0x3C, "_distanceCullImportance")]
		//public DistanceCullImportance _distanceCullImportance;
		//[igField(typeof(igEnumMetaField<ETeamFilterLayers>), 0x09, 0x02, 0x2C, 0x40, "_collisionLayer")]
		//public ETeamFilterLayers _collisionLayer;
		//[igField(typeof(igEnumMetaField<ECharacterCollisionPriority>), 0x09, 0x03, 0x30, 0x44, "_collisionPriority")]
		//public ECharacterCollisionPriority _collisionPriority;
		[igField(typeof(igStringMetaField), 0x09, 0x04, 0x34, 0x48, "_modelName")]
		public string _modelName;
		[igField(typeof(igStringMetaField), 0x09, 0x05, 0x38, 0x50, "_skinName")]
		public string _skinName;
		//[igField(typeof(igObjectRefMetaField<CFxMaterialRedirectTable>), 0x09, 0x06, 0x3C, 0x58, "_materialOverrides")]
		//public CFxMaterialRedirectTable _materialOverrides;
		//[igField(typeof(igHandleMetaField<CCollisionMaterial>), 0x09, 0x07, 0x40, 0x60, "_collisionMaterial")]
		//public CCollisionMaterial _collisionMaterial;
		[igField(typeof(igBoolMetaField), 0x09, 0x08, 0x44, 0x68, "_castsShadows")]
		public bool _castsShadows;
		//[igField(typeof(igEnumMetaField<EMobileShadowState>), 0x09, 0x09, 0x48, 0x6C, "_mobileShadowState")]
		//public EMobileShadowState _mobileShadowState;
		[igField(typeof(igFloatMetaField), 0x09, 0x0A, 0x4C, 0x70, "_lifetime")]
		public float _lifetime;
		[igField(typeof(igFloatMetaField), 0x09, 0x0B, 0x50, 0x74, "_lifetimeModifier")]
		public float _lifetimeModifier;
		//[igField(typeof(igEnumMetaField<EMemoryPoolID>), 0x09, 0x0C, 0x54, 0x78, "_cachedAssetPool")]
		//public EMemoryPoolID _cachedAssetPool;
		//[igField(typeof(igPropertyFieldMetaField), 0x09, 0x0D, 0x00, 0x00, "_material")]
	}
}