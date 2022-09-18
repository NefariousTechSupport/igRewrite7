namespace igLibrary
{
	public class CPhysicalEntity : CGameEntity
	{
		//[igField(typeof(igVectorMetaField<CHealthObject, igObjectRefMetaField<igObject>>), 0x09, 0x00, 0xB0, 0x100, "_healthObjects")]	//CHealthObject
		//public List<CHealthObject> _healthObjects;
		[igField(typeof(igIntMetaField), 0x09, 0x01, 0xBC, 0x118, "_healthMax")]
		public int _healthMax;
		[igField(typeof(igIntMetaField), 0x09, 0x02, 0xC0, 0x11C, "_unadjustedMaxHealth")]
		public int _unadjustedMaxHealth;
		[igField(typeof(igFloatMetaField), 0x09, 0x03, 0xC4, 0x120, "_lastBeamAttackedTime")]
		public float _lastBeamAttackedTime;
		[igField(typeof(igEnumMetaField<EVulnerability>), 0x09, 0x04, 0xC8, 0x124, "_vulnerability")]
		public EVulnerability _vulnerability;
		//[igField(typeof(igObjectRefMetaField<CEnableRequestManager>), 0x09, 0x05, 0xCC, 0x128, "_invulnerable")]
		//public CEnableRequestManager _invulnerable;
		//[igField(typeof(igObjectRefMetaField<CAttackNumberTimestampTable>), 0x09, 0x06, 0xD0, 0x130, "_recentAttackNumberTimestampTable")]
		//public CAttackNumberTimestampTable _recentAttackNumberTimestampTable;
		//[igField(typeof(igObjectRefMetaField<CAttackImmunityTimestampTable>), 0x09, 0x07, 0xD4, 0x138, "_recentAttackImmunityTimestampTable")]
		//public CAttackImmunityTimestampTable _recentAttackImmunityTimestampTabl;
		[igField(typeof(igUnsignedCharMetaField), 0x09, 0x08, 0xD8, 0x140, "_runtimeFlags")]
		public byte _runtimeFlags;
		//[igField(typeof(igTStaticMetaField<igObjectRefMetaField<igUnsignedIntList>>), 0x09, 0x09, 0x00, 0x00, "_expiredAttackNumbers")]
		//public static igUnsignedIntList _expiredAttackNumbers;
		//[igField(typeof(igTStaticMetaField<igObjectRefMetaField<igStringRefList>>), 0x09, 0x0A, 0x00, 0x00, "_expiredImmunities")]
		//public static igStringRefList _expiredImmunities;
		[igField(typeof(igBitFieldMetaField<bool>), 0x09, 0x0B, 0xD8, 0x140, "_removeOnDeath", new object[] { 0, 1 })]
		public bool _removeOnDeath;
		[igField(typeof(igBitFieldMetaField<bool>), 0x09, 0x0C, 0xD8, 0x140, "_netDeath", new object[] { 1, 1 })]
		public bool _netDeath;
		[igField(typeof(igBitFieldMetaField<bool>), 0x09, 0x0D, 0xD8, 0x140, "_hasDied", new object[] { 2, 1 })]
		public bool _hasDied;
		[igField(typeof(igBitFieldMetaField<bool>), 0x09, 0x0E, 0xD8, 0x140, "_immunityCallbackRegistered", new object[] { 3, 1 })]
		public bool _immunityCallbackRegistered;

	}
}