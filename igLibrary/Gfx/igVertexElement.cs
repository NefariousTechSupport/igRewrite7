namespace igLibrary.Gfx
{
	[igStruct(0x09, 0x0C, 0x0C)]
	public struct igVertexElement
	{
		public static void arkRegisterCompoundFields(igMetaFieldList metafields)
		{
			IG_CORE_PLATFORM[] emptyPlatformOverride = new IG_CORE_PLATFORM[0];

			igUnsignedCharMetaField _type = new igUnsignedCharMetaField();
			_type._name = "_type";
			_type._offset32 = 0;
			_type._offset64 = 0;
			_type._version = 0xFF;
			_type._ordinal = 0x0;
			_type._overrides = emptyPlatformOverride;
			metafields.Append(_type);

			igUnsignedCharMetaField _stream = new igUnsignedCharMetaField();
			_stream._name = "_stream";
			_stream._offset32 = 1;
			_stream._offset64 = 1;
			_stream._version = 0xFF;
			_stream._ordinal = 0x1;
			_stream._overrides = emptyPlatformOverride;
			metafields.Append(_stream);

			igUnsignedCharMetaField _mapToElement = new igUnsignedCharMetaField();
			_mapToElement._name = "_mapToElement";
			_mapToElement._offset32 = 2;
			_mapToElement._offset64 = 2;
			_mapToElement._version = 0xFF;
			_mapToElement._ordinal = 0x2;
			_mapToElement._overrides = emptyPlatformOverride;
			metafields.Append(_mapToElement);

			igUnsignedCharMetaField _count = new igUnsignedCharMetaField();
			_count._name = "_count";
			_count._offset32 = 3;
			_count._offset64 = 3;
			_count._version = 0xFF;
			_count._ordinal = 0x3;
			_count._overrides = emptyPlatformOverride;
			metafields.Append(_count);

			igUnsignedCharMetaField _usage = new igUnsignedCharMetaField();
			_usage._name = "_usage";
			_usage._offset32 = 4;
			_usage._offset64 = 4;
			_usage._version = 0xFF;
			_usage._ordinal = 0x4;
			_usage._overrides = emptyPlatformOverride;
			metafields.Append(_usage);

			igUnsignedCharMetaField _usageIndex = new igUnsignedCharMetaField();
			_usageIndex._name = "_usageIndex";
			_usageIndex._offset32 = 5;
			_usageIndex._offset64 = 5;
			_usageIndex._version = 0xFF;
			_usageIndex._ordinal = 0x5;
			_usageIndex._overrides = emptyPlatformOverride;
			metafields.Append(_usageIndex);

			igUnsignedCharMetaField _packDataOffset = new igUnsignedCharMetaField();
			_packDataOffset._name = "_packDataOffset";
			_packDataOffset._offset32 = 6;
			_packDataOffset._offset64 = 6;
			_packDataOffset._version = 0xFF;
			_packDataOffset._ordinal = 0x6;
			_packDataOffset._overrides = emptyPlatformOverride;
			metafields.Append(_packDataOffset);

			igUnsignedCharMetaField _packTypeAndFracHint = new igUnsignedCharMetaField();
			_packTypeAndFracHint._name = "_packTypeAndFracHint";
			_packTypeAndFracHint._offset32 = 7;
			_packTypeAndFracHint._offset64 = 7;
			_packTypeAndFracHint._version = 0xFF;
			_packTypeAndFracHint._ordinal = 0x7;
			_packTypeAndFracHint._overrides = emptyPlatformOverride;
			metafields.Append(_packTypeAndFracHint);

			igUnsignedShortMetaField _offset = new igUnsignedShortMetaField();
			_offset._name = "_offset";
			_offset._offset32 = 8;
			_offset._offset64 = 8;
			_offset._version = 0xFF;
			_offset._ordinal = 0x8;
			_offset._overrides = emptyPlatformOverride;
			metafields.Append(_offset);

			igUnsignedShortMetaField _freq = new igUnsignedShortMetaField();
			_freq._name = "_freq";
			_freq._offset32 = 10;
			_freq._offset64 = 10;
			_freq._version = 0xFF;
			_freq._ordinal = 0x9;
			_freq._overrides = emptyPlatformOverride;
			metafields.Append(_freq);
		}

		public IG_VERTEX_TYPE _type;
		public byte _stream;
		public byte _mapToElement;
		public byte _count;
		public IG_VERTEX_USAGE _usage;
		public byte _usageIndex;
		public byte _packDataOffset;
		public byte _packTypeAndFracHint;
		public ushort _offset;
		public ushort _freq;

	}
}
