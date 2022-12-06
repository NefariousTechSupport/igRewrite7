using igLibrary.PS3Edge;

namespace igLibrary.Gfx
{
	[sizeofSize(0xFF, 0x20, 0x00)]
	public class igPS3EdgeGeometry : igPS3EdgeGeometrySegmentList
	{
		[igField(typeof(igBoolMetaField), 0xFF, 0x00, 0x18, 0x00, "_isMorphed")]
		public bool _isMorphed;

		[igField(typeof(igBoolMetaField), 0xFF, 0x01, 0x19, 0x00, "_isSkinned")]
		public bool _isSkinned;

		[igField(typeof(igUnsignedIntMetaField), 0xFF, 0x02, 0x1C, 0x00, "_hashCode")]
		public uint _hashCode;

		public override void ReadFields(igIGZ igz)
		{
			base.ReadFields(igz);

			//endianness = igz._stream._endianness;
			//version = igz._version;
		}

		public void BatchSegmentVertexBuffersForAttribute(EDGE_GEOM_ATTRIBUTE_ID attribute, out float[]? outBuffer, out uint stride)
		{
			uint currentIndex = 0;
			uint[] strides = new uint[this._count];
			float[]?[] inBuffer = new float[this._count][];

			if(this._count > 1)
				Console.WriteLine("yo batching's happening");

			//Load the vertex buffers and allocate the batched buffer
			for(int i = 0; i < this._count; i++)
			{
				this[i].GetVertexBufferForAttribute(attribute, out inBuffer[i], out strides[i]);
				currentIndex += this[i].hSpuConfigInfo.numVertexes;
			}
			uint maxStride = strides.Max();
			if(maxStride == 0)
			{
				outBuffer = null;
				stride = 0;
				return;
			}
			outBuffer = new float[maxStride * currentIndex];

			if(maxStride == 4)
			{
				for(uint i = 0; i < currentIndex; i++)
				{
					outBuffer[(i + 1) * maxStride - 1] = 1.0f;	//Set the W component to 1, done in case any buffers have fewer than 4 components
				}
			}

			//Populate the batched buffer
			currentIndex = 0;
			for(int i = 0; i < this._count; i++)
			{
				if(inBuffer[i] != null)
				{
					for(uint j = 0; j < this[i].hSpuConfigInfo.numVertexes; j++)
					{
						Array.Copy(inBuffer[i], (int)(j * strides[i]), outBuffer, currentIndex + j * maxStride, strides[i]);
					}
				}

				currentIndex += this[i].hSpuConfigInfo.numVertexes * maxStride;
			}

			stride = maxStride;
		}

		public void BatchSegmentIndexBuffers(out uint[] outBuffer)
		{
			uint[][] inBuffer = new uint[this._count][];

			uint currentIndex = 0;

			//Load the index buffers and allocate the batched buffer
			for(int i = 0; i < inBuffer.Length; i++)
			{
				this[i].GetIndexBuffer(out inBuffer[i]);
				currentIndex += (uint)inBuffer[i].Length;
			}
			outBuffer = new uint[currentIndex];

			//Populate the batched buffer
			currentIndex = 0;
			uint minIndex = 0;
			for(int i = 0; i < inBuffer.Length; i++)
			{
				for(uint j = 0; j < inBuffer[i].Length; j++)
				{
					outBuffer[currentIndex + j] = inBuffer[i][j] + minIndex;
				}
				minIndex += this[i].hSpuConfigInfo.numVertexes;
				currentIndex += (uint)inBuffer[i].Length;
			}
		}
	}
}