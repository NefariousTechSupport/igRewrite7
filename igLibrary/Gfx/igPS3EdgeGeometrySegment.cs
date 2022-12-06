using igLibrary.PS3Edge;

namespace igLibrary.Gfx
{
	[sizeofSize(0xFF, 0xB0, 0x00)]
	public class igPS3EdgeGeometrySegment : igObject
	{
		[igField(typeof(igMemoryRefMetaField), 0xFF, 0x00, 0x08, 0x00, "_spuConfigInfo")]
		public igMemory _spuConfigInfo;
		[igField(typeof(igMemoryRefMetaField), 0xFF, 0x01, 0x10, 0x00, "_indexes")]
		public igMemory _indexes;
		[igField(typeof(igUnsignedShortArrayMetaField), 0xFF, 0x02, 0x18, 0x00, "_indexesSizes", new object[]{ 2 })]
		public ushort[] _indexesSizes;
		[igField(typeof(igMemoryRefMetaField), 0xFF, 0x03, 0x1C, 0x00, "_spuVertexes0")]
		public igMemory _spuVertexes0;
		[igField(typeof(igMemoryRefMetaField), 0xFF, 0x04, 0x24, 0x00, "_spuVertexes1")]
		public igMemory _spuVertexes1;
		[igField(typeof(igUnsignedShortArrayMetaField), 0xFF, 0x05, 0x2C, 0x00, "_spuVertexesSizes", new object[]{ 6 })]
		public ushort[] _spuVertexesSizes;
		[igField(typeof(igMemoryRefMetaField), 0xFF, 0x06, 0x38, 0x00, "_rsxOnlyVertexes")]
		public igMemory _rsxOnlyVertexes;
		[igField(typeof(igUnsignedIntMetaField), 0xFF, 0x07, 0x40, 0x00, "_rsxOnlyVertexesSizes")]
		public uint _rsxOnlyVertexesSizes;
		[igField(typeof(igUnsignedShortArrayMetaField), 0xFF, 0x08, 0x44, 0x00, "_skinMatricesByteOffsets", new object[]{ 2 })]
		public ushort[] _skinMatricesByteOffsets;
		[igField(typeof(igUnsignedShortArrayMetaField), 0xFF, 0x09, 0x48, 0x00, "_skinMatricesSizes", new object[]{ 2 })]
		public ushort[] _skinMatricesSizes;
		[igField(typeof(igUnsignedShortArrayMetaField), 0xFF, 0x0A, 0x4C, 0x00, "_skinIndexesAndWeightsSizes", new object[]{ 2 })]
		public ushort[] _skinIndexesAndWeightsSizes;
		[igField(typeof(igMemoryRefMetaField), 0xFF, 0x0B, 0x50, 0x00, "_skinIndexesAndWeights")]
		public igMemory _skinIndexesAndWeights;
		[igField(typeof(igUnsignedIntMetaField), 0xFF, 0x0C, 0x58, 0x00, "_ioBufferSize")]
		public uint _ioBufferSize;
		[igField(typeof(igUnsignedIntMetaField), 0xFF, 0x0D, 0x5C, 0x00, "_scratchSize")]
		public uint _scratchSize;
		[igField(typeof(igMemoryRefMetaField), 0xFF, 0x0E, 0x60, 0x00, "_spuInputStreamDescs0")]
		public igMemory _spuInputStreamDescs0;
		[igField(typeof(igMemoryRefMetaField), 0xFF, 0x0F, 0x68, 0x00, "_spuInputStreamDescs1")]
		public igMemory _spuInputStreamDescs1;
		[igField(typeof(igMemoryRefMetaField), 0xFF, 0x10, 0x70, 0x00, "_spuOutputStreamDescs")]
		public igMemory _spuOutputStreamDescs;
		[igField(typeof(igMemoryRefMetaField), 0xFF, 0x11, 0x78, 0x00, "_rsxOnlyStreamDesc")]
		public igMemory _rsxOnlyStreamDesc;
		[igField(typeof(igUnsignedShortArrayMetaField), 0xFF, 0x12, 0x80, 0x00, "_spuInputStreamDescSizes", new object[]{ 2 })]
		public ushort[] _spuInputStreamDescSizes;
		[igField(typeof(igUnsignedShortMetaField), 0xFF, 0x13, 0x84, 0x00, "_spuOutputStreamDescSize")]
		public ushort _spuOutputStreamDescSize;
		[igField(typeof(igUnsignedShortMetaField), 0xFF, 0x14, 0x86, 0x00, "_rsxOnlyStreamDescSize")]
		public ushort _rsxOnlyStreamDescSize;
		[igField(typeof(igUnsignedIntMetaField), 0xFF, 0x15, 0x88, 0x00, "_numBlendShapes")]
		public uint _numBlendShapes;
		[igField(typeof(igVectorMetaField<ushort, igUnsignedShortMetaField>), 0xFF, 0x16, 0x8C, 0x00, "_blendShapeSizes")]
		public List<ushort> _blendShapeSizes;
		[igField(typeof(igMemoryRefMetaField), 0xFF, 0x17, 0x98, 0x00, "_blendShapeData")]
		public igMemory _blendShapeData;
		[igField(typeof(igVectorMetaField<ulong, igRawRefMetaField>), 0xFF, 0x18, 0xA0, 0x00, "_blendShapes")]
		public List<ulong> _blendShapes;
		[igField(typeof(igUnsignedIntMetaField), 0xFF, 0x19, 0xAC, 0x00, "_speedTreeType")]
		public uint _speedTreeType;

