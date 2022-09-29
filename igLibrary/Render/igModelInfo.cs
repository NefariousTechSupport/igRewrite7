namespace igLibrary.Render
{
	[sizeofSize(0xFF, 0x18, 0x30)]
	public class igModelInfo : igInfo
	{
		[igField(typeof(igObjectRefMetaField<igModelData>), 0x09, 0x00, 0x14, 0x28, "_modelData")]
		public igModelData _modelData;
	} 
}