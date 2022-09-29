namespace igLibrary.Entity
{
	[sizeofSize(0xFF, 0x24, 0x40)]
	public class igComponentDataTable : igHashTable<string, igStringMetaField, igComponentData, igObjectRefMetaField<igComponentData>>{}
}
