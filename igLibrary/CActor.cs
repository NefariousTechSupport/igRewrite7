namespace igLibrary
{
	public class CActor : CPhysicalEntity
	{
		[igField(typeof(igUnsignedIntMetaField), 0x09, 0x00, 0xF4, 0x15C, "mAttackNumber")]
		public uint mAttackNumber;
		//[igField(typeof(igHandleMetaField<CPlayer>), 0x09, 0x01, 0xF8, 0x160, "_player")]
		//public igHandle _player;
		[igField(typeof(igUnsignedIntMetaField), 0x09, 0x02, 0xFC, 0x168, "_nonPersistentBitfield")]
		public uint _nonPersistentBitfield;
		[igField(typeof(igBoolMetaField), 0x09, 0x03, 0x100, 0x16C, "mIsPlayerFastFlagHack")]
		public bool mIsPlayerFastFlagHack;
		[igField(typeof(igBoolMetaField), 0x09, 0x04, 0x101, 0x16D, "mInitialized")]
		public bool mInitialized;
		[igField(typeof(igBoolMetaField), 0x09, 0x05, 0x102, 0x16E, "_inFreezeFrame")]
		public bool _inFreezeFrame;
		[igField(typeof(igVec3fMetaField), 0x09, 0x06, 0x104, 0x170, "_linearVelocityBeforeFreezeFrame")]
		public Vector3 _linearVelocityBeforeFreezeFrame;
		[igField(typeof(igVec3fMetaField), 0x09, 0x07, 0x110, 0x17C, "_angularVelocityBeforeFreezeFrame")]
		public Vector3 _angularVelocityBeforeFreezeFrame;
		[igField(typeof(igVec2fMetaField), 0x09, 0x08, 0x11C, 0x188, "_currentMoveStickDirection")]
		public Vector2 _currentMoveStickDirection;
		//[igField(typeof(CTransformMetaField), 0x09, 0x09, 0x124, 0x190, "_cameraRelativeMovementTransform")]
		//public CTransform _cameraRelativeMovementTransform;
		[igField(typeof(igFloatMetaField), 0x09, 0x0A, 0x140, 0x1AC, "_heroShadowFade")]
		public float _heroShadowFade;
		[igField(typeof(igFloatMetaField), 0x09, 0x0B, 0xDC, 0x144, "mPainSoundTimer")]
		public float mPainSoundTimer;
		//[igField(typeof(igHandleMetaField<CCollisionMaterial>), 0x09, 0x0C, 0x144, 0x1B0, "_lastGroundMaterialTouched")]
		//public igHandle _lastGroundMaterialTouched;
		//[igField(typeof(igTimeMetaField), 0x09, 0x0D, 0xE0, 0x148, "mDeathTime")]
		//public Time mDeathTime;
		//[igField(typeof(CEntityIDMetaField), 0x09, 0x0E, 0xE4, 0x14C, "mLastHitEnt")]
		//public CEntityID mLastHitEnt;
		[igField(typeof(igFloatMetaField), 0x09, 0x0F, 0xE8, 0x150, "mLastHitEntTime")]
		public float mLastHitEntTime;
		[igField(typeof(igFloatMetaField), 0x09, 0x10, 0xEC, 0x154, "mLastAttackedTime")]
		public float mLastAttackedTime;
		//[igField(typeof(CEntityIDMetaField), 0x09, 0x11, 0xF0, 0x158, "mLastAttackedBy")]
		//public CEntityID mLastAttackedBy;
		//[igField(typeof(igObjectRefMetaField<CCombatTargetDataListList>), 0x09, 0x12, 0x198, 0x258, "_combatTargets")]
		//public CCombatTargetDataListList _combatTargets;
		[igField(typeof(igHandleMetaField<CActor>), 0x09, 0x13, 0x19C, 0x260, "_combatTargetProxy")]
		public igHandle _combatTargetProxy;
		//[igField(typeof(igObjectRefMetaField<CCollectibleFilterList>), 0x09, 0x14, 0x1A0, 0x268, "_collectiblesFilters")]
		//public CCollectibleFilterList _collectiblesFilters;
		//[igField(typeof(igHandleMetaField<CBaseVehicleControllerComponent>), 0x09, 0x15, 0x1A4, 0x270, "_enabledBaseVehicleController")]
		//public CBaseVehicleControllerComponent _enabledBaseVehicleController;
		[igField(typeof(igBoolMetaField), 0x09, 0x16, 0x1A8, 0x278, "_canCollectCollectibles")]
		public bool _canCollectCollectibles;
		[igField(typeof(igBoolMetaField), 0x09, 0x17, 0x148, 0x1B8, "_debugMove")]
		public bool _debugMove;
		//[igField(typeof(igObjectRefMetaField<ActorInput>), 0x09, 0x18, 0x14C, 0x1C0, "_actorInput")]
		//public ActorInput _actorInput;
		//[igField(typeof(igObjectRefMetaField<CCharacterPortalData>), 0x09, 0x19, 0x150, 0x1C8, "_portalData")]
		//public CCharacterPortalData _portalData;
		[igField(typeof(igBoolMetaField), 0x09, 0x1A, 0x154, 0x1D0, "_isMagicMomentDummy")]
		public bool _isMagicMomentDummy;
		//[igField(typeof(igHandleMetaField<igVfxSpawnedEffect>), 0x09, 0x1B, 0x158, 0x1D8, "_spawnedLowHealthEffect")]
		//public igHandle _spawnedLowHealthEffect;
		//[igField(typeof(igObjectRefMetaField<CEnableRequestManager>), 0x09, 0x1C, 0x15C, 0x1E0, "_ignoreHitReacts")]
		//public CEnableRequestManager _ignoreHitReacts;
		//[igField(typeof(igObjectRefMetaField<CEnableRequestManager>), 0x09, 0x1D, 0x160, 0x1E8, "_ignorePartialHitReacts")]
		//public CEnableRequestManager _ignorePartialHitReacts;
		//[igField(typeof(igObjectRefMetaField<CEnableRequestManager>), 0x09, 0x1E, 0x164, 0x1F0, "_ignoreHitPushBack")]
		//public CEnableRequestManager _ignoreHitPushBack;
		//[igField(typeof(igObjectRefMetaField<CTargetableFlagEnableStack>), 0x09, 0x1F, 0x168, 0x1F8, "_targetableFlag")]
		//public CTargetableFlagEnableStack _targetableFlag;
		//[igField(typeof(igObjectRefMetaField<CSpawnedActorVfxList>), 0x09, 0x20, 0x16C, 0x200, "_spawnedVfx")]
		//public CSpawnedActorVfxList _spawnedVfx;
		//[igField(typeof(igObjectRefMetaField<CActorTimeScaleNonRefcountedList>), 0x09, 0x21, 0x170, 0x208, "_timeScaleList")]
		//public CActorTimeScaleNonRefcountedList _timeScaleList;
		//[igField(typeof(igObjectRefMetaField<CTimeScaleEnableStack>), 0x09, 0x22, 0x174, 0x210, "_allowTimeScaling")]
		//public CTimeScaleEnableStack _allowTimeScaling;
		//[igField(typeof(igObjectRefMetaField<CActorTimeScale>), 0x09, 0x23, 0x178, 0x218, "_freezeFrameTimeScale")]
		//public CActorTimeScale _freezeFrameTimeScale;
		//[igField(typeof(igObjectRefMetaField<CEnableRequestManager>), 0x09, 0x24, 0x17C, 0x220, "_muted")]
		//public CEnableRequestManager _muted;
		//[igField(typeof(igObjectRefMetaField<CChangeRequestList>), 0x09, 0x25, 0x180, 0x228, "_changeRequests")]
		//public CChangeRequestList _changeRequests;
		[igField(typeof(igStringMetaField), 0x09, 0x26, 0x184, 0x230, "_skinName")]
		public string _skinName;
		//[igField(typeof(igTStaticMetaField<igBoolMetaField>), 0x09, 0x27, 0x00, 0x00, "_usedNoClip")]
		//public static bool _usedNoClip
		[igField(typeof(igBoolMetaField), 0x09, 0x28, 0x188, 0x238, "_followingOther")]
		public bool _followingOther;
		[igField(typeof(igObjectRefMetaField<CActor>), 0x09, 0x29, 0x18C, 0x240, "_followHero")]
		public CActor _followHero;
		//[igField(typeof(igHandleMetaField<CBehaviorComponent>), 0x09, 0x2A, 0x190, 0x248, "_behaviorComponentHandle")]
		//public igHandle _behaviorComponentHandle;
		//[igField(typeof(igHandleMetaField<CCharacterProgressionComponent>), 0x09, 0x2B, 0x194, 0x250, "_progressionComponentHandle")]
		//public igHandle _progressionComponentHandle;
		//[igField(typeof(igTStaticMetaField<igBoolMetaField>), 0x09, 0x2C, 0x00, 0x0, "mAllowFriendlyFire")]
		//public static bool mAllowFriendlyFire;
		//[igField(typeof(igTStaticMetaField<igBoolMetaField>), 0x09, 0x2D, 0x00, 0x0, "mHealthDisplay")]
		//public static bool mHealthDisplay;
		//[igField(typeof(igTStaticMetaField<igBoolMetaField>), 0x09, 0x2E, 0x00, 0x0, "mHeroUndying")]
		//public static bool mHeroUndying;
		//[igField(typeof(igTStaticMetaField<igBoolMetaField>), 0x09, 0x2F, 0x00, 0x0, "mGodMode")]
		//public static bool mGodMode;
		//[igField(typeof(igTStaticMetaField<igBoolMetaField>), 0x09, 0x30, 0x00, 0x0, "mDisplayFlash")]
		//public static bool mDisplayFlash;
		//[igField(typeof(igTStaticMetaField<igBoolMetaField>), 0x09, 0x31, 0x00, 0x0, "mDisplayPos")]
		//public static bool mDisplayPos;
		//[igField(typeof(igTStaticMetaField<igBoolMetaField>), 0x09, 0x32, 0x00, 0x0, "mTouchOfDeath")]
		//public static bool mTouchOfDeath;
		//[igField(typeof(igTStaticMetaField<igBoolMetaField>), 0x09, 0x33, 0x00, 0x0, "_debugEnemiesUndying")]
		//public static bool _debugEnemiesUndying;
		//[igField(typeof(igTStaticMetaField<igBoolMetaField>), 0x09, 0x34, 0x00, 0x0, "mAnimClipDisplayHero")]
		//public static bool mAnimClipDisplayHero;
		//[igField(typeof(igTStaticMetaField<igBoolMetaField>), 0x09, 0x35, 0x00, 0x0, "mAnimClipDisplayVehicle")]
		//public static bool mAnimClipDisplayVehicle;
		//[igField(typeof(igTStaticMetaField<igBoolMetaField>), 0x09, 0x36, 0x00, 0x0, "mAnimClipDisplayAI")]
		//public static bool mAnimClipDisplayAI;
		//[igField(typeof(igTStaticMetaField<igBoolMetaField>), 0x09, 0x37, 0x00, 0x0, "mTimelineDisplayHero")]
		//public static bool mTimelineDisplayHero;
		//[igField(typeof(igTStaticMetaField<igBoolMetaField>), 0x09, 0x38, 0x00, 0x0, "mTimelineDisplayVehicle")]
		//public static bool mTimelineDisplayVehicle;
		//[igField(typeof(igTStaticMetaField<igBoolMetaField>), 0x09, 0x39, 0x00, 0x0, "mTimelineDisplayAI")]
		//public static bool mTimelineDisplayAI;
		//[igField(typeof(igTStaticMetaField<igBoolMetaField>), 0x09, 0x3A, 0x00, 0x0, "mShowCombatTargets")]
		//public static bool mShowCombatTargets;
		//[igField(typeof(igTStaticMetaField<igBoolMetaField>), 0x09, 0x3B, 0x00, 0x0, "mDisplayMovementSpeed")]
		//public static bool mDisplayMovementSpeed;
		//[igField(typeof(igTStaticMetaField<igBoolMetaField>), 0x09, 0x3C, 0x00, 0x0, "mResetBehaviorOnNoClip")]
		//public static bool mResetBehaviorOnNoClip;
		//[igField(typeof(igTStaticMetaField<igBoolMetaField>), 0x09, 0x3D, 0x00, 0x0, "_disableButtonAliases")]
		//public static bool _disableButtonAliases;
		//[igField(typeof(igTStaticMetaField<igBoolMetaField>), 0x09, 0x3E, 0x00, 0x0, "_drawGroundMaterial")]
		//public static bool _drawGroundMaterial;
		//[igField(typeof(igTStaticMetaField<igBoolMetaField>), 0x09, 0x3F, 0x00, 0x0, "_drawEnemyEntityTags")]
		//public static bool _drawEnemyEntityTags;
		//[igField(typeof(igTStaticMetaField<CDebugCombatTargetCountTable>), 0x09, 0x40, 0x00, 0x0, "_debugCombatTargetCounts")]
		//public CDebugCombatTargetCountTable _debugCombatTargetCounts;
		[igField(typeof(igBitFieldMetaField<bool, igUnsignedIntMetaField>), 0x09, 0x41, 0xFC, 0x168, "_forceMovementForward", new object[]{ 0, 1 })]
		public bool _forceMovementForward;
		[igField(typeof(igBitFieldMetaField<bool, igUnsignedIntMetaField>), 0x09, 0x42, 0xFC, 0x168, "_isHoldingMove", new object[]{ 1, 1 })]
		public bool _isHoldingMove;
		[igField(typeof(igBitFieldMetaField<bool, igUnsignedIntMetaField>), 0x09, 0x43, 0xFC, 0x168, "_resetCameraRelativeMovement", new object[]{ 2, 1 })]
		public bool _resetCameraRelativeMovement;
		[igField(typeof(igBitFieldMetaField<bool, igUnsignedIntMetaField>), 0x09, 0x44, 0xFC, 0x168, "_hasBaseVehicleControllerComponent", new object[]{ 3, 1 })]
		public bool _hasBaseVehicleControllerComponent;
		[igField(typeof(igBitFieldMetaField<bool, igUnsignedIntMetaField>), 0x09, 0x45, 0xFC, 0x168, "_manualThinkControl", new object[]{ 4, 1 })]
		public bool _manualThinkControl;
		[igField(typeof(igBitFieldMetaField<bool, igUnsignedIntMetaField>), 0x09, 0x46, 0xFC, 0x168, "_animClipDisplayHero", new object[]{ 5, 1 })]
		public bool _animClipDisplayHero;
		[igField(typeof(igBitFieldMetaField<bool, igUnsignedIntMetaField>), 0x09, 0x47, 0xFC, 0x168, "_timelineDisplayHero", new object[]{ 6, 1 })]
		public bool _timelineDisplayHero;

		public override void ReadFields(igIGZ igz)
		{
			base.ReadFields(igz);
			return;
		}
	}
}