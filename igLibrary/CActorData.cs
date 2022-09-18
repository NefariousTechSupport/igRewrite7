namespace igLibrary
{
	public class CActorData : CPhysicalEntityData
	{
		[igField(typeof(igUnsignedIntMetaField), 0x09, 0x00, 0x68, 0x08C, "_actorDataFlags")]
		public uint _actorDataFlags;
		[igField(typeof(igStringMetaField), 0x09, 0x01, 0x6C, 0x090, "_character")]
		public string _character;
		[igField(typeof(igStringMetaField), 0x09, 0x02, 0x70, 0x098, "_skin")]
		public string _skin;																						//Note, this is how to get the actor
		[igField(typeof(igStringMetaField), 0x09, 0x03, 0x74, 0x0A0, "_magicMomentModel")]
		public string _magicMomentModel;
		[igField(typeof(igFloatMetaField), 0x09, 0x04, 0x78, 0x0A8, "_magicMomentSpawnBackgroundVfxOverrideTime")]
		public float _magicMomentSpawnBackgroundVfxOverrideTime;
		[igField(typeof(igFloatMetaField), 0x09, 0x05, 0x7C, 0x0AC, "_magicMomentSpawnOutroVfxOverrideTime")]
		public float _magicMomentSpawnOutroVfxOverrideTime;
		[igField(typeof(igFloatMetaField), 0x09, 0x06, 0x80, 0x0B0, "_magicMomentStartEndVfxOverrideTime")]
		public float _magicMomentStartEndVfxOverrideTime;
		[igField(typeof(igFloatMetaField), 0x09, 0x07, 0x84, 0x0B4, "_magicMomentShowNameOverrideTime")]
		public float _magicMomentShowNameOverrideTime;
		[igField(typeof(igFloatMetaField), 0x09, 0x08, 0x88, 0x0B8, "_magicMomentHideNameOverrideTime")]
		public float _magicMomentHideNameOverrideTime;
		[igField(typeof(igFloatMetaField), 0x09, 0x09, 0x8C, 0x0BC, "_magicMomentPauseIntroAnimationOverrideTime")]
		public float _magicMomentPauseIntroAnimationOverrideTime;
		[igField(typeof(igFloatMetaField), 0x09, 0x0A, 0x90, 0x0C0, "_magicMomentJumpOutTimeFromEndOverride")]
		public float _magicMomentJumpOutTimeFromEndOverride;
		[igField(typeof(igStringMetaField), 0x09, 0x0B, 0x94, 0x0C8, "_characterAnimations")]
		public string _characterAnimations;
		[igField(typeof(igStringMetaField), 0x09, 0x0C, 0x98, 0x0D0, "_characterAnimationBase")]
		public string _characterAnimationBase;
		//[igField(typeof(igObjectRefMetaField<CAudioArchiveHandleList>), 0x09, 0x0D, 0x9C, 0x0D8, "_soundBankHandleList")]
		//public CAudioArchiveHandleList _soundBankHandleList;
		[igField(typeof(igStringMetaField), 0x09, 0x0E, 0xA0, 0x0E0, "_characterScript")]
		public string _characterScript;
		[igField(typeof(igFloatMetaField), 0x09, 0x0F, 0xA4, 0x0E8, "_aiAlertRange")]
		public float _aiAlertRange;
		[igField(typeof(igBoolMetaField), 0x09, 0x10, 0xA8, 0x0EC, "_isShapeshifter")]
		public bool _isShapeshifter;
		[igField(typeof(igEnumMetaField<EAllowedHitReactDirections>), 0x09, 0x11, 0xAC, 0x0F0, "_takeHitReactDirections")]
		public EAllowedHitReactDirections _takeHitReactDirections;
		[igField(typeof(igEnumMetaField<EAllowedHitReactDirections>), 0x09, 0x12, 0xB0, 0x0F4, "_partialHitReactDirections")]
		public EAllowedHitReactDirections _partialHitReactDirections;
		[igField(typeof(igEnumMetaField<EAllowedHitReactDirections>), 0x09, 0x13, 0xB4, 0x0F8, "_knockawayReactDirections")]
		public EAllowedHitReactDirections _knockawayReactDirections;
		[igField(typeof(igEnumMetaField<EAllowedHitReactDirections>), 0x09, 0x14, 0xB8, 0x0FC, "_deathReactDirections")]
		public EAllowedHitReactDirections _deathReactDirections;
		[igField(typeof(igEnumMetaField<EAllowedHitReactDirections>), 0x09, 0x15, 0xBC, 0x100, "_knockawayDeathReactDirections")]
		public EAllowedHitReactDirections _knockawayDeathReactDirections;
		[igField(typeof(igHandleMetaField<igMaterial>), 0x09, 0x16, 0xC0, 0x108, "_hudPortrait")]
		public igHandle _hudPortrait;
		//[igField(typeof(igHandleMetaField<igVfxEffect>), 0x09, 0x17, 0xC4, 0x110, "_footstepEffect")]
		//public igHandle _footstepEffect;
		//[igField(typeof(igHandleMetaField<igVfxEffect>), 0x09, 0x18, 0xC8, 0x118, "_magicMomentNameEffect")]
		//public igHandle _magicMomentNameEffect;
	}
}