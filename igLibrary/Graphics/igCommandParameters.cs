//You'll see a lot of commented out igObjectRefMetaFields, the commented out ones are correct, but when the game decodes the stream it takes the raw value and looks it up in some sort of list

namespace igLibrary.Graphics
{
	[sizeofSize(0xFF, 0x04, 0x04)]
	public struct igCommandSetPrimitiveTypeParameters
	{
		public static void arkRegisterCompoundFields(igMetaFieldList metaFields)
		{
			IG_CORE_PLATFORM[] emptyPlatformOverride = new IG_CORE_PLATFORM[0];
			
			igEnumMetaField<IG_GFX_DRAW> _type = igMetaField.CreateMetaField<igEnumMetaField<IG_GFX_DRAW>>(0xFF, 0x00, 0x00, 0x00, "_type", emptyPlatformOverride);
			metaFields.Append(_type);
		}

		public IG_GFX_DRAW _type;
	}
	public class igCommandSetPrimitiveTypeParametersMetaField : igCompoundMetaField
	{
		public override Type OutputType() => typeof(igCommandSetPrimitiveTypeParameters);

		public igCommandSetPrimitiveTypeParametersMetaField() : base(){}

		public override void UserInstantiate()
		{
			_t = typeof(igCommandSetPrimitiveTypeParameters);
			igCommandSetPrimitiveTypeParameters.arkRegisterCompoundFields(this._metaFields);
		}
	}
	[sizeofSize(0xFF, 0x10, 0x18)]
	public struct igCommandSetVertexBufferParameters
	{
		public static void arkRegisterCompoundFields(igMetaFieldList metaFields)
		{
			IG_CORE_PLATFORM[] emptyPlatformOverride = new IG_CORE_PLATFORM[0];

			igSizeTypeMetaField      _resource = igMetaField.CreateMetaField<igSizeTypeMetaField>    (0xFF, 0x00, 0x00, 0x00, "_resource", emptyPlatformOverride);
			igSizeTypeMetaField      _format   = igMetaField.CreateMetaField<igSizeTypeMetaField>    (0xFF, 0x01, 0x04, 0x08,   "_format", emptyPlatformOverride);
			igIntMetaField           _offset   = igMetaField.CreateMetaField<igIntMetaField>         (0xFF, 0x02, 0x08, 0x10,   "_offset", emptyPlatformOverride);
			igUnsignedCharMetaField  _register = igMetaField.CreateMetaField<igUnsignedCharMetaField>(0xFF, 0x02, 0x0C, 0x14, "_register", emptyPlatformOverride);
			metaFields.Append(_resource);
			metaFields.Append(_format);
			metaFields.Append(_offset);
			metaFields.Append(_register);
		}

		public ulong _resource;
		public ulong _format;
		public int _offset;
		public byte _register;
	}
	public class igCommandSetVertexBufferParametersMetaField : igCompoundMetaField
	{
		public override Type OutputType() => typeof(igCommandSetVertexBufferParameters);

		public igCommandSetVertexBufferParametersMetaField() : base(){}

		public override void UserInstantiate()
		{
			_t = typeof(igCommandSetVertexBufferParameters);
			igCommandSetVertexBufferParameters.arkRegisterCompoundFields(this._metaFields);
		}
	}
	[sizeofSize(0xFF, 0x10, 0x10)]
	public struct igCommandSetIndexBufferParameters
	{
		public static void arkRegisterCompoundFields(igMetaFieldList metaFields)
		{
			IG_CORE_PLATFORM[] emptyPlatformOverride = new IG_CORE_PLATFORM[0];

			igSizeTypeMetaField            _resource = igMetaField.CreateMetaField<igSizeTypeMetaField>           (0xFF, 0x00, 0x00, 0x00, "_resource", emptyPlatformOverride);
			igEnumMetaField<IG_INDEX_TYPE> _format   = igMetaField.CreateMetaField<igEnumMetaField<IG_INDEX_TYPE>>(0xFF, 0x01, 0x04, 0x08,   "_format", emptyPlatformOverride);
			igIntMetaField                 _offset   = igMetaField.CreateMetaField<igIntMetaField>                (0xFF, 0x02, 0x08, 0x0C,   "_offset", emptyPlatformOverride);
			metaFields.Append(_resource);
			metaFields.Append(_format);
			metaFields.Append(_offset);
		}

		public ulong _resource;
		public IG_INDEX_TYPE _format;
		public int _offset;
	}
	public class igCommandSetIndexBufferParametersMetaField : igCompoundMetaField
	{
		public override Type OutputType() => typeof(igCommandSetIndexBufferParameters);

		public igCommandSetIndexBufferParametersMetaField() : base(){}

		public override void UserInstantiate()
		{
			_t = typeof(igCommandSetIndexBufferParameters);
			igCommandSetIndexBufferParameters.arkRegisterCompoundFields(this._metaFields);
		}
	}
	[sizeofSize(0xFF, 0x04, 0x08)]
	public struct igCommandSetVertexShaderParameters
	{
		public static void arkRegisterCompoundFields(igMetaFieldList metaFields)
		{
			IG_CORE_PLATFORM[] emptyPlatformOverride = new IG_CORE_PLATFORM[0];

			igSizeTypeMetaField            _resource = igMetaField.CreateMetaField<igSizeTypeMetaField>(0xFF, 0x00, 0x00, 0x00, "_resource", emptyPlatformOverride);
			metaFields.Append(_resource);
		}

		public ulong _resource;
	}

	public class igCommandSetVertexShaderParametersMetaField : igCompoundMetaField
	{
		public override Type OutputType() => typeof(igCommandSetVertexShaderParameters);

		public igCommandSetVertexShaderParametersMetaField() : base(){}

		public override void UserInstantiate()
		{
			_t = typeof(igCommandSetVertexShaderParameters);
			igCommandSetVertexShaderParameters.arkRegisterCompoundFields(this._metaFields);
		}
	}
	[sizeofSize(0xFF, 0x04, 0x08)]
	public struct igCommandSetVertexShaderVariantParameters
	{
		public static void arkRegisterCompoundFields(igMetaFieldList metaFields)
		{
			IG_CORE_PLATFORM[] emptyPlatformOverride = new IG_CORE_PLATFORM[0];

			//Is actually igShaderVariant2
			//igObjectRefMetaField<igObject> _resource = igMetaField.CreateMetaField<igObjectRefMetaField<igObject>>(0xFF, 0x00, 0x00, 0x00, "_resource", emptyPlatformOverride);
			igSizeTypeMetaField _resource = igMetaField.CreateMetaField<igSizeTypeMetaField>(0xFF, 0x00, 0x00, 0x00, "_resource", emptyPlatformOverride);
			metaFields.Append(_resource);
		}

		public ulong _resource;
	}
	public class igCommandSetVertexShaderVariantParametersMetaField : igCompoundMetaField
	{
		public override Type OutputType() => typeof(igCommandSetVertexShaderVariantParameters);

		public igCommandSetVertexShaderVariantParametersMetaField() : base(){}

		public override void UserInstantiate()
		{
			_t = typeof(igCommandSetVertexShaderVariantParameters);
			igCommandSetVertexShaderVariantParameters.arkRegisterCompoundFields(this._metaFields);
		}
	}
	[sizeofSize(0xFF, 0x08, 0x10)]
	public struct igCommandSetVertexShaderTextureParameters
	{
		public static void arkRegisterCompoundFields(igMetaFieldList metaFields)
		{
			IG_CORE_PLATFORM[] emptyPlatformOverride = new IG_CORE_PLATFORM[0];

			igSizeTypeMetaField            _resource = igMetaField.CreateMetaField<igSizeTypeMetaField>    (0xFF, 0x00, 0x00, 0x00, "_resource", emptyPlatformOverride);
			igUnsignedCharMetaField        _register = igMetaField.CreateMetaField<igUnsignedCharMetaField>(0xFF, 0x01, 0x04, 0x08, "_register", emptyPlatformOverride);
			metaFields.Append(_resource);
			metaFields.Append(_register);
		}

		public ulong _resource;
		public byte _register;
	}
	public class igCommandSetVertexShaderTextureParametersMetaField : igCompoundMetaField
	{
		public override Type OutputType() => typeof(igCommandSetVertexShaderTextureParameters);

		public igCommandSetVertexShaderTextureParametersMetaField() : base(){}

		public override void UserInstantiate()
		{
			_t = typeof(igCommandSetVertexShaderTextureParameters);
			igCommandSetVertexShaderTextureParameters.arkRegisterCompoundFields(this._metaFields);
		}
	}
	[sizeofSize(0xFF, 0x08, 0x10)]
	public struct igCommandSetVertexShaderSamplerParameters
	{
		public static void arkRegisterCompoundFields(igMetaFieldList metaFields)
		{
			IG_CORE_PLATFORM[] emptyPlatformOverride = new IG_CORE_PLATFORM[0];

			igSizeTypeMetaField            _resource = igMetaField.CreateMetaField<igSizeTypeMetaField>    (0xFF, 0x00, 0x00, 0x00, "_resource", emptyPlatformOverride);
			igUnsignedCharMetaField        _register = igMetaField.CreateMetaField<igUnsignedCharMetaField>(0xFF, 0x01, 0x04, 0x08, "_register", emptyPlatformOverride);
			metaFields.Append(_resource);
			metaFields.Append(_register);
		}

		public ulong _resource;
		public byte _register;
	}
	public class igCommandSetVertexShaderSamplerParametersMetaField : igCompoundMetaField
	{
		public override Type OutputType() => typeof(igCommandSetVertexShaderSamplerParameters);

