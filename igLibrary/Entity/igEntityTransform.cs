namespace igLibrary.Entity
{
	public class igEntityTransform : igObject
	{
		[igField(typeof(igQuaternionfMetaField), 0x09, 0x00, 0x10, 0x10, "_parentSpaceOrientation")]
		public Quaternion _parentSpaceOrientation;
		[igField(typeof(igMatrix44fMetaField), 0x09, 0x01, 0x20, 0x20, "_parentSpaceTransform")]
		public Matrix4x4 _parentSpaceTransform;
		[igField(typeof(igVec3fMetaField), 0x09, 0x02, 0x60, 0x60, "_parentSpaceRotation")]
		public Vector3 _parentSpaceRotation;
		[igField(typeof(igFloatMetaField), 0x09, 0x03, 0x6C, 0x6C, "_runtimeParentSpaceScale")]
		public float _runtimeParentSpaceScale;
		[igField(typeof(igVec3fMetaField), 0x09, 0x04, 0x70, 0x70, "_nonUniformPersistentParentSpaceScale")]
		public Vector3 _nonUniformPersistentParentSpaceScale;
		[igField(typeof(igBoolMetaField), 0x09, 0x05, 0x7C, 0x7C, "_isDirty")]
		public bool _isDirty;
		//[igField(typeof(igTStaticMetaField<igSpinLockMetaField>), 0x09, 0x06, 0x00, 0x00, "_lock")]
	}
}