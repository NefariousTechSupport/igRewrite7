namespace igLibrary.Gfx
{
	public class igVertexFormat : igObject
	{
		[igField(typeof(igUnsignedIntMetaField), 0x09, 0x00, 0x08, 0x0C, "_vertexSize")]
		public uint _vertexSize;
		[igField(typeof(igMemoryRefMetaField<igVertexElementMetaField>), 0x09, 0x01, 0x0C, 0x10, "_elements")]
		public igMemory _elements;
		[igField(typeof(igMemoryRefMetaField), 0x09, 0x02, 0x14, 0x20, "_platformData")]
		public igMemory _data;
		[igField(typeof(igEnumMetaField<IG_GFX_PLATFORM>), 0x09, 0x03, 0x1C, 0x30, "_platform")]
		public IG_GFX_PLATFORM _platform;
		[igField(typeof(igObjectRefMetaField<igVertexFormat>), 0x09, 0x04, 0x20, 0x38, "_softwareBlendedFormat")]
		public igVertexFormat _softwareBlendedFormat;
		/*[igField(typeof(igObjectRefMetaField<igVertexBlender>), 0x09, 0x05, 0x24, 0x40, "_blender")]
		public igVertexBlender _blender;
		[igField(typeof(igBoolMetaField), 0x09, 0x06, 0x28, 0x48, "_dynamic")]
		public bool _dynamic;
		[igField(typeof(igObjectRefMetaField<igVertexFormatPlatform>), 0x09, 0x07, 0x2C, 0x50, "_platformFormat")]
		public igVertexFormatPlatform _platformFormat;
		[igField(typeof(igMemoryRefMetaField<igVertexStream>), 0x09, 0x08, 0x30, 0x58, "_streams")]
		public igMemory _streams;*/
		[igField(typeof(igUnsignedIntMetaField), 0x09, 0x09, 0x38, 0x68, "_hashCode")]
		public uint _hashCode;
		[igField(typeof(igObjectRefMetaField<igVertexFormat>), 0x09, 0x0A, 0x3C, 0x70, "_softwareBlendedMultistreamFormat")]
		public igVertexFormat _softwareBlendedMultistreamFormat;
		[igField(typeof(igBoolMetaField), 0x09, 0x0B, 0x40, 0x78, "_enableSoftwareBlending")]
		public bool _enableSoftwareBlending;
		[igField(typeof(igUnsignedIntMetaField), 0x09, 0x0C, 0x44, 0x7C, "_cachedUsage")]
		public uint _cachedUsage;

		/*public override unsafe void ReadFields(igIGZ igz)
		{
			base.ReadFields(igz);

			fixed(byte* elementBytes = _elements.buffer)
			{
				igVertexElement* elements = (igVertexElement*)elementBytes;
				for(int i = 0; i < (int)_elements.size / 12; i++)
				{
					Console.WriteLine($"elements[{i}]._type: {elements[i]._type}");
					Console.WriteLine($"elements[{i}]._usage: {elements[i]._usage}");
					Console.WriteLine($"elements[{i}]._offset: {elements[i]._offset}");
				}
			}
		}*/

		public unsafe igVertexElement GetElementFromUsage(IG_VERTEX_USAGE usage)
		{
			fixed(byte* elementBytes = _elements.buffer)
			{
				igVertexElement* elements = (igVertexElement*)elementBytes;
				for(int i = 0; i < (int)_elements.size / 12; i++)
				{
					if(elements[i]._usage == usage) return elements[i];
				}
				return new igVertexElement(){_type = IG_VERTEX_TYPE.UNUSED};
			}
		}
	}
}