		public igCommandSetVertexShaderSamplerParametersMetaField() : base(){}

		public override void UserInstantiate()
		{
			_t = typeof(igCommandSetVertexShaderSamplerParameters);
			igCommandSetVertexShaderSamplerParameters.arkRegisterCompoundFields(this._metaFields);
		}
	}
	[sizeofSize(0xFF, 0x08, 0x10)]
	public struct igCommandSetViewportParameters
	{
		public static void arkRegisterCompoundFields(igMetaFieldList metaFields)
		{
			IG_CORE_PLATFORM[] emptyPlatformOverride = new IG_CORE_PLATFORM[0];

			igSizeTypeMetaField            _resource = igMetaField.CreateMetaField<igSizeTypeMetaField>    (0xFF, 0x00, 0x00, 0x00, "_resource", emptyPlatformOverride);
			igUnsignedCharMetaField        _register = igMetaField.CreateMetaField<igUnsignedCharMetaField>(0xFF, 0x01, 0x04, 0x08, "_register", emptyPlatformOverride);
			metaFields.Append(_resource);
			metaFields.Append(_register);
		}

		public ulong _resource;
		public byte _register;
	}
	public class igCommandSetViewportParametersMetaField : igCompoundMetaField
	{
		public override Type OutputType() => typeof(igCommandSetViewportParameters);

		public igCommandSetViewportParametersMetaField() : base(){}

		public override void UserInstantiate()
		{
			_t = typeof(igCommandSetViewportParameters);
			igCommandSetViewportParameters.arkRegisterCompoundFields(this._metaFields);
		}
	}
	[sizeofSize(0xFF, 0x10, 0x10)]
	public struct igCommandSetScissorParameters
	{
		public static void arkRegisterCompoundFields(igMetaFieldList metaFields)
		{
			IG_CORE_PLATFORM[] emptyPlatformOverride = new IG_CORE_PLATFORM[0];

			igIntMetaField _x = igMetaField.CreateMetaField<igIntMetaField>(0xFF, 0x00, 0x00, 0x00, "_x", emptyPlatformOverride);
			igIntMetaField _y = igMetaField.CreateMetaField<igIntMetaField>(0xFF, 0x01, 0x04, 0x04, "_y", emptyPlatformOverride);
			igIntMetaField _w = igMetaField.CreateMetaField<igIntMetaField>(0xFF, 0x02, 0x08, 0x08, "_w", emptyPlatformOverride);
			igIntMetaField _h = igMetaField.CreateMetaField<igIntMetaField>(0xFF, 0x03, 0x0C, 0x0C, "_h", emptyPlatformOverride);
			metaFields.Append(_x);
			metaFields.Append(_y);
			metaFields.Append(_w);
			metaFields.Append(_h);
		}

		public int _x;
		public int _y;
		public int _w;
		public int _h;
	}
	public class igCommandSetScissorParametersMetaField : igCompoundMetaField
	{
		public override Type OutputType() => typeof(igCommandSetScissorParameters);

		public igCommandSetScissorParametersMetaField() : base(){}

		public override void UserInstantiate()
		{
			_t = typeof(igCommandSetScissorParameters);
			igCommandSetScissorParameters.arkRegisterCompoundFields(this._metaFields);
		}
	}
	[sizeofSize(0xFF, 0x04, 0x04)]
	public struct igCommandSetScissorEnabledParameters
	{
		public static void arkRegisterCompoundFields(igMetaFieldList metaFields)
		{
			IG_CORE_PLATFORM[] emptyPlatformOverride = new IG_CORE_PLATFORM[0];

			igBoolMetaField _enabled = igMetaField.CreateMetaField<igBoolMetaField>(0xFF, 0x00, 0x00, 0x00, "_enabled", emptyPlatformOverride);
			metaFields.Append(_enabled);
		}

		public bool _enabled;
	}
	public class igCommandSetScissorEnabledParametersMetaField : igCompoundMetaField
	{
		public override Type OutputType() => typeof(igCommandSetScissorEnabledParameters);

		public igCommandSetScissorEnabledParametersMetaField() : base(){}

		public override void UserInstantiate()
		{
			_t = typeof(igCommandSetScissorEnabledParameters);
			igCommandSetScissorEnabledParameters.arkRegisterCompoundFields(this._metaFields);
		}
	}
	[sizeofSize(0xFF, 0x04, 0x08)]
	public struct igCommandSetRasterizeStateBundleParameters
	{
		public static void arkRegisterCompoundFields(igMetaFieldList metaFields)
		{
			IG_CORE_PLATFORM[] emptyPlatformOverride = new IG_CORE_PLATFORM[0];

			igSizeTypeMetaField            _resource = igMetaField.CreateMetaField<igSizeTypeMetaField>    (0xFF, 0x00, 0x00, 0x00, "_resource", emptyPlatformOverride);
			metaFields.Append(_resource);
		}

		public ulong _resource;
	}
	public class igCommandSetRasterizeStateBundleParametersMetaField : igCompoundMetaField
	{
		public override Type OutputType() => typeof(igCommandSetRasterizeStateBundleParameters);

		public igCommandSetRasterizeStateBundleParametersMetaField() : base(){}

		public override void UserInstantiate()
		{
			_t = typeof(igCommandSetRasterizeStateBundleParameters);
			igCommandSetRasterizeStateBundleParameters.arkRegisterCompoundFields(this._metaFields);
		}
	}
	[sizeofSize(0xFF, 0x04, 0x08)]
	public struct igCommandSetPixelShaderParameters
	{
		public static void arkRegisterCompoundFields(igMetaFieldList metaFields)
		{
			IG_CORE_PLATFORM[] emptyPlatformOverride = new IG_CORE_PLATFORM[0];

			igSizeTypeMetaField            _resource = igMetaField.CreateMetaField<igSizeTypeMetaField>(0xFF, 0x00, 0x00, 0x00, "_resource", emptyPlatformOverride);
			metaFields.Append(_resource);
		}

		public ulong _resource;
	}

	public class igCommandSetPixelShaderParametersMetaField : igCompoundMetaField
	{
		public override Type OutputType() => typeof(igCommandSetPixelShaderParameters);

		public igCommandSetPixelShaderParametersMetaField() : base(){}

		public override void UserInstantiate()
		{
			_t = typeof(igCommandSetPixelShaderParameters);
			igCommandSetPixelShaderParameters.arkRegisterCompoundFields(this._metaFields);
		}
	}
	[sizeofSize(0xFF, 0x04, 0x08)]
	public struct igCommandSetPixelShaderVariantParameters
	{
		public static void arkRegisterCompoundFields(igMetaFieldList metaFields)
		{
			IG_CORE_PLATFORM[] emptyPlatformOverride = new IG_CORE_PLATFORM[0];

			//Is actually igShaderVariant2
			//igObjectRefMetaField<igObject> _resource = igMetaField.CreateMetaField<igObjectRefMetaField<igObject>>(0xFF, 0x00, 0x00, 0x00, "_resource", emptyPlatformOverride);
			igSizeTypeMetaField _resource = igMetaField.CreateMetaField<igSizeTypeMetaField>(0xFF, 0x00, 0x00, 0x00, "_resource", emptyPlatformOverride);
			metaFields.Append(_resource);
		}

		public ulong _resource;
	}
	public class igCommandSetPixelShaderVariantParametersMetaField : igCompoundMetaField
	{
		public override Type OutputType() => typeof(igCommandSetPixelShaderVariantParameters);

		public igCommandSetPixelShaderVariantParametersMetaField() : base(){}

		public override void UserInstantiate()
		{
			_t = typeof(igCommandSetPixelShaderVariantParameters);
			igCommandSetPixelShaderVariantParameters.arkRegisterCompoundFields(this._metaFields);
		}
	}
	[sizeofSize(0xFF, 0x08, 0x10)]
	public struct igCommandSetPixelShaderTextureParameters
	{
		public static void arkRegisterCompoundFields(igMetaFieldList metaFields)
		{
			IG_CORE_PLATFORM[] emptyPlatformOverride = new IG_CORE_PLATFORM[0];

			igSizeTypeMetaField            _resource = igMetaField.CreateMetaField<igSizeTypeMetaField>    (0xFF, 0x00, 0x00, 0x00, "_resource", emptyPlatformOverride);
			igUnsignedCharMetaField        _register = igMetaField.CreateMetaField<igUnsignedCharMetaField>(0xFF, 0x01, 0x04, 0x08, "_register", emptyPlatformOverride);
			metaFields.Append(_resource);
			metaFields.Append(_register);
		}

		public ulong _resource;
		public byte _register;
	}
	public class igCommandSetPixelShaderTextureParametersMetaField : igCompoundMetaField
	{
		public override Type OutputType() => typeof(igCommandSetPixelShaderTextureParameters);

		public igCommandSetPixelShaderTextureParametersMetaField() : base(){}

		public override void UserInstantiate()
		{
			_t = typeof(igCommandSetPixelShaderTextureParameters);
			igCommandSetPixelShaderTextureParameters.arkRegisterCompoundFields(this._metaFields);
		}
	}
	[sizeofSize(0xFF, 0x08, 0x10)]
	public struct igCommandSetPixelShaderSamplerParameters
	{
		public static void arkRegisterCompoundFields(igMetaFieldList metaFields)
		{
			IG_CORE_PLATFORM[] emptyPlatformOverride = new IG_CORE_PLATFORM[0];

			igSizeTypeMetaField            _resource = igMetaField.CreateMetaField<igSizeTypeMetaField>    (0xFF, 0x00, 0x00, 0x00, "_resource", emptyPlatformOverride);
			igUnsignedCharMetaField        _register = igMetaField.CreateMetaField<igUnsignedCharMetaField>(0xFF, 0x01, 0x04, 0x08, "_register", emptyPlatformOverride);
			metaFields.Append(_resource);
			metaFields.Append(_register);
		}
		public ulong _resource;
		public byte _register;
	}
	public class igCommandSetPixelShaderSamplerParametersMetaField : igCompoundMetaField
	{
		public override Type OutputType() => typeof(igCommandSetPixelShaderSamplerParameters);

