namespace igLibrary
{
	public class CEntity : Entity.igEntity
	{
		[igField(typeof(igHandleMetaField<CEntity>), 0x09, 0x00, 0x28, 0x48, "_owner")]
		public igHandle _owner;
		[igField(typeof(igVec3fMetaField), 0x09, 0x01, 0x2C, 0x50, "_min")]
		public Vector3 _min;
		[igField(typeof(igVec3fMetaField), 0x09, 0x02, 0x38, 0x5C, "_max")]
		public Vector3 _max;
		[igField(typeof(igVec3fMetaField), 0x09, 0x03, 0x44, 0x68, "_velocity")]
		public Vector3 _velocity;
		[igField(typeof(igVec3fMetaField), 0x09, 0x04, 0x50, 0x74, "_angularVelocity")]
		public Vector3 _angularVelocity;
		//[igField(typeof(igStructMetaField), 0x09, 0x05, 0x5C, 0x80, "_flags")]
		//public _flags;
		[igField(typeof(igStringMetaField), 0x09, 0x06, 0x64, 0x88, "_name")]
		public string _name;
		//[igField(typeof(CEntityIDMetaField), 0x09, 0x07, 0x68, 0x90, "_id")]
		//public _id;
		[igField(typeof(igUnsignedShortMetaField), 0x09, 0x08, 0x6C, 0x94, "_properties")]
		public ushort _properties;
		[igField(typeof(igShortMetaField), 0x09, 0x09, 0x6E, 0x96, "_turningLockedCounter")]
		public short _turningLockedCounter;
		//[igField(typeof(igTStaticMetaField<igBoolMetaField>), 0x09, 0x0A, 0x00, 0x00, "_peachesCallbackRegistered")]
		//public static bool _peachesCallbackRegistered;
		[igField(typeof(igBitFieldMetaField<bool, igUnsignedShortMetaField>), 0x09, 0x0B, 0x6C, 0x94, "_startHidden", new object[] { 00, 1 })]
		public bool _startHidden;
		[igField(typeof(igBitFieldMetaField<bool, igUnsignedShortMetaField>), 0x09, 0x0C, 0x6C, 0x94, "_haveComponentsToStart", new object[] { 01, 1 })]
		public bool _haveComponentsToStart;
		[igField(typeof(igBitFieldMetaField<bool, igUnsignedShortMetaField>), 0x09, 0x0D, 0x6C, 0x94, "_haveComponentsToRemove", new object[] { 02, 1 })]
		public bool _haveComponentsToRemove;
		[igField(typeof(igBitFieldMetaField<bool, igUnsignedShortMetaField>), 0x09, 0x0E, 0x6C, 0x94, "_actEnabled", new object[] { 03, 1 })]
		public bool _actEnabled;
		[igField(typeof(igBitFieldMetaField<bool, igUnsignedShortMetaField>), 0x09, 0x0F, 0x6C, 0x94, "_actToggleOn", new object[] { 04, 1 })]
		public bool _actToggleOn;
		[igField(typeof(igBitFieldMetaField<EScaleSource, igUnsignedShortMetaField>), 0x09, 0x10, 0x6C, 0x94, "_scaleSource", new object[] { 05, 1 })]
		public EScaleSource _scaleSource;
		[igField(typeof(igBitFieldMetaField<bool, igUnsignedShortMetaField>), 0x09, 0x11, 0x6C, 0x94, "_netReplicate", new object[] { 06, 1 })]
		public bool _netReplicate;
		[igField(typeof(igBitFieldMetaField<bool, igUnsignedShortMetaField>), 0x09, 0x12, 0x6C, 0x94, "_hasTimeComponent", new object[] { 07, 1 })]
		public bool _hasTimeComponent;
		[igField(typeof(igBitFieldMetaField<bool, igUnsignedShortMetaField>), 0x09, 0x13, 0x6C, 0x94, "_hasScaledTimeComponent", new object[] { 08, 1 })]
		public bool _hasScaledTimeComponent;
		//[igField(typeof(igPropertyMetaField<>), 0x09, 0x15, 0x00, 0x00, "_netFlags")]
		//public _netFlags;

		public enum EScaleSource : byte
		{
			eSS_Entity = 0,
			eSS_EntityData = 1
		}
	}
}