namespace igLibrary.Graphics
{
	[sizeofSize(0xFF, 0x14, 0x28)]
	public class igGraphicsObjectSet : igObject			//why doesn't this just inherit from igObjectList<igGraphicsObject>??
	{
		[igField(typeof(igVectorMetaField<igGraphicsObject, igObjectRefMetaField<igGraphicsObject>>), 0x09, 0x00, 0x08, 0x10, "_objects")]
		public List<igGraphicsObject> _objects;
	}
}