		public igCommandSetPixelShaderSamplerParametersMetaField() : base(){}

		public override void UserInstantiate()
		{
			_t = typeof(igCommandSetPixelShaderSamplerParameters);
			igCommandSetPixelShaderSamplerParameters.arkRegisterCompoundFields(this._metaFields);
		}
	}
	[sizeofSize(0xFF, 0x04, 0x08)]
	public struct igCommandSetAlphaTestStateBundleParameters
	{
		public static void arkRegisterCompoundFields(igMetaFieldList metaFields)
		{
			IG_CORE_PLATFORM[] emptyPlatformOverride = new IG_CORE_PLATFORM[0];

			igSizeTypeMetaField            _resource = igMetaField.CreateMetaField<igSizeTypeMetaField>    (0xFF, 0x00, 0x00, 0x00, "_resource", emptyPlatformOverride);
			metaFields.Append(_resource);
		}
		public ulong _resource;
	}
	public class igCommandSetAlphaTestStateBundleParametersMetaField : igCompoundMetaField
	{
		public override Type OutputType() => typeof(igCommandSetAlphaTestStateBundleParameters);

		public igCommandSetAlphaTestStateBundleParametersMetaField() : base(){}

		public override void UserInstantiate()
		{
			_t = typeof(igCommandSetAlphaTestStateBundleParameters);
			igCommandSetAlphaTestStateBundleParameters.arkRegisterCompoundFields(this._metaFields);
		}
	}
	[sizeofSize(0xFF, 0x04, 0x08)]
	public struct igCommandSetBlendStateBundleParameters
	{
		public static void arkRegisterCompoundFields(igMetaFieldList metaFields)
		{
			IG_CORE_PLATFORM[] emptyPlatformOverride = new IG_CORE_PLATFORM[0];

			igSizeTypeMetaField            _resource = igMetaField.CreateMetaField<igSizeTypeMetaField>    (0xFF, 0x00, 0x00, 0x00, "_resource", emptyPlatformOverride);
			metaFields.Append(_resource);
		}
		public ulong _resource;
	}
	public class igCommandSetBlendStateBundleParametersMetaField : igCompoundMetaField
	{
		public override Type OutputType() => typeof(igCommandSetBlendStateBundleParameters);

		public igCommandSetBlendStateBundleParametersMetaField() : base(){}

		public override void UserInstantiate()
		{
			_t = typeof(igCommandSetBlendStateBundleParameters);
			igCommandSetBlendStateBundleParameters.arkRegisterCompoundFields(this._metaFields);
		}
	}
	[sizeofSize(0xFF, 0x04, 0x08)]
	public struct igCommandSetDepthStateBundleParameters
	{
		public static void arkRegisterCompoundFields(igMetaFieldList metaFields)
		{
			IG_CORE_PLATFORM[] emptyPlatformOverride = new IG_CORE_PLATFORM[0];

			igSizeTypeMetaField            _resource = igMetaField.CreateMetaField<igSizeTypeMetaField>    (0xFF, 0x00, 0x00, 0x00, "_resource", emptyPlatformOverride);
			metaFields.Append(_resource);
		}
		public ulong _resource;
	}
	public class igCommandSetDepthStateBundleParametersMetaField : igCompoundMetaField
	{
		public override Type OutputType() => typeof(igCommandSetDepthStateBundleParameters);

		public igCommandSetDepthStateBundleParametersMetaField() : base(){}

		public override void UserInstantiate()
		{
			_t = typeof(igCommandSetDepthStateBundleParameters);
			igCommandSetDepthStateBundleParameters.arkRegisterCompoundFields(this._metaFields);
		}
	}
	[sizeofSize(0xFF, 0x04, 0x08)]
	public struct igCommandSetStencilStateBundleParameters
	{
		public static void arkRegisterCompoundFields(igMetaFieldList metaFields)
		{
			IG_CORE_PLATFORM[] emptyPlatformOverride = new IG_CORE_PLATFORM[0];

			igSizeTypeMetaField            _resource = igMetaField.CreateMetaField<igSizeTypeMetaField>    (0xFF, 0x00, 0x00, 0x00, "_resource", emptyPlatformOverride);
			metaFields.Append(_resource);
		}
		public ulong _resource;
	}
	public class igCommandSetStencilStateBundleParametersMetaField : igCompoundMetaField
	{
		public override Type OutputType() => typeof(igCommandSetStencilStateBundleParameters);

		public igCommandSetStencilStateBundleParametersMetaField() : base(){}

		public override void UserInstantiate()
		{
			_t = typeof(igCommandSetStencilStateBundleParameters);
			igCommandSetStencilStateBundleParameters.arkRegisterCompoundFields(this._metaFields);
		}
	}
	[sizeofSize(0xFF, 0x04, 0x04)]
	public struct igCommandSetStencilRefParameters
	{
		public static void arkRegisterCompoundFields(igMetaFieldList metaFields)
		{
			IG_CORE_PLATFORM[] emptyPlatformOverride = new IG_CORE_PLATFORM[0];

			igUnsignedIntMetaField _stencilRef = igMetaField.CreateMetaField<igUnsignedIntMetaField>(0xFF, 0x00, 0x00, 0x00, "_stencilRef", emptyPlatformOverride);
			metaFields.Append(_stencilRef);
		}
		public uint _stencilRef;
	}
	public class igCommandSetStencilRefParametersMetaField : igCompoundMetaField
	{
		public override Type OutputType() => typeof(igCommandSetStencilRefParameters);

		public igCommandSetStencilRefParametersMetaField() : base(){}

		public override void UserInstantiate()
		{
			_t = typeof(igCommandSetStencilRefParameters);
			igCommandSetStencilRefParameters.arkRegisterCompoundFields(this._metaFields);
		}
	}
	[sizeofSize(0xFF, 0x28, 0x50)]
	public struct igCommandSetRenderTargetsParameters
	{
		public static void arkRegisterCompoundFields(igMetaFieldList metaFields)
		{
			IG_CORE_PLATFORM[] emptyPlatformOverride = new IG_CORE_PLATFORM[0];

			igSizeTypeArrayMetaField _colorTargets = igMetaField.CreateMetaField<igSizeTypeArrayMetaField>(0xFF, 0x00, 0x00, 0x00, "_colorTargets", emptyPlatformOverride);
			igUnsignedIntMetaField   _colorCount   = igMetaField.CreateMetaField<igUnsignedIntMetaField>  (0xFF, 0x01, 0x20, 0x40,   "_colorCount", emptyPlatformOverride);
			igSizeTypeMetaField      _depthTarget  = igMetaField.CreateMetaField<igSizeTypeMetaField>     (0xFF, 0x02, 0x24, 0x48,  "_depthTarget", emptyPlatformOverride);
			_colorTargets._num = 8;
			metaFields.Append(_colorTargets);
			metaFields.Append(_colorCount);
			metaFields.Append(_depthTarget);
		}
		public ulong[] _colorTargets;
		public uint _colorCount;
		public ulong _depthTarget;
	}
	public class igCommandSetRenderTargetsParametersMetaField : igCompoundMetaField
	{
		public override Type OutputType() => typeof(igCommandSetRenderTargetsParameters);

		public igCommandSetRenderTargetsParametersMetaField() : base(){}

		public override void UserInstantiate()
		{
			_t = typeof(igCommandSetRenderTargetsParameters);
			igCommandSetRenderTargetsParameters.arkRegisterCompoundFields(this._metaFields);
		}
	}
	[sizeofSize(0xFF, 0x04, 0x08)]
	public struct igCommandSetRenderTargetMaskParameters
	{
		public static void arkRegisterCompoundFields(igMetaFieldList metaFields)
		{
			IG_CORE_PLATFORM[] emptyPlatformOverride = new IG_CORE_PLATFORM[0];

			igSizeTypeMetaField            _resource = igMetaField.CreateMetaField<igSizeTypeMetaField>    (0xFF, 0x00, 0x00, 0x00, "_resource", emptyPlatformOverride);
			metaFields.Append(_resource);
		}
		public ulong _resource;
	}
	public class igCommandSetRenderTargetMaskParametersMetaField : igCompoundMetaField
	{
		public override Type OutputType() => typeof(igCommandSetRenderTargetMaskParameters);

		public igCommandSetRenderTargetMaskParametersMetaField() : base(){}

