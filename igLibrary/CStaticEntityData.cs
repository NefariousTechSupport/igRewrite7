namespace igLibrary
{
	public class CStaticEntityData : igObject
	{
		[igField(typeof(igStringMetaField), 0x09, 0x00, 0x08, 0x10, "_modelName")]
		public string _modelName;
		//[igField(typeof(igObjectRefMetaField<CStaticDeformer>), 0x09, 0x01, 0x0C, 0x18, "_staticDeformer")]
		//public CStaticDeformer _staticDeformer;
		//[igField(typeof(igObjectRefMetaField<CEntityGroupSet>), 0x09, 0x02, 0x10, 0x20, "_entityGroupSet")]
		//public CEntityGroupSet _entityGroupSet;
		//[igField(typeof(igObjectRefMetaField<CFxMaterialRedirectTable>), 0x09, 0x03, 0x14, 0x28, "_materialOverrides")]
		//public CFxMaterialRedirectTable _materialOverrides;
		[igField(typeof(igUnsignedIntMetaField), 0x09, 0x04, 0x18, 0x30, "_flagsBitfield")]
		public uint _flagsBitfield;
		//[igField(typeof(igHandleMetaField<CCollisionMaterial>), 0x09, 0x05, 0x1C, 0x38, "_collisionMaterial")]
		//public CCollisionMaterial _collisionMaterial;
		//[igField(typeof(igBitFieldMetaField<DistanceCullImportance>), 0x09, 0x06, 0x18, 0x30, "_distanceCullImportance", new object[]{ 0, 3 })]
		//public DistanceCullImportance _distanceCullImportance;
		[igField(typeof(igBitFieldMetaField<bool>), 0x09, 0x07, 0x18, 0x30, "_ignoreOcclusionBoxes", new object[]{ 3, 1 })]
		public bool _ignoreOcclusionBoxes;
		[igField(typeof(igBitFieldMetaField<bool>), 0x09, 0x08, 0x18, 0x30, "_receiveDecals", new object[]{ 4, 1 })]
		public bool _receiveDecals;
		[igField(typeof(igBitFieldMetaField<bool>), 0x09, 0x09, 0x18, 0x30, "_disableVisual", new object[]{ 5, 1 })]
		public bool _disableVisual;
		[igField(typeof(igBitFieldMetaField<bool>), 0x09, 0x0A, 0x18, 0x30, "_disableCollision", new object[]{ 6, 1 })]
		public bool _disableCollision;
		[igField(typeof(igBitFieldMetaField<bool>), 0x09, 0x0B, 0x18, 0x30, "_castsShadows", new object[]{ 7, 1 })]
		public bool _castsShadows;
		[igField(typeof(igBitFieldMetaField<bool>), 0x09, 0x0C, 0x18, 0x30, "_enableNavMesh", new object[]{ 8, 1 })]
		public bool _enableNavMesh;
		[igField(typeof(igBitFieldMetaField<EMobileShadowState>), 0x09, 0x0D, 0x18, 0x30, "_mobileShadowState", new object[]{ 9, 2 })]
		public EMobileShadowState _mobileShadowState;
		[igField(typeof(igBitFieldMetaField<bool>), 0x09, 0x0E, 0x18, 0x30, "_includeInBake", new object[]{ 11, 1 })]
		public bool _includeInBake;
		//[igField(typeof(igPropertyFieldMetaField<EMaterialMetaEnum>), 0x09, 0x0F, 0x00, 0x00, "_physicsMaterial")]
		//public EMaterialMetaEnum _physicsMaterial;
	}
}