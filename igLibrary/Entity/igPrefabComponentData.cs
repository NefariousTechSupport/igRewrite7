namespace igLibrary.Entity
{
	[sizeofSize(0xFF, 0x18, 0x28)]
	public class igPrefabComponentData : igComponentData
	{
		[igField(typeof(igObjectRefMetaField<igEntityList>), 0x09, 0x00, 0x10, 0x20, "_prefabEntities")]
		public igEntityList _prefabEntities;
	}
}