		public override void UserInstantiate()
		{
			_t = typeof(igCommandSetRenderTargetMaskParameters);
			igCommandSetRenderTargetMaskParameters.arkRegisterCompoundFields(this._metaFields);
		}
	}
	[sizeofSize(0xFF, 0x0C, 0x0C)]
	public struct igCommandXenonSetHiStencilParameters
	{
		public static void arkRegisterCompoundFields(igMetaFieldList metaFields)
		{
			IG_CORE_PLATFORM[] emptyPlatformOverride = new IG_CORE_PLATFORM[0];

			igBoolMetaField                                 _state = igMetaField.CreateMetaField<igBoolMetaField>                           (0xFF, 0x00, 0x00, 0x00,      "_state", emptyPlatformOverride);
			igBoolMetaField                            _writeState = igMetaField.CreateMetaField<igBoolMetaField>                           (0xFF, 0x01, 0x01, 0x01, "_writeState", emptyPlatformOverride);
			igEnumMetaField<IG_GFX_HISTENCIL_FUNCTION>       _func = igMetaField.CreateMetaField<igEnumMetaField<IG_GFX_HISTENCIL_FUNCTION>>(0xFF, 0x02, 0x04, 0x04,       "_func", emptyPlatformOverride);
			igUnsignedIntMetaField                       _refValue = igMetaField.CreateMetaField<igUnsignedIntMetaField>                    (0xFF, 0x03, 0x08, 0x08,   "_refValue", emptyPlatformOverride);
			metaFields.Append(_state);
			metaFields.Append(_writeState);
			metaFields.Append(_func);
			metaFields.Append(_refValue);
		}
		public bool _state;
		public bool _writeState;
		public IG_GFX_HISTENCIL_FUNCTION _func;
		public uint _refValue;
	}
	public class igCommandXenonSetHiStencilParametersMetaField : igCompoundMetaField
	{
		public override Type OutputType() => typeof(igCommandXenonSetHiStencilParameters);

		public igCommandXenonSetHiStencilParametersMetaField() : base(){}

		public override void UserInstantiate()
		{
			_t = typeof(igCommandXenonSetHiStencilParameters);
			igCommandXenonSetHiStencilParameters.arkRegisterCompoundFields(this._metaFields);
		}
	}
	[sizeofSize(0xFF, 0x04, 0x04)]
	public struct igCommandXenonSetFlushHiZStencilParameters
	{
		public static void arkRegisterCompoundFields(igMetaFieldList metaFields)
		{
			IG_CORE_PLATFORM[] emptyPlatformOverride = new IG_CORE_PLATFORM[0];

			igBoolMetaField                                 _async = igMetaField.CreateMetaField<igBoolMetaField>                           (0xFF, 0x00, 0x00, 0x00,      "_async", emptyPlatformOverride);
			metaFields.Append(_async);
		}
		public bool _async;
	}
	public class igCommandXenonSetFlushHiZStencilParametersMetaField : igCompoundMetaField
	{
		public override Type OutputType() => typeof(igCommandXenonSetFlushHiZStencilParameters);

		public igCommandXenonSetFlushHiZStencilParametersMetaField() : base(){}

		public override void UserInstantiate()
		{
			_t = typeof(igCommandXenonSetFlushHiZStencilParameters);
			igCommandXenonSetFlushHiZStencilParameters.arkRegisterCompoundFields(this._metaFields);
		}
	}
	[sizeofSize(0xFF, 0x08, 0x08)]
	public struct igCommandXenonSetGprCountsParameters
	{
		public static void arkRegisterCompoundFields(igMetaFieldList metaFields)
		{
			IG_CORE_PLATFORM[] emptyPlatformOverride = new IG_CORE_PLATFORM[0];

			igUnsignedIntMetaField _vertex = igMetaField.CreateMetaField<igUnsignedIntMetaField>(0xFF, 0x00, 0x00, 0x00, "_vertex", emptyPlatformOverride);
			igUnsignedIntMetaField _pixel  = igMetaField.CreateMetaField<igUnsignedIntMetaField>(0xFF, 0x01, 0x04, 0x04, "_pixel", emptyPlatformOverride);
			metaFields.Append(_vertex);
			metaFields.Append(_pixel);
		}
		public uint _vertex;
		public uint _pixel;
	}
	public class igCommandXenonGprCountsParametersMetaField : igCompoundMetaField
	{
		public override Type OutputType() => typeof(igCommandXenonSetGprCountsParameters);

		public igCommandXenonGprCountsParametersMetaField() : base(){}

		public override void UserInstantiate()
		{
			_t = typeof(igCommandXenonSetGprCountsParameters);
			igCommandXenonSetGprCountsParameters.arkRegisterCompoundFields(this._metaFields);
		}
	}
	[sizeofSize(0xFF, 0x0C, 0x0C)]
	public struct igCommandPS3SetSCullParameters
	{
		public static void arkRegisterCompoundFields(igMetaFieldList metaFields)
		{
			IG_CORE_PLATFORM[] emptyPlatformOverride = new IG_CORE_PLATFORM[0];

			igEnumMetaField<IG_GFX_STENCIL_FUNCTION>  _function = igMetaField.CreateMetaField<igEnumMetaField<IG_GFX_STENCIL_FUNCTION>>(0xFF, 0x00, 0x00, 0x00, "_function", emptyPlatformOverride);
			igUnsignedIntMetaField                    _refValue = igMetaField.CreateMetaField<igUnsignedIntMetaField>                  (0xFF, 0x01, 0x04, 0x04, "_refValue", emptyPlatformOverride);
			igUnsignedIntMetaField                        _mask = igMetaField.CreateMetaField<igUnsignedIntMetaField>                  (0xFF, 0x02, 0x08, 0x08,     "_mask", emptyPlatformOverride);
			metaFields.Append(_function);
			metaFields.Append(_refValue);
			metaFields.Append(_mask);
		}
		public IG_GFX_STENCIL_FUNCTION _function;
		public uint _refValue;
		public uint _mask;
	}
	public class igCommandPS3SetSCullParametersMetaField : igCompoundMetaField
	{
		public override Type OutputType() => typeof(igCommandPS3SetSCullParameters);

		public igCommandPS3SetSCullParametersMetaField() : base(){}

		public override void UserInstantiate()
		{
			_t = typeof(igCommandPS3SetSCullParameters);
			igCommandPS3SetSCullParameters.arkRegisterCompoundFields(this._metaFields);
		}
	}
	[sizeofSize(0xFF, 0x08, 0x10)]
	public struct igCommandSetConstantBoolParameters
	{
		public static void arkRegisterCompoundFields(igMetaFieldList metaFields)
		{
			IG_CORE_PLATFORM[] emptyPlatformOverride = new IG_CORE_PLATFORM[0];

			igSizeTypeMetaField _resource = igMetaField.CreateMetaField<igSizeTypeMetaField>(0xFF, 0x00, 0x00, 0x00, "_resource", emptyPlatformOverride);
			igBoolMetaField        _value =     igMetaField.CreateMetaField<igBoolMetaField>(0xFF, 0x01, 0x04, 0x08,    "_value", emptyPlatformOverride);
			metaFields.Append(_resource);
			metaFields.Append(_value);
		}

		public ulong _resource;
		public bool _value;
	}
	public class igCommandSetConstantBoolParametersMetaField : igCompoundMetaField
	{
		public override Type OutputType() => typeof(igCommandSetConstantBoolParameters);

		public igCommandSetConstantBoolParametersMetaField() : base(){}

		public override void UserInstantiate()
		{
			_t = typeof(igCommandSetConstantBoolParameters);
			igCommandSetConstantBoolParameters.arkRegisterCompoundFields(this._metaFields);
		}
	}
	[sizeofSize(0xFF, 0x08, 0x10)]
	public struct igCommandSetConstantIntParameters
	{
		public static void arkRegisterCompoundFields(igMetaFieldList metaFields)
		{
			IG_CORE_PLATFORM[] emptyPlatformOverride = new IG_CORE_PLATFORM[0];

			igSizeTypeMetaField _resource = igMetaField.CreateMetaField<igSizeTypeMetaField>(0xFF, 0x00, 0x00, 0x00, "_resource", emptyPlatformOverride);
			igIntMetaField         _value =      igMetaField.CreateMetaField<igIntMetaField>(0xFF, 0x01, 0x04, 0x08,    "_value", emptyPlatformOverride);
			metaFields.Append(_resource);
			metaFields.Append(_value);
		}

		public ulong _resource;
		public int _value;
	}
	public class igCommandSetConstantIntParametersMetaField : igCompoundMetaField
	{
		public override Type OutputType() => typeof(igCommandSetConstantIntParameters);

		public igCommandSetConstantIntParametersMetaField() : base(){}

		public override void UserInstantiate()
		{
			_t = typeof(igCommandSetConstantIntParameters);
			igCommandSetConstantIntParameters.arkRegisterCompoundFields(this._metaFields);
		}
	}
	[sizeofSize(0xFF, 0x08, 0x10)]
	public struct igCommandSetConstantFloatParameters
	{
		public static void arkRegisterCompoundFields(igMetaFieldList metaFields)
		{
			IG_CORE_PLATFORM[] emptyPlatformOverride = new IG_CORE_PLATFORM[0];

			igSizeTypeMetaField _resource = igMetaField.CreateMetaField<igSizeTypeMetaField>(0xFF, 0x00, 0x00, 0x00, "_resource", emptyPlatformOverride);
			igFloatMetaField       _value =    igMetaField.CreateMetaField<igFloatMetaField>(0xFF, 0x01, 0x04, 0x08,    "_value", emptyPlatformOverride);
			metaFields.Append(_resource);
			metaFields.Append(_value);
		}

		public ulong _resource;
		public float _value;
	}
	public class igCommandSetConstantFloatParametersMetaField : igCompoundMetaField
	{
		public override Type OutputType() => typeof(igCommandSetConstantFloatParameters);

		public igCommandSetConstantFloatParametersMetaField() : base(){}