		private void GetSpuConfigInfo(out EdgeGeomSpuConfigInfo spuConfigInfo)
		{
			StreamHelper sh = new StreamHelper(_spuConfigInfo.buffer, StreamHelper.Endianness.Big);
			spuConfigInfo = sh.ReadStruct<EdgeGeomSpuConfigInfo>();
		}
		private void GetSpuInputStreamDescs0(out EdgeGeomVertexStreamDescription spuInputStreamDesc0, out EdgeGeomGenericBlock[] blocks)
		{
			if(_spuInputStreamDescs0.size == 0)
			{
				spuInputStreamDesc0 = new EdgeGeomVertexStreamDescription();
				blocks = null;
				return;
			}
			StreamHelper sh = new StreamHelper(_spuInputStreamDescs0.buffer, StreamHelper.Endianness.Big);
			spuInputStreamDesc0 = sh.ReadStruct<EdgeGeomVertexStreamDescription>();
			blocks = sh.ReadStructArray<EdgeGeomGenericBlock>(spuInputStreamDesc0.numBlocks);
		}
		private void GetSpuInputStreamDescs1(out EdgeGeomVertexStreamDescription spuInputStreamDesc1, out EdgeGeomGenericBlock[] blocks)
		{
			if(_spuInputStreamDescs1.size == 0)
			{
				spuInputStreamDesc1 = new EdgeGeomVertexStreamDescription();
				blocks = null;
				return;
			}
			StreamHelper sh = new StreamHelper(_spuInputStreamDescs1.buffer, StreamHelper.Endianness.Big);
			spuInputStreamDesc1 = sh.ReadStruct<EdgeGeomVertexStreamDescription>();
			blocks = sh.ReadStructArray<EdgeGeomGenericBlock>(spuInputStreamDesc1.numBlocks);
		}
		private void GetRsxOnlyStreamDesc(out EdgeGeomVertexStreamDescription rsxOnlyStreamDesc, out EdgeGeomGenericBlock[] blocks)
		{
			if(_rsxOnlyStreamDesc.size == 0)
			{
				rsxOnlyStreamDesc = new EdgeGeomVertexStreamDescription();
				blocks = null;
				return;
			}
			StreamHelper sh = new StreamHelper(_rsxOnlyStreamDesc.buffer, StreamHelper.Endianness.Big);
			rsxOnlyStreamDesc = sh.ReadStruct<EdgeGeomVertexStreamDescription>();
			blocks = sh.ReadStructArray<EdgeGeomGenericBlock>(rsxOnlyStreamDesc.numBlocks);
		}

