namespace igLibrary.Graphics
{
	public class igGraphicsIndexBuffer : igGraphicsObject
	{
		[igField(typeof(igEnumMetaField<igResourceUsage>), 0x09, 0x00, 0x08, 0x0C, "_usage")]
		public igResourceUsage _usage;

		[igField(typeof(igObjectRefMetaField<igIndexBuffer>), 0x09, 0x01, 0x0C, 0x10, "_indexBuffer")]
		public igIndexBuffer _indexBuffer;

		[igField(typeof(igSizeTypeMetaField), 0x09, 0x02, 0x10, 0x18, "_resource")]
		public ulong _resource;

		public void GetBuffer(out uint[] indices, uint vertexCount) => _indexBuffer.GetBuffer(out indices, vertexCount);

	}
}