		public override void UserInstantiate()
		{
			_t = typeof(igCommandSetConstantFloatParameters);
			igCommandSetConstantFloatParameters.arkRegisterCompoundFields(this._metaFields);
		}
	}
	[sizeofSize(0xFF, 0x20, 0x20)]
	public struct igCommandSetConstantVec4fParameters
	{
		public static void arkRegisterCompoundFields(igMetaFieldList metaFields)
		{
			IG_CORE_PLATFORM[] emptyPlatformOverride = new IG_CORE_PLATFORM[0];

			igSizeTypeMetaField _resource = igMetaField.CreateMetaField<igSizeTypeMetaField>(0xFF, 0x00, 0x00, 0x00, "_resource", emptyPlatformOverride);
			igVec4fMetaField       _value =    igMetaField.CreateMetaField<igVec4fMetaField>(0xFF, 0x01, 0x10, 0x10,    "_value", emptyPlatformOverride);
			metaFields.Append(_resource);
			metaFields.Append(_value);
		}

		public ulong _resource;
		public Vector4 _value;
	}
	public class igCommandSetConstantVec4fParametersMetaField : igCompoundMetaField
	{
		public override Type OutputType() => typeof(igCommandSetConstantVec4fParameters);

		public igCommandSetConstantVec4fParametersMetaField() : base(){}

		public override void UserInstantiate()
		{
			_t = typeof(igCommandSetConstantVec4fParameters);
			igCommandSetConstantVec4fParameters.arkRegisterCompoundFields(this._metaFields);
		}
	}
	[sizeofSize(0xFF, 0x50, 0x50)]
	public struct igCommandSetConstantMatrix44fParameters
	{
		public static void arkRegisterCompoundFields(igMetaFieldList metaFields)
		{
			IG_CORE_PLATFORM[] emptyPlatformOverride = new IG_CORE_PLATFORM[0];

			igSizeTypeMetaField  _resource =  igMetaField.CreateMetaField<igSizeTypeMetaField>(0xFF, 0x00, 0x00, 0x00, "_resource", emptyPlatformOverride);
			igMatrix44fMetaField    _value = igMetaField.CreateMetaField<igMatrix44fMetaField>(0xFF, 0x01, 0x10, 0x10,    "_value", emptyPlatformOverride);
			metaFields.Append(_resource);
			metaFields.Append(_value);
		}

		public ulong _resource;
		public Matrix4x4 _value;
	}
	public class igCommandSetConstantMatrix44fParametersMetaField : igCompoundMetaField
	{
		public override Type OutputType() => typeof(igCommandSetConstantMatrix44fParameters);

		public igCommandSetConstantMatrix44fParametersMetaField() : base(){}

		public override void UserInstantiate()
		{
			_t = typeof(igCommandSetConstantMatrix44fParameters);
			igCommandSetConstantMatrix44fParameters.arkRegisterCompoundFields(this._metaFields);
		}
	}
	[sizeofSize(0xFF, 0x0C, 0x18)]
	public struct igCommandSetConstantArrayIntParameters
	{
		public static void arkRegisterCompoundFields(igMetaFieldList metaFields)
		{
			IG_CORE_PLATFORM[] emptyPlatformOverride = new IG_CORE_PLATFORM[0];

			igSizeTypeMetaField _resource = igMetaField.CreateMetaField<igSizeTypeMetaField>(0xFF, 0x00, 0x00, 0x00, "_resource", emptyPlatformOverride);
			igRawRefMetaField      _value =   igMetaField.CreateMetaField<igRawRefMetaField>(0xFF, 0x01, 0x04, 0x08,    "_value", emptyPlatformOverride);
			igIntMetaField         _count =      igMetaField.CreateMetaField<igIntMetaField>(0xFF, 0x01, 0x04, 0x08,    "_count", emptyPlatformOverride);
			metaFields.Append(_resource);
			metaFields.Append(_value);
			metaFields.Append(_count);
		}

		public ulong _resource;
		public ulong _value;
		public int _count;
	}
	public class igCommandSetConstantArrayIntParametersMetaField : igCompoundMetaField
	{
		public override Type OutputType() => typeof(igCommandSetConstantArrayIntParameters);

		public igCommandSetConstantArrayIntParametersMetaField() : base(){}

		public override void UserInstantiate()
		{
			_t = typeof(igCommandSetConstantArrayIntParameters);
			igCommandSetConstantArrayIntParameters.arkRegisterCompoundFields(this._metaFields);
		}
	}
	[sizeofSize(0xFF, 0x0C, 0x18)]
	public struct igCommandSetConstantArrayFloatParameters
	{
		public static void arkRegisterCompoundFields(igMetaFieldList metaFields)
		{
			IG_CORE_PLATFORM[] emptyPlatformOverride = new IG_CORE_PLATFORM[0];

			igSizeTypeMetaField _resource = igMetaField.CreateMetaField<igSizeTypeMetaField>(0xFF, 0x00, 0x00, 0x00, "_resource", emptyPlatformOverride);
			igRawRefMetaField      _value =   igMetaField.CreateMetaField<igRawRefMetaField>(0xFF, 0x01, 0x04, 0x08,    "_value", emptyPlatformOverride);
			igIntMetaField         _count =      igMetaField.CreateMetaField<igIntMetaField>(0xFF, 0x01, 0x04, 0x08,    "_count", emptyPlatformOverride);
			metaFields.Append(_resource);
			metaFields.Append(_value);
			metaFields.Append(_count);
		}

		public ulong _resource;
		public ulong _value;
		public int _count;
	}
	public class igCommandSetConstantArrayFloatParametersMetaField : igCompoundMetaField
	{
		public override Type OutputType() => typeof(igCommandSetConstantArrayFloatParameters);

		public igCommandSetConstantArrayFloatParametersMetaField() : base(){}

		public override void UserInstantiate()
		{
			_t = typeof(igCommandSetConstantArrayFloatParameters);
			igCommandSetConstantArrayFloatParameters.arkRegisterCompoundFields(this._metaFields);
		}
	}
	[sizeofSize(0xFF, 0x0C, 0x18)]
	public struct igCommandSetConstantArrayVec4fParameters
	{
		public static void arkRegisterCompoundFields(igMetaFieldList metaFields)
		{
			IG_CORE_PLATFORM[] emptyPlatformOverride = new IG_CORE_PLATFORM[0];

			igSizeTypeMetaField _resource = igMetaField.CreateMetaField<igSizeTypeMetaField>(0xFF, 0x00, 0x00, 0x00, "_resource", emptyPlatformOverride);
			igRawRefMetaField      _value =   igMetaField.CreateMetaField<igRawRefMetaField>(0xFF, 0x01, 0x04, 0x08,    "_value", emptyPlatformOverride);
			igIntMetaField         _count =      igMetaField.CreateMetaField<igIntMetaField>(0xFF, 0x01, 0x04, 0x08,    "_count", emptyPlatformOverride);
			metaFields.Append(_resource);
			metaFields.Append(_value);
			metaFields.Append(_count);
		}

		public ulong _resource;
		public ulong _value;
		public int _count;
	}
	public class igCommandSetConstantArrayVec4fParametersMetaField : igCompoundMetaField
	{
		public override Type OutputType() => typeof(igCommandSetConstantArrayVec4fParameters);

		public igCommandSetConstantArrayVec4fParametersMetaField() : base(){}

		public override void UserInstantiate()
		{
			_t = typeof(igCommandSetConstantArrayVec4fParameters);
			igCommandSetConstantArrayVec4fParameters.arkRegisterCompoundFields(this._metaFields);
		}
	}
	[sizeofSize(0xFF, 0x0C, 0x18)]
	public struct igCommandSetConstantArrayMatrix44fParameters
	{
		public static void arkRegisterCompoundFields(igMetaFieldList metaFields)
		{
			IG_CORE_PLATFORM[] emptyPlatformOverride = new IG_CORE_PLATFORM[0];

			igSizeTypeMetaField _resource = igMetaField.CreateMetaField<igSizeTypeMetaField>(0xFF, 0x00, 0x00, 0x00, "_resource", emptyPlatformOverride);
			igRawRefMetaField      _value =   igMetaField.CreateMetaField<igRawRefMetaField>(0xFF, 0x01, 0x04, 0x08,    "_value", emptyPlatformOverride);
			igIntMetaField         _count =      igMetaField.CreateMetaField<igIntMetaField>(0xFF, 0x01, 0x04, 0x08,    "_count", emptyPlatformOverride);
			metaFields.Append(_resource);
			metaFields.Append(_value);
			metaFields.Append(_count);
		}

		public ulong _resource;
		public ulong _value;
		public int _count;
	}
	public class igCommandSetConstantArrayMatrix44fParametersMetaField : igCompoundMetaField
	{
		public override Type OutputType() => typeof(igCommandSetConstantArrayMatrix44fParameters);

		public igCommandSetConstantArrayMatrix44fParametersMetaField() : base(){}

		public override void UserInstantiate()
		{
			_t = typeof(igCommandSetConstantArrayMatrix44fParameters);
			igCommandSetConstantArrayMatrix44fParameters.arkRegisterCompoundFields(this._metaFields);
		}
	}
	[sizeofSize(0xFF, 0x04, 0x08)]
	public struct igCommandApplyConstantBundleParameters
	{
		public static void arkRegisterCompoundFields(igMetaFieldList metaFields)
		{
			IG_CORE_PLATFORM[] emptyPlatformOverride = new IG_CORE_PLATFORM[0];

			//igShaderConstantBundle
			//igObjectRefMetaField<igObject> _bundle = igMetaField.CreateMetaField<igObjectRefMetaField<igObject>>(0xFF, 0x00, 0x00, 0x00, "_bundle", emptyPlatformOverride);
			igSizeTypeMetaField _bundle = igMetaField.CreateMetaField<igSizeTypeMetaField>(0xFF, 0x00, 0x00, 0x00, "_bundle", emptyPlatformOverride);
			metaFields.Append(_bundle);
		}
		public ulong _bundle;
	}
	public class igCommandApplyConstantBundleParametersMetaField : igCompoundMetaField
	{
		public override Type OutputType() => typeof(igCommandApplyConstantBundleParameters);

