namespace igLibrary.Entity
{
	public class igEntityData : igObject
	{
		//igHashTable annoying
		//[igField(typeof(igObjectRefMetaField<igComponentDataTable>), 0x09, 0x00, 0x08, 0x10, "_componentData")]
		public igComponentDataTable _componentData;

		[igField(typeof(igFloatMetaField), 0x09, 0x01, 0x0C, 0x18, "_scale")]
		public float _scale;
	}
}