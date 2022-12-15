namespace igLibrary.Graphics
{
	[sizeofSize(0xFF, 0x10, 0x20)]
	public class igGraphicsShaderConstant : igGraphicsObject
	{
		[igField(typeof(igStringMetaField), 0x09, 0x00, 0x08, 0x10, "_name")]
		public string _name;
		[igField(typeof(igSizeTypeMetaField), 0x09, 0x01, 0x0C, 0x18, "_resource")]
		public ulong _resource;
	}
}