		public igCommandApplyConstantBundleParametersMetaField() : base(){}

		public override void UserInstantiate()
		{
			_t = typeof(igCommandApplyConstantBundleParameters);
			igCommandApplyConstantBundleParameters.arkRegisterCompoundFields(this._metaFields);
		}
	}
	[sizeofSize(0xFF, 0x04, 0x08)]
	public struct igCommandApplyConstantValueListParameters
	{
		public static void arkRegisterCompoundFields(igMetaFieldList metaFields)
		{
			IG_CORE_PLATFORM[] emptyPlatformOverride = new IG_CORE_PLATFORM[0];

			//igShaderConstantValueList
			//igObjectRefMetaField<igObject> _list = igMetaField.CreateMetaField<igObjectRefMetaField<igObject>>(0xFF, 0x00, 0x00, 0x00, "_bundle", emptyPlatformOverride);
			igSizeTypeMetaField _list = igMetaField.CreateMetaField<igSizeTypeMetaField>(0xFF, 0x00, 0x00, 0x00, "_bundle", emptyPlatformOverride);
			metaFields.Append(_list);
		}
		public ulong _bundle;
	}
	public class igCommandApplyConstantValueListParametersMetaField : igCompoundMetaField
	{
		public override Type OutputType() => typeof(igCommandApplyConstantValueListParameters);

		public igCommandApplyConstantValueListParametersMetaField() : base(){}

		public override void UserInstantiate()
		{
			_t = typeof(igCommandApplyConstantValueListParameters);
			igCommandApplyConstantValueListParameters.arkRegisterCompoundFields(this._metaFields);
		}
	}
	[sizeofSize(0xFF, 0x08, 0x10)]
	public struct igCommandSetPixelShaderTextureEnabledConstantParameters
	{
		public static void arkRegisterCompoundFields(igMetaFieldList metaFields)
		{
			IG_CORE_PLATFORM[] emptyPlatformOverride = new IG_CORE_PLATFORM[0];

			igSizeTypeMetaField            _resource = igMetaField.CreateMetaField<igSizeTypeMetaField>    (0xFF, 0x00, 0x00, 0x00, "_resource", emptyPlatformOverride);
			igUnsignedCharMetaField        _register = igMetaField.CreateMetaField<igUnsignedCharMetaField>(0xFF, 0x01, 0x04, 0x08, "_register", emptyPlatformOverride);
			metaFields.Append(_resource);
			metaFields.Append(_register);
		}

		public ulong _resource;
		public byte _register;
	}
	public class igCommandSetPixelShaderTextureEnabledConstantParametersMetaField : igCompoundMetaField
	{
		public override Type OutputType() => typeof(igCommandSetPixelShaderTextureEnabledConstantParameters);

		public igCommandSetPixelShaderTextureEnabledConstantParametersMetaField() : base(){}

		public override void UserInstantiate()
		{
			_t = typeof(igCommandSetPixelShaderTextureEnabledConstantParameters);
			igCommandSetPixelShaderTextureEnabledConstantParameters.arkRegisterCompoundFields(this._metaFields);
		}
	}
	[sizeofSize(0xFF, 0x08, 0x10)]
	public struct igCommandSetVertexShaderTextureEnabledConstantParameters
	{
		public static void arkRegisterCompoundFields(igMetaFieldList metaFields)
		{
			IG_CORE_PLATFORM[] emptyPlatformOverride = new IG_CORE_PLATFORM[0];

			igSizeTypeMetaField            _resource = igMetaField.CreateMetaField<igSizeTypeMetaField>    (0xFF, 0x00, 0x00, 0x00, "_resource", emptyPlatformOverride);
			igUnsignedCharMetaField        _register = igMetaField.CreateMetaField<igUnsignedCharMetaField>(0xFF, 0x01, 0x04, 0x08, "_register", emptyPlatformOverride);
			metaFields.Append(_resource);
			metaFields.Append(_register);
		}

		public ulong _resource;
		public byte _register;
	}
	public class igCommandSetVertexShaderTextureEnabledConstantParametersMetaField : igCompoundMetaField
	{
		public override Type OutputType() => typeof(igCommandSetVertexShaderTextureEnabledConstantParameters);

		public igCommandSetVertexShaderTextureEnabledConstantParametersMetaField() : base(){}

		public override void UserInstantiate()
		{
			_t = typeof(igCommandSetVertexShaderTextureEnabledConstantParameters);
			igCommandSetVertexShaderTextureEnabledConstantParameters.arkRegisterCompoundFields(this._metaFields);
		}
	}
	[sizeofSize(0xFF, 0x08, 0x10)]
	public struct igCommandSetPixelShaderTextureSizeConstantParameters
	{
		public static void arkRegisterCompoundFields(igMetaFieldList metaFields)
		{
			IG_CORE_PLATFORM[] emptyPlatformOverride = new IG_CORE_PLATFORM[0];

			igSizeTypeMetaField            _resource = igMetaField.CreateMetaField<igSizeTypeMetaField>    (0xFF, 0x00, 0x00, 0x00, "_resource", emptyPlatformOverride);
			igUnsignedCharMetaField        _register = igMetaField.CreateMetaField<igUnsignedCharMetaField>(0xFF, 0x01, 0x04, 0x08, "_register", emptyPlatformOverride);
			metaFields.Append(_resource);
			metaFields.Append(_register);
		}

		public ulong _resource;
		public byte _register;
	}
	public class igCommandSetPixelShaderTextureSizeConstantParametersMetaField : igCompoundMetaField
	{
		public override Type OutputType() => typeof(igCommandSetPixelShaderTextureSizeConstantParameters);

		public igCommandSetPixelShaderTextureSizeConstantParametersMetaField() : base(){}

		public override void UserInstantiate()
		{
			_t = typeof(igCommandSetPixelShaderTextureSizeConstantParameters);
			igCommandSetPixelShaderTextureSizeConstantParameters.arkRegisterCompoundFields(this._metaFields);
		}
	}
	[sizeofSize(0xFF, 0x08, 0x10)]
	public struct igCommandSetVertexShaderTextureSizeConstantParameters
	{
		public static void arkRegisterCompoundFields(igMetaFieldList metaFields)
		{
			IG_CORE_PLATFORM[] emptyPlatformOverride = new IG_CORE_PLATFORM[0];

			igSizeTypeMetaField            _resource = igMetaField.CreateMetaField<igSizeTypeMetaField>    (0xFF, 0x00, 0x00, 0x00, "_resource", emptyPlatformOverride);
			igUnsignedCharMetaField        _register = igMetaField.CreateMetaField<igUnsignedCharMetaField>(0xFF, 0x01, 0x04, 0x08, "_register", emptyPlatformOverride);
			metaFields.Append(_resource);
			metaFields.Append(_register);
		}

		public ulong _resource;
		public byte _register;
	}
	public class igCommandSetVertexShaderTextureSizeConstantParametersMetaField : igCompoundMetaField
	{
		public override Type OutputType() => typeof(igCommandSetVertexShaderTextureSizeConstantParameters);

		public igCommandSetVertexShaderTextureSizeConstantParametersMetaField() : base(){}

		public override void UserInstantiate()
		{
			_t = typeof(igCommandSetVertexShaderTextureSizeConstantParameters);
			igCommandSetVertexShaderTextureSizeConstantParameters.arkRegisterCompoundFields(this._metaFields);
		}
	}
	[sizeofSize(0xFF, 0x1C, 0x1C)]
	public struct igCommandClearRenderTargetParameters
	{
		public static void arkRegisterCompoundFields(igMetaFieldList metaFields)
		{
			IG_CORE_PLATFORM[] emptyPlatformOverride = new IG_CORE_PLATFORM[0];

			igIntMetaField             _mode = igMetaField.CreateMetaField<igIntMetaField>         (0xFF, 0x00, 0x00, 0x00,    "_mode", emptyPlatformOverride);
			igFloatArrayMetaField     _color = igMetaField.CreateMetaField<igFloatArrayMetaField>  (0xFF, 0x01, 0x04, 0x04,   "_color", emptyPlatformOverride);
			igFloatMetaField          _depth = igMetaField.CreateMetaField<igFloatMetaField>       (0xFF, 0x02, 0x14, 0x14,   "_depth", emptyPlatformOverride);
			igUnsignedCharMetaField _stencil = igMetaField.CreateMetaField<igUnsignedCharMetaField>(0xFF, 0x03, 0x18, 0x18, "_stencil", emptyPlatformOverride);
			_color._num = 4;
			metaFields.Append(_mode);
			metaFields.Append(_color);
			metaFields.Append(_depth);
			metaFields.Append(_stencil);
		}

		public ulong _resource;
		public byte _register;
	}
	public class igCommandClearRenderTargetParametersMetaField : igCompoundMetaField
	{
		public override Type OutputType() => typeof(igCommandClearRenderTargetParameters);

		public igCommandClearRenderTargetParametersMetaField() : base(){}

