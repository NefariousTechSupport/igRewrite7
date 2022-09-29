namespace igLibrary.Graphics
{
	[sizeofSize(0xFF, 0x18, 0x28)]
	public class igGraphicsVertexBuffer : igGraphicsObject
	{
		[igField(typeof(igEnumMetaField<igResourceUsage>), 0x09, 0x00, 0x08, 0x0C, "_usage")]
		public igResourceUsage _usage;

		[igField(typeof(igObjectRefMetaField<igVertexBuffer>), 0x09, 0x01, 0x0C, 0x10, "_vertexBuffer")]
		public igVertexBuffer _vertexBuffer;

		[igField(typeof(igSizeTypeMetaField), 0x09, 0x02, 0x10, 0x18, "_resource")]
		public ulong _resource;

		[igField(typeof(igSizeTypeMetaField), 0x09, 0x03, 0x14, 0x20, "_formatResource")]
		public ulong _formatResource;

		public void GetBuffer(out float[]? buffer, IG_VERTEX_USAGE usage) => _vertexBuffer.GetBuffer(out buffer, usage);
	}
}