namespace igLibrary
{
	public class CGraphicsSkinInfo : igInfo
	{
		//[igField(typeof(igObjectRefMetaField<igSkeleton2>), 0x09, 0x00, 0x14, 0x28, "_skeleton")]
		//public igSkeleton2 _skeleton;
		[igField(typeof(igObjectRefMetaField<igModelData>), 0x09, 0x01, 0x18, 0x30, "_skin")]
		public igModelData _skin;
		//[igField(typeof(igObjectRefMetaField<igStringIntHashTable>), 0x09, 0x02, 0x1C, 0x38, "_boltPointIndexArray")]
		//public igStringIntHashTable _boltPointIndexArray;
		//[igField(typeof(igObjectRefMetaField<CHavokSkeleton>), 0x09, 0x03, 0x20, 0x40, "_havokSkeleton")]
		//public CHavokSkeleton _havokSkeleton;
		[igField(typeof(igVec3fMetaField), 0x09, 0x04, 0x24, 0x48, "_boundsMin")]
		public Vector3 _boundsMin;
		[igField(typeof(igVec3fMetaField), 0x09, 0x05, 0x30, 0x54, "_boundsMax")]
		public Vector3 _boundsMax;
	}
}