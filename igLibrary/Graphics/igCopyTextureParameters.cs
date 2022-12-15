namespace igLibrary.Graphics
{
	[sizeofSize(0xFF, 0x20, 0x20)]
	public struct igCopyTextureParameters
	{
		public static void arkRegisterCompoundFields(igMetaFieldList metaFields)
		{
			IG_CORE_PLATFORM[] emptyPlatformOverride = new IG_CORE_PLATFORM[0];
			
			igIntMetaField             _sourceX = igMetaField.CreateMetaField<igIntMetaField>(0xFF, 0x00, 0x00, 0x00,             "_sourceX", emptyPlatformOverride);
			igIntMetaField             _sourceY = igMetaField.CreateMetaField<igIntMetaField>(0xFF, 0x01, 0x04, 0x04,             "_sourceY", emptyPlatformOverride);
			igIntMetaField        _destinationX = igMetaField.CreateMetaField<igIntMetaField>(0xFF, 0x02, 0x08, 0x08,        "_destinationX", emptyPlatformOverride);
			igIntMetaField        _destinationY = igMetaField.CreateMetaField<igIntMetaField>(0xFF, 0x03, 0x0C, 0x0C,        "_destinationY", emptyPlatformOverride);
			igIntMetaField               _width = igMetaField.CreateMetaField<igIntMetaField>(0xFF, 0x04, 0x10, 0x10,               "_width", emptyPlatformOverride);
			igIntMetaField              _height = igMetaField.CreateMetaField<igIntMetaField>(0xFF, 0x05, 0x14, 0x14,              "_height", emptyPlatformOverride);
			igIntMetaField      _sourceMipLevel = igMetaField.CreateMetaField<igIntMetaField>(0xFF, 0x06, 0x18, 0x18,      "_sourceMipLevel", emptyPlatformOverride);
			igIntMetaField _destinationMipLevel = igMetaField.CreateMetaField<igIntMetaField>(0xFF, 0x07, 0x1C, 0x1C, "_destinationMipLevel", emptyPlatformOverride);
			metaFields.Append(_sourceX);
			metaFields.Append(_sourceY);
			metaFields.Append(_destinationX);
			metaFields.Append(_destinationY);
			metaFields.Append(_width);
			metaFields.Append(_height);
			metaFields.Append(_sourceMipLevel);
			metaFields.Append(_destinationMipLevel);
		}

		public int _sourceX;
		public int _sourceY;
		public int _destinationX;
		public int _destinationY;
		public int _width;
		public int _height;
		public int _sourceMipLevel;
		public int _destinationMipLevel;
	}

	public class igCopyTextureParametersMetaField : igCompoundMetaField
	{
		public override Type OutputType() => typeof(igCopyTextureParameters);

		public igCopyTextureParametersMetaField() : base(){}

		public override void UserInstantiate()
		{
			_t = typeof(igCopyTextureParameters);
			igCopyTextureParameters.arkRegisterCompoundFields(this._metaFields);
		}
	}
}