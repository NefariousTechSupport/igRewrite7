namespace igLibrary.Graphics
{
	public class igGraphicsTexture : igGraphicsObject
	{
		[igField(typeof(igEnumMetaField<igResourceUsage>), 0x09, 0x00, 0x08, 0x0C, "_usage")]
		public igResourceUsage _usage;
		[igField(typeof(igObjectRefMetaField<igImage2>), 0x09, 0x01, 0x0C, 0x10, "_image")]
		public igImage2 _image;
		[igField(typeof(igHandleMetaField<igImage2>), 0x09, 0x02, 0x10, 0x18, "_imageHandle")]
		public igHandle _imageHandle;
		[igField(typeof(igSizeTypeMetaField), 0x09, 0x03, 0x14, 0x20, "_resource")]
		public ulong _resource;
		
	}
}