		public override void UserInstantiate()
		{
			_t = typeof(igCommandClearRenderTargetParameters);
			igCommandClearRenderTargetParameters.arkRegisterCompoundFields(this._metaFields);
		}
	}
	[sizeofSize(0xFF, 0x0C, 0x0C)]
	public struct igCommandDrawPrimitivesParameters
	{
		public static void arkRegisterCompoundFields(igMetaFieldList metaFields)
		{
			IG_CORE_PLATFORM[] emptyPlatformOverride = new IG_CORE_PLATFORM[0];
			
			igEnumMetaField<IG_GFX_DRAW> _primitive = igMetaField.CreateMetaField<igEnumMetaField<IG_GFX_DRAW>>(0xFF, 0x00, 0x00, 0x00,     "_primitive", emptyPlatformOverride);
			igIntMetaField           _numPrimitives =               igMetaField.CreateMetaField<igIntMetaField>(0xFF, 0x01, 0x04, 0x04, "_numPrimitives", emptyPlatformOverride);
			igIntMetaField                  _offset =               igMetaField.CreateMetaField<igIntMetaField>(0xFF, 0x02, 0x08, 0x08,        "_offset", emptyPlatformOverride);
			metaFields.Append(_primitive);
			metaFields.Append(_numPrimitives);
			metaFields.Append(_offset);
		}

		public IG_GFX_DRAW _primitive;
		public int _numPrimitives;
		public int _offset;
	}
	public class igCommandDrawPrimitivesParametersMetaField : igCompoundMetaField
	{
		public override Type OutputType() => typeof(igCommandDrawPrimitivesParameters);

		public igCommandDrawPrimitivesParametersMetaField() : base(){}

		public override void UserInstantiate()
		{
			_t = typeof(igCommandDrawPrimitivesParameters);
			igCommandDrawPrimitivesParameters.arkRegisterCompoundFields(this._metaFields);
		}
	}
	[sizeofSize(0xFF, 0x04, 0x08)]
	public struct igCommandDecodeMemoryCommandStreamParameters
	{
		public static void arkRegisterCompoundFields(igMetaFieldList metaFields)
		{
			IG_CORE_PLATFORM[] emptyPlatformOverride = new IG_CORE_PLATFORM[0];
			
			//igObjectRefMetaField<igMemoryCommandStream> _stream = igMetaField.CreateMetaField<igObjectRefMetaField<igMemoryCommandStream>>(0xFF, 0x00, 0x00, 0x00, "_stream", emptyPlatformOverride);
			igSizeTypeMetaField _stream = igMetaField.CreateMetaField<igSizeTypeMetaField>(0xFF, 0x00, 0x00, 0x00, "_stream", emptyPlatformOverride);
			metaFields.Append(_stream);
		}

		//public igMemoryCommandStream _stream;
		public ulong _stream;
	}
	public class igCommandDecodeMemoryCommandStreamParametersMetaField : igCompoundMetaField
	{
		public override Type OutputType() => typeof(igCommandDecodeMemoryCommandStreamParameters);

		public igCommandDecodeMemoryCommandStreamParametersMetaField() : base(){}

		public override void UserInstantiate()
		{
			_t = typeof(igCommandDecodeMemoryCommandStreamParameters);
			igCommandDecodeMemoryCommandStreamParameters.arkRegisterCompoundFields(this._metaFields);
		}
	}
	[sizeofSize(0xFF, 0x28, 0x38)]
	public struct igCommandCopyTextureParameters
	{
		public static void arkRegisterCompoundFields(igMetaFieldList metaFields)
		{
			IG_CORE_PLATFORM[] emptyPlatformOverride = new IG_CORE_PLATFORM[0];
			
			igSizeTypeMetaField              _source = igMetaField.CreateMetaField<igSizeTypeMetaField>             (0xFF, 0x00, 0x00, 0x00,      "_source", emptyPlatformOverride);
			igSizeTypeMetaField         _destination = igMetaField.CreateMetaField<igSizeTypeMetaField>             (0xFF, 0x01, 0x04, 0x08, "_destination", emptyPlatformOverride);
			igCopyTextureParametersMetaField _params = igMetaField.CreateMetaField<igCopyTextureParametersMetaField>(0xFF, 0x02, 0x08, 0x10,      "_params", emptyPlatformOverride);
			metaFields.Append(_source);
			metaFields.Append(_destination);
			metaFields.Append(_params);
		}

		public ulong _source;
		public ulong _destination;
		public igCopyTextureParameters _params;
	}
	public class igCommandCopyTextureParametersMetaField : igCompoundMetaField
	{
		public override Type OutputType() => typeof(igCommandCopyTextureParameters);

		public igCommandCopyTextureParametersMetaField() : base(){}

		public override void UserInstantiate()
		{
			_t = typeof(igCommandCopyTextureParameters);
			igCommandCopyTextureParameters.arkRegisterCompoundFields(this._metaFields);
		}
	}
	[sizeofSize(0xFF, 0x04, 0x08)]
	public struct igCommandUpdateTextureParameters
	{
		public static void arkRegisterCompoundFields(igMetaFieldList metaFields)
		{
			IG_CORE_PLATFORM[] emptyPlatformOverride = new IG_CORE_PLATFORM[0];
			
			igSizeTypeMetaField        _texture = igMetaField.CreateMetaField<igSizeTypeMetaField>   (0xFF, 0x00, 0x00, 0x00,    "_texture", emptyPlatformOverride);
			igRawRefMetaField             _data = igMetaField.CreateMetaField<igRawRefMetaField>     (0xFF, 0x01, 0x04, 0x08,       "_data", emptyPlatformOverride);
			igUnsignedIntMetaField        _size = igMetaField.CreateMetaField<igUnsignedIntMetaField>(0xFF, 0x02, 0x08, 0x10,       "_size", emptyPlatformOverride);
			igUnsignedIntMetaField  _imageIndex = igMetaField.CreateMetaField<igUnsignedIntMetaField>(0xFF, 0x02, 0x0C, 0x14, "_imageIndex", emptyPlatformOverride);
			igUnsignedIntMetaField    _mipLevel = igMetaField.CreateMetaField<igUnsignedIntMetaField>(0xFF, 0x02, 0x10, 0x18,   "_mipLevel", emptyPlatformOverride);
			igUnsignedIntMetaField       _flags = igMetaField.CreateMetaField<igUnsignedIntMetaField>(0xFF, 0x02, 0x14, 0x1C,   "_mipLevel", emptyPlatformOverride);
			metaFields.Append(_texture);
			metaFields.Append(_data);
			metaFields.Append(_size);
			metaFields.Append(_imageIndex);
			metaFields.Append(_mipLevel);
			metaFields.Append(_flags);
		}
		public ulong _texture;
		public ulong _data;
		public uint _size;
		public uint _imageIndex;
		public uint _mipLevel;
		public uint _flags;
	}
	public class igCommandUpdateTextureParametersMetaField : igCompoundMetaField
	{
		public override Type OutputType() => typeof(igCommandUpdateTextureParameters);

		public igCommandUpdateTextureParametersMetaField() : base(){}

		public override void UserInstantiate()
		{
			_t = typeof(igCommandUpdateTextureParameters);
			igCommandUpdateTextureParameters.arkRegisterCompoundFields(this._metaFields);
		}
	}
	[sizeofSize(0xFF, 0x00, 0x18)]
	public struct igCommandExecuteCallbackParameters
	{
		public static void arkRegisterCompoundFields(igMetaFieldList metaFields)
		{
			IG_CORE_PLATFORM[] emptyPlatformOverride = new IG_CORE_PLATFORM[0];
			//It's a struct called _callback
		}
	}
	public class igCommandExecuteCallbackParametersMetaField : igCompoundMetaField
	{
		public override Type OutputType() => typeof(igCommandExecuteCallbackParameters);

		public igCommandExecuteCallbackParametersMetaField() : base(){}

		public override void UserInstantiate()
		{
			_t = typeof(igCommandExecuteCallbackParameters);
			igCommandExecuteCallbackParameters.arkRegisterCompoundFields(this._metaFields);
		}
	}
	[sizeofSize(0xFF, 0xD0, 0xD0)]
	public struct igCommandSetCameraMatricesParameters
	{
		public static void arkRegisterCompoundFields(igMetaFieldList metaFields)
		{
			IG_CORE_PLATFORM[] emptyPlatformOverride = new IG_CORE_PLATFORM[0];
			
			igUnsignedCharMetaField     _cameraIndex = igMetaField.CreateMetaField<igUnsignedCharMetaField>(0xFF, 0x00, 0x00, 0x00,        "_cameraIndex", emptyPlatformOverride);
			igMatrix44fMetaField         _viewMatrix =    igMetaField.CreateMetaField<igMatrix44fMetaField>(0xFF, 0x01, 0x10, 0x10,         "_viewMatrix", emptyPlatformOverride);
			igMatrix44fMetaField _previousViewMatrix =    igMetaField.CreateMetaField<igMatrix44fMetaField>(0xFF, 0x02, 0x50, 0x50, "_previousViewMatrix", emptyPlatformOverride);
			igMatrix44fMetaField         _projMatrix =    igMetaField.CreateMetaField<igMatrix44fMetaField>(0xFF, 0x03, 0x90, 0x90,         "_projMatrix", emptyPlatformOverride);
			metaFields.Append(_cameraIndex);
			metaFields.Append(_viewMatrix);
			metaFields.Append(_previousViewMatrix);
			metaFields.Append(_projMatrix);
		}
		public byte _cameraIndex;
		public byte _viewMatrix;
		public byte _previousViewMatrix;
		public byte _projMatrix;
	}
	public class igCommandSetCameraMatricesParametersMetaField : igCompoundMetaField
	{
		public override Type OutputType() => typeof(igCommandSetCameraMatricesParameters);

		public igCommandSetCameraMatricesParametersMetaField() : base(){}

