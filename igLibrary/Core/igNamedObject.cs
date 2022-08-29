namespace igLibrary.Core
{
	public class igNamedObject : igObject
	{
		[igField(typeof(igStringMetaField), 0xFF, 0x00, 0x08, 0x10, "_name")]
		public string _name;
	}
}