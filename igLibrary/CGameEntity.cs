namespace igLibrary
{
	public class CGameEntity : CEntity
	{
		[igField(typeof(igUnsignedIntMetaField), 0x09, 0x00, 0x00, 0x98, "_gameEntityPersistentProperties")]
		public uint _gameEntityPersistentProperties;
		[igField(typeof(igBoolMetaField), 0x09, 0x01, 0x00, 0x9C, "_ignoreOcclusionBoxes")]
		public bool _ignoreOcclusionBoxes;
		[igField(typeof(igUnsignedIntMetaField), 0x09, 0x02, 0x00, 0xA0, "_gameEntityProperties")]
		public uint _gameEntityProperties;
		[igField(typeof(igFloatMetaField), 0x09, 0x03, 0x00, 0xA4, "_lifetimeCache")]
		public float _lifetimeCache;
		//[igField(typeof(igObjectRefMetaField<CAttachModelList>), 0x09, 0x04, 0x00, 0xA8, "_attachModelList")]
		//public CAttachModelList _attachModelList;
		//[igField(typeof(igObjectRefMetaField<CScopedScheduledFunction>), 0x09, 0x05, 0x00, 0xB0, "_animationCompleted")]
		//public CScopedScheduledFunction _animationCompleted;
		//[igField(typeof(igObjectRefMetaField<igCallbackDelegate>), 0x09, 0x06, 0x00, 0xB8, "_onAnimationCompleteDelegate")]
		//public igCallbackDelegate _onAnimationCompleteDelegate;
		//[igField(typeof(igHandleMetaField<COverrideRenderMatrixComponent>), 0x09, 0x07, 0x00, 0xC0, "_overrideRenderMatrixComponent")]
		//public COverrideRenderMatrixComponent _overrideRenderMatrixComponent;
		[igField(typeof(igFloatMetaField), 0x09, 0x08, 0x00, 0xC8, "_fadeStartTime")]
		public float _fadeStartTime;
		[igField(typeof(igFloatMetaField), 0x09, 0x09, 0x00, 0xCC, "_fadeEndTime")]
		public float _fadeEndTime;
		[igField(typeof(igObjectRefMetaField<igObject>), 0x09, 0x0A, 0x00, 0xD0, "mModel")]	//CModelInstance
		public igObject mModel;
		[igField(typeof(igBoolMetaField), 0x09, 0x0B, 0x00, 0xD8, "mBelowKillZ")]
		public bool mBelowKillZ;
		[igField(typeof(igBoolMetaField), 0x09, 0x0C, 0x00, 0xD9, "_IsValidModel")]
		public bool _IsValidModel;
		//[igField(typeof(igObjectRefMetaField<CFxMaterialRedirectTable>), 0x09, 0x0D, 0x00, 0xE0, "_dynamicModelMaterialOverrides")]
		//public CFxMaterialRedirectTable _dynamicModelMaterialOverrides;
		//[igField(typeof(igHandleMetaField<igVfxSpawnedEffect>), 0x09, 0x0E, 0x00, 0xE8, "_spawnedRenderVfx")]
		//public igVfxSpawnedEffect _spawnedRenderVfx;
		//[igField(typeof(igObjectRefMetaField<CCloudBundle>), 0x09, 0x0F, 0x00, 0xF0, "_cloudBundle")]
		//public CCloudBundle _cloudBundle;
		//[igField(typeof(igTimeMetaField), 0x09, 0x10, 0x00, 0xF8, "_lastNetUpdateTime")]
		//[igField(typeof(igTStaticMetaField<igBoolMetaField>), 0x09, 0x11, 0x00, 0x00, "sbDisplayPhysicsProperties")]
		//public static bool sbDisplayPhysicsProperties;
		//[igField(typeof(igTStaticMetaField<igBoolMetaField>), 0x09, 0x12, 0x00, 0x00, "_peachesCallbackRegistered")]
		//public static bool _peachesCallbackRegistered;
		[igField(typeof(igBitFieldMetaField<ECastsShadows>), 0x09, 0x13, 0x00, 0x98, "_castsShadows", new object[]{ 00, 2 })]
		public ECastsShadows _castsShadows;
		[igField(typeof(igBitFieldMetaField<EMobileShadowStateOverride>), 0x09, 0x14, 0x00, 0x98, "_mobileShadowStateOverride", new object[]{ 02, 2 })]
		public EMobileShadowStateOverride _mobileShadowStateOverride;
		[igField(typeof(igBitFieldMetaField<byte>), 0x09, 0x15, 0x00, 0xA0, "_viewportForceDisableFlags", new object[]{ 00, 8 })]
		public byte _viewportForceDisableFlags;
		[igField(typeof(igBitFieldMetaField<bool>), 0x09, 0x16, 0x00, 0xA0, "_animActive", new object[]{ 08, 1 })]
		public bool _animActive;
		[igField(typeof(igBitFieldMetaField<bool>), 0x09, 0x17, 0x00, 0xA0, "_animInReverse", new object[]{ 09, 1 })]
		public bool _animInReverse;
		[igField(typeof(igBitFieldMetaField<bool>), 0x09, 0x18, 0x00, 0xA0, "_noKillZ", new object[]{ 10, 1 })]
		public bool _noKillZ;
		[igField(typeof(igBitFieldMetaField<bool>), 0x09, 0x19, 0x00, 0xA0, "_hasDestination", new object[]{ 11, 1 })]
		public bool _hasDestination;
		[igField(typeof(igBitFieldMetaField<bool>), 0x09, 0x1A, 0x00, 0xA0, "_fadeIn", new object[]{ 12, 1 })]
		public bool _fadeIn;
		[igField(typeof(igBitFieldMetaField<bool>), 0x09, 0x1B, 0x00, 0xA0, "_scaleMovementSpeed", new object[]{ 13, 1 })]
		public bool _scaleMovementSpeed;

		public enum ECastsShadows : int
		{
			ECS_Archetype = 0,
			ECS_CastsShadows = 1,
			ECS_DoesNotCastShadows = 1,
		}
		public enum EMobileShadowStateOverride : int
		{
			eMSSO_Archetype = 0,
			eMSSO_CastsShadows = 1,
			eMSSO_ReceivesShadows = 2,
			eMSSO_DoesNotCastOrReceiveShadows = 3,
		}
	}
}