		public override void UserInstantiate()
		{
			_t = typeof(igCommandSetCameraMatricesParameters);
			igCommandSetCameraMatricesParameters.arkRegisterCompoundFields(this._metaFields);
		}
	}
	[sizeofSize(0xFF, 0x0C, 0x18)]
	public struct igCommandComputeAndSetInstanceMatricesParameters
	{
		public static void arkRegisterCompoundFields(igMetaFieldList metaFields)
		{
			IG_CORE_PLATFORM[] emptyPlatformOverride = new IG_CORE_PLATFORM[0];
			
			igRawRefMetaField            _modelMatrix =        igMetaField.CreateMetaField<igRawRefMetaField>(0xFF, 0x00, 0x00, 0x00,     "_modelMatrix", emptyPlatformOverride);
			igRawRefMetaField        _prevModelMatrix =        igMetaField.CreateMetaField<igRawRefMetaField>(0xFF, 0x01, 0x04, 0x08, "_prevModelMatrix", emptyPlatformOverride);
			igUnsignedShortMetaField _matrixConstants = igMetaField.CreateMetaField<igUnsignedShortMetaField>(0xFF, 0x02, 0x08, 0x10, "_matrixConstants", emptyPlatformOverride);
			igUnsignedCharMetaField      _cameraIndex =  igMetaField.CreateMetaField<igUnsignedCharMetaField>(0xFF, 0x03, 0x0A, 0x12,     "_cameraIndex", emptyPlatformOverride);
			metaFields.Append(_modelMatrix);
			metaFields.Append(_prevModelMatrix);
			metaFields.Append(_matrixConstants);
			metaFields.Append(_cameraIndex);
		}

		public ulong _modelMatrix;
		public ulong _prevModelMatrix;
		public ushort _matrixConstants;
		public byte _cameraIndex;
	}
	public class igCommandComputeAndSetInstanceMatricesParametersMetaField : igCompoundMetaField
	{
		public override Type OutputType() => typeof(igCommandComputeAndSetInstanceMatricesParameters);

		public igCommandComputeAndSetInstanceMatricesParametersMetaField() : base(){}

		public override void UserInstantiate()
		{
			_t = typeof(igCommandComputeAndSetInstanceMatricesParameters);
			igCommandComputeAndSetInstanceMatricesParameters.arkRegisterCompoundFields(this._metaFields);
		}
	}
	[sizeofSize(0xFF, 0x04, 0x04)]
	public struct igCommandComputeAndSetInstanceConstantsParameters
	{
		public static void arkRegisterCompoundFields(igMetaFieldList metaFields)
		{
			IG_CORE_PLATFORM[] emptyPlatformOverride = new IG_CORE_PLATFORM[0];
			
			igUnsignedCharMetaField   _effectFlags = igMetaField.CreateMetaField<igUnsignedCharMetaField>(0xFF, 0x00, 0x00, 0x00,   "_effectFlags", emptyPlatformOverride);
			igUnsignedCharMetaField _geometryFlags = igMetaField.CreateMetaField<igUnsignedCharMetaField>(0xFF, 0x01, 0x01, 0x02, "_geometryFlags", emptyPlatformOverride);
			metaFields.Append(_effectFlags);
			metaFields.Append(_geometryFlags);
		}
		public byte _effectFlags;
		public byte _geometryFlags;
	}
	public class igCommandComputeAndSetInstanceConstantsParametersMetaField : igCompoundMetaField
	{
		public override Type OutputType() => typeof(igCommandComputeAndSetInstanceConstantsParameters);

		public igCommandComputeAndSetInstanceConstantsParametersMetaField() : base(){}

		public override void UserInstantiate()
		{
			_t = typeof(igCommandComputeAndSetInstanceConstantsParameters);
			igCommandComputeAndSetInstanceConstantsParameters.arkRegisterCompoundFields(this._metaFields);
		}
	}
	[sizeofSize(0xFF, 0x04, 0x04)]
	public struct igCommandSetCommonRenderStateParameters
	{
		public static void arkRegisterCompoundFields(igMetaFieldList metaFields)
		{
			IG_CORE_PLATFORM[] emptyPlatformOverride = new IG_CORE_PLATFORM[0];
			
			igUnsignedShortMetaField _commonRenderState = igMetaField.CreateMetaField<igUnsignedShortMetaField>(0xFF, 0x00, 0x00, 0x00, "_commonRenderState", emptyPlatformOverride);
			metaFields.Append(_commonRenderState);
		}
		public ushort _commonRenderState;
	}
	public class igCommandSetCommonRenderStateParametersMetaField : igCompoundMetaField
	{
		public override Type OutputType() => typeof(igCommandSetCommonRenderStateParameters);

		public igCommandSetCommonRenderStateParametersMetaField() : base(){}

		public override void UserInstantiate()
		{
			_t = typeof(igCommandSetCommonRenderStateParameters);
			igCommandSetCommonRenderStateParameters.arkRegisterCompoundFields(this._metaFields);
		}
	}
	[sizeofSize(0xFF, 0x08, 0x08)]
	public struct igCommandSetDitherStateParameters
	{
		public static void arkRegisterCompoundFields(igMetaFieldList metaFields)
		{
			IG_CORE_PLATFORM[] emptyPlatformOverride = new IG_CORE_PLATFORM[0];
			
			igBoolMetaField        _enabled =  igMetaField.CreateMetaField<igBoolMetaField>(0xFF, 0x00, 0x00, 0x00,       "_enabled", emptyPlatformOverride);
			igFloatMetaField _ditherOpacity = igMetaField.CreateMetaField<igFloatMetaField>(0xFF, 0x01, 0x04, 0x04, "_ditherOpacity", emptyPlatformOverride);
			metaFields.Append(_enabled);
			metaFields.Append(_ditherOpacity);
		}
		public bool _enabled;
		public float _ditherOpacity;
	}
	public class igCommandSetDitherStateParametersMetaField : igCompoundMetaField
	{
		public override Type OutputType() => typeof(igCommandSetDitherStateParameters);

		public igCommandSetDitherStateParametersMetaField() : base(){}

		public override void UserInstantiate()
		{
			_t = typeof(igCommandSetDitherStateParameters);
			igCommandSetDitherStateParameters.arkRegisterCompoundFields(this._metaFields);
		}
	}
	[sizeofSize(0xFF, 0x04, 0x08)]
	public struct igCommandBeginNamedEventParameters
	{
		public static void arkRegisterCompoundFields(igMetaFieldList metaFields)
		{
			IG_CORE_PLATFORM[] emptyPlatformOverride = new IG_CORE_PLATFORM[0];
			
			igStringMetaField _name = igMetaField.CreateMetaField<igStringMetaField>(0xFF, 0x00, 0x00, 0x00, "_name", emptyPlatformOverride);
			metaFields.Append(_name);
		}
		public string _name;
	}
	public class igCommandBeginNamedEventParametersMetaField : igCompoundMetaField
	{
		public override Type OutputType() => typeof(igCommandBeginNamedEventParameters);

		public igCommandBeginNamedEventParametersMetaField() : base(){}

		public override void UserInstantiate()
		{
			_t = typeof(igCommandBeginNamedEventParameters);
			igCommandBeginNamedEventParameters.arkRegisterCompoundFields(this._metaFields);
		}
	}
	[sizeofSize(0xFF, 0x04, 0x04)]
	public struct igCommandEndNamedEventParameters
	{
		public static void arkRegisterCompoundFields(igMetaFieldList metaFields)
		{
			IG_CORE_PLATFORM[] emptyPlatformOverride = new IG_CORE_PLATFORM[0];
			
			igIntMetaField _count =  igMetaField.CreateMetaField<igIntMetaField>(0xFF, 0x00, 0x00, 0x00, "_count", emptyPlatformOverride);
			metaFields.Append(_count);
		}
		public int _count;
	}
	public class igCommandEndNamedEventParametersMetaField : igCompoundMetaField
	{
		public override Type OutputType() => typeof(igCommandEndNamedEventParameters);

		public igCommandEndNamedEventParametersMetaField() : base(){}

		public override void UserInstantiate()
		{
			_t = typeof(igCommandEndNamedEventParameters);
			igCommandEndNamedEventParameters.arkRegisterCompoundFields(this._metaFields);
		}
	}
	[sizeofSize(0xFF, 0x04, 0x08)]
	public struct igCommandIssueBufferedGpuTimestampParameters
	{
		public static void arkRegisterCompoundFields(igMetaFieldList metaFields)
		{
			IG_CORE_PLATFORM[] emptyPlatformOverride = new IG_CORE_PLATFORM[0];
			
			//igBufferedGpuTimestamp
			//igObjectRefMetaField<igObject> _timestamp =  igMetaField.CreateMetaField<igObjectRefMetaField<igObject>>(0xFF, 0x00, 0x00, 0x00, "_timestamp", emptyPlatformOverride);
			igSizeTypeMetaField _timestamp =  igMetaField.CreateMetaField<igSizeTypeMetaField>(0xFF, 0x00, 0x00, 0x00, "_timestamp", emptyPlatformOverride);
			metaFields.Append(_timestamp);
		}
		//public igObject _timestamp;
		public ulong _timestamp;
	}
	public class igCommandIssueBufferedGpuTimestampParametersMetaField : igCompoundMetaField
	{
		public override Type OutputType() => typeof(igCommandIssueBufferedGpuTimestampParameters);

		public igCommandIssueBufferedGpuTimestampParametersMetaField() : base(){}

		public override void UserInstantiate()
		{
			_t = typeof(igCommandIssueBufferedGpuTimestampParameters);
			igCommandIssueBufferedGpuTimestampParameters.arkRegisterCompoundFields(this._metaFields);
		}
	}

}