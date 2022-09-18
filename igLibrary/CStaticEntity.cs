namespace igLibrary
{
	public class CStaticEntity : igObject
	{
		[igField(typeof(igObjectRefMetaField<CStaticEntityData>), 0x09, 0x00, 0x44, 0x58, "_entityData")]
		public CStaticEntityData _entityData;
		[igField(typeof(igVec3fMetaField), 0x09, 0x01, 0x08, 0x0C, "_position")]
		public Vector3 _position;
		[igField(typeof(igVec3fMetaField), 0x09, 0x02, 0x14, 0x18, "_rotation")]
		public Vector3 _rotation;
		[igField(typeof(igVec3fMetaField), 0x09, 0x03, 0x20, 0x24, "_scale")]
		public Vector3 _scale;
		//[igField(typeof(igObjectRefMetaField<CRigidModelInstance>), 0x09, 0x04, 0x2C, 0x30, "_model")]
		//public CRigidModelInstance _model;
		[igField(typeof(igEnumMetaField<CGameEntity.ECastsShadows>), 0x09, 0x05, 0x30, 0x38, "_castsShadows")]
		public CGameEntity.ECastsShadows _castsShadows;
		[igField(typeof(igEnumMetaField<CGameEntity.EMobileShadowStateOverride>), 0x09, 0x06, 0x34, 0x3C, "_mobileShadowState")]
		public CGameEntity.EMobileShadowStateOverride _mobileShadowState;
		[igField(typeof(igRawRefMetaField), 0x09, 0x07, 0x38, 0x40, "_navmesh")]
		public ulong _navmesh;
		[igField(typeof(igShortMetaField), 0x09, 0x08, 0x3C, 0x48, "_collisionManagerInstanceId")]
		public short _collisionManagerInstanceId;
		//[igField(typeof(igTStaticMetaField<igBoolMetaField>), 0x09, 0x09, 0x00, 0x00, "_peachesCallbackRegistered")]
		//public static bool _peachesCallbackRegistered;
		[igField(typeof(igBoolMetaField), 0x09, 0x0A, 0x3E, 0x4A, "_isCollisionBaked")]
		public bool _isCollisionBaked;
		//[igField(typeof(igObjectRefMetaField<CCloudBundle>), 0x09, 0x0B, 0x40, 0x50, "_cloudBundle")]
		//public CCloudBundle _cloudBundle;
		//[igField(typeof(igBoolMetaField), 0x09, 0x0C, 0x00, 0x00, "_isSelected")]
		//public bool _isSelected;
	}
}