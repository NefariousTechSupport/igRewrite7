namespace igLibrary.Core
{
	[sizeofSize(0xFF, 0x0C, 0x18)]
	public class igNamedObject : igObject
	{
		[igField(typeof(igStringMetaField), 0xFF, 0x00, 0x08, 0x10, "_name")]
		public string _name;
	}
}