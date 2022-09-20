//reminder: you were last implementing models, you made it to igModelDrawCallData

namespace igLibrary.Render
{
	public class igModelDrawCallData : igNamedObject
	{
		[igField(typeof(igVec4fMetaField), 0x09, 0x00, 0x10, 0x20, "_min")]
		public Vector4 _min;

		[igField(typeof(igVec4fMetaField), 0x09, 0x01, 0x20, 0x30, "_max")]
		public Vector4 _max;

		[igField(typeof(igHandleMetaField<igGraphicsMaterial>), 0x09, 0x02, 0x30, 0x40, "_materialHandle")]
		public igHandle _materialHandle;

		[igField(typeof(igObjectRefMetaField<igGraphicsVertexBuffer>), 0x09, 0x03, 0x34, 0x48, "_graphicsVertexBuffer")]
		public igGraphicsVertexBuffer _graphicsVertexBuffer;
	
		[igField(typeof(igObjectRefMetaField<igGraphicsIndexBuffer>), 0x09, 0x04, 0x38, 0x50, "_graphicsIndexBuffer")]
		public igGraphicsIndexBuffer _graphicsIndexBuffer;

		[igField(typeof(igObjectRefMetaField<igObject>), 0x09, 0x05, 0x3C, 0x58, "_platformData")]
		public igObject _platformData;

		[igField(typeof(igUnsignedShortMetaField), 0x09, 0x06, 0x40, 0x60, "_blendVectorOffset")]
		public ushort _blendVectorOffset;

		[igField(typeof(igUnsignedShortMetaField), 0x09, 0x06, 0x42, 0x62, "_blendVectorCount")]
		public ushort _blendVectorCount;

		[igField(typeof(igIntMetaField), 0x09, 0x08, 0x44, 0x64, "_morphWeightTransformIndex")]
		public int _morphWeightTransformIndex;

		[igField(typeof(igIntMetaField), 0x09, 0x09, 0x48, 0x68, "_primitiveCount")]
		public int _primitiveCount;

		[igField(typeof(igUnsignedIntMetaField), 0x09, 0x0A, 0x4C, 0x6C, "_propertiesBitField")]
		public uint _propertiesBitField;

		//[igField(typeof(igObjectRefMetaField), 0x09, 0x0B, 0x50, 0x70, "_shaderConstantBundle", typeof(igShaderConstantBundleList))]
		//public igShaderConstantBundleList _shaderConstantBundle;
		[igField(typeof(igIntMetaField), 0x09, 0x0C, 0x54, 0x78, "_bakedBufferOffset")]
		public int _bakedBufferOffset;
		[igField(typeof(igUnsignedIntMetaField), 0x09, 0x0D, 0x58, 0x7C, "_hash")]
		public uint _hash;
		[igField(typeof(igSizeTypeMetaField), 0x09, 0x0E, 0x5C, 0x80, "_vertexBufferResource")]
		public ulong _vertexBufferResource;
		[igField(typeof(igSizeTypeMetaField), 0x09, 0x0F, 0x60, 0x88, "_vertexBufferFormatResource")]
		public ulong _vertexBufferFormatResource;
		[igField(typeof(igSizeTypeMetaField), 0x09, 0x10, 0x64, 0x90, "_indexBufferResource")]
		public ulong _indexBufferResource;
		[igField(typeof(igBitFieldMetaField<IG_INDEX_TYPE, igUnsignedIntMetaField>), 0x09, 0x11, 0x4C, 0x6C, "_indexBufferType", new object[2]{0, 3})]
		public IG_INDEX_TYPE _indexBufferType;
		[igField(typeof(igBitFieldMetaField<IG_GFX_DRAW, igUnsignedIntMetaField>), 0x09, 0x12, 0x4C, 0x6C, "_primitiveType", new object[2]{3, 3})]
		public IG_GFX_DRAW _primitiveType;
		[igField(typeof(igBitFieldMetaField<byte, igUnsignedIntMetaField>), 0x09, 0x13, 0x4C, 0x6C, "_lod", new object[2]{6, 8})]
		public byte _lod;
		[igField(typeof(igBitFieldMetaField<bool, igUnsignedIntMetaField>), 0x09, 0x14, 0x4C, 0x6C, "_enabled", new object[2]{14, 1})]
		public bool _enabled;
		[igField(typeof(igBitFieldMetaField<byte, igUnsignedIntMetaField>), 0x09, 0x15, 0x4C, 0x6C, "_instanceShaderConstants", new object[2]{15, 8})]
		public byte _instanceShaderConstants;


		public void GetVertexAttributeBuffer(out float[] vAttribute, IG_VERTEX_USAGE usage)
		{
			if(_graphicsVertexBuffer != null)
			{
				_graphicsVertexBuffer.GetBuffer(out vAttribute, usage);
			}
			else
			{
				throw new NotImplementedException("THIS PLATFORM IS UNSUPPORTED");
			}
		}
		public void GetIndexBuffer(out uint[] indices)
		{
			if(_graphicsIndexBuffer != null)
			{
				_graphicsIndexBuffer.GetBuffer(out indices, _graphicsVertexBuffer._vertexBuffer._vertexCount);
			}
			else
			{
				throw new NotImplementedException("THIS PLATFORM IS UNSUPPORTED");
			}
		}
	}
}