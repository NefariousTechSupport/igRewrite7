namespace igLibrary.Render
{
	public class igModelData : igNamedObject
	{
		[igField(typeof(igVec4fMetaField), 0x09, 0x00, 0x10, 0x20, "_min")]
		public Vector4 _min;

		[igField(typeof(igVec4fMetaField), 0x09, 0x01, 0x20, 0x30, "_max")]
		public Vector4 _max;

		//igVector<igAnimatedTransform>
		[igField(typeof(igVectorMetaField<igObject>), 0x09, 0x02, 0x30, 0x40, "_transforms")]
		public List<igObject> _transforms;

		//igVector<int>
		[igField(typeof(igVectorMetaField<int>), 0x09, 0x03, 0x3C, 0x58, "_transformHeirarchy")]
		public List<int> _transformHeirarchy;

		//igVector<igModelDrawCallData>
		[igField(typeof(igVectorMetaField<igModelDrawCallData>), 0x09, 0x04, 0x48, 0x70, "_drawCalls")]
		public List<igModelDrawCallData> _drawCalls;

		//igVector<int>
		[igField(typeof(igVectorMetaField<int>), 0x09, 0x05, 0x54, 0x88, "_drawCallTransformIndices")]
		public List<int> _drawCallTransformIndices;

		//igVector<igAnimatedMorphWeightTransform>
		[igField(typeof(igVectorMetaField<igObject>), 0x09, 0x06, 0x60, 0xA0, "_morphWeightTransforms")]
		public List<igObject> _morphWeightTransforms;

		//igVector<int>
		[igField(typeof(igVectorMetaField<int>), 0x09, 0x07, 0x6C, 0xB8, "_blendMatrixIndices")]
		public List<int> _blendMatrixIndices;
	} 
}