		public void GetVertexBufferForAttribute(EDGE_GEOM_ATTRIBUTE_ID attribute, out float[]? outBuffer, out uint stride)
		{
			GetSpuConfigInfo(out EdgeGeomSpuConfigInfo spuConfigInfo);
			GetSpuInputStreamDescs0(out EdgeGeomVertexStreamDescription spuInputStreamDescs0, out EdgeGeomGenericBlock[] spuInputStreamDescs0Blocks);
			GetSpuInputStreamDescs1(out EdgeGeomVertexStreamDescription spuInputStreamDescs1, out EdgeGeomGenericBlock[] spuInputStreamDescs1Blocks);
			GetRsxOnlyStreamDesc(out EdgeGeomVertexStreamDescription rsxOnlyStreamDesc, out EdgeGeomGenericBlock[] rsxOnlyStreamDescBlocks);

			if(attribute == EDGE_GEOM_ATTRIBUTE_ID.POSITION && spuInputStreamDescs0.numBlocks == 0)
			{
				EdgeGeomVertexStreamDescription desc = new EdgeGeomVertexStreamDescription();
				desc.numAttributes = desc.numBlocks = 1;
				EdgeGeomGenericBlock block = new EdgeGeomGenericBlock();
				block.attributeBlock.componentCount = 3;
				block.attributeBlock.format = EDGE_GEOM_ATTRIBUTE_FORMAT.F32;
				block.attributeBlock.size = 0x0C;
				EdgeGeomVertexConversion.UnpackBufferForAttribute(_spuVertexes0.buffer, spuConfigInfo, desc, block, out outBuffer);
				stride = 3;
				return;
			}

			if(spuInputStreamDescs0Blocks != null)
			{
				int index = Array.FindIndex<EdgeGeomGenericBlock>(spuInputStreamDescs0Blocks, x => x.attributeBlock.edgeAttributeId == attribute);
				if(index >= 0)
				{
					EdgeGeomVertexConversion.UnpackBufferForAttribute(   _spuVertexes0.buffer, spuConfigInfo, spuInputStreamDescs0, spuInputStreamDescs0Blocks[index], out outBuffer);
					stride = (uint)outBuffer.Length / spuConfigInfo.numVertexes;
					return;
				}
			}

			if(spuInputStreamDescs1Blocks != null)
			{
				int index = Array.FindIndex<EdgeGeomGenericBlock>(spuInputStreamDescs1Blocks, x => x.attributeBlock.edgeAttributeId == attribute);
				if(index >= 0)
				{
					EdgeGeomVertexConversion.UnpackBufferForAttribute(   _spuVertexes1.buffer, spuConfigInfo, spuInputStreamDescs1, spuInputStreamDescs1Blocks[index], out outBuffer);
					stride = (uint)outBuffer.Length / spuConfigInfo.numVertexes;
					return;
				}
			}

			if(rsxOnlyStreamDescBlocks != null)
			{
				int index = Array.FindIndex<EdgeGeomGenericBlock>(   rsxOnlyStreamDescBlocks, x => x.attributeBlock.edgeAttributeId == attribute);
				if(index >= 0)
				{
					EdgeGeomVertexConversion.UnpackBufferForAttribute(_rsxOnlyVertexes.buffer, spuConfigInfo,    rsxOnlyStreamDesc,    rsxOnlyStreamDescBlocks[index], out outBuffer);
					stride = (uint)outBuffer.Length / spuConfigInfo.numVertexes;
					return;
				}
			}

			outBuffer = null;
			stride = 0;
		}
		public void GetIndexBuffer(out uint[] indices)
		{
			GetSpuConfigInfo(out EdgeGeomSpuConfigInfo spuConfigInfo);
			EdgeGeomVertexConversion.UnpackIndexBuffer(_indexes.buffer, spuConfigInfo, out indices);
		}
	}
}