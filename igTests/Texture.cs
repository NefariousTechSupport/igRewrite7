namespace igRewrite7
{
	public class Texture
	{
		public int textureId;

		/*public unsafe Texture(CTexture ctex)
		{
			textureId = GL.GenTexture();

			GL.ActiveTexture(TextureUnit.Texture0);
			GL.BindTexture(TextureTarget.Texture2D, textureId);

			fixed (byte* b = ctex.data)
			{
				uint offset = 0;
				for(int i = 0; i < ctex.mipmapCount; i++)
				{
					if(ctex.format == CTexture.TexFormat.DXT1)
					{
						int size = (Math.Max( 1, ((ctex.width / (int)Math.Pow(2, i))+3)/4) * Math.Max(1, ((ctex.height / (int)Math.Pow(2, i)) +3)/4)) * 8;
						GL.CompressedTexImage2D(TextureTarget.Texture2D, i, InternalFormat.CompressedRgbS3tcDxt1Ext, ctex.width, ctex.height, 0, size, (IntPtr)(b + offset));
						offset += (uint)size;
					}
					else if (ctex.format == CTexture.TexFormat.DXT3)
					{
						int size = (Math.Max( 1, ((ctex.width / (int)Math.Pow(2, i))+3)/4) * Math.Max(1, ((ctex.height / (int)Math.Pow(2, i)) +3)/4)) * 16;
						GL.CompressedTexImage2D(TextureTarget.Texture2D, i, InternalFormat.CompressedRgbaS3tcDxt3Ext, ctex.width, ctex.height, 0, size, (IntPtr)(b + offset));
						offset += (uint)size;
					}
					else if (ctex.format == CTexture.TexFormat.DXT5)
					{
						int size = (Math.Max( 1, ((ctex.width / (int)Math.Pow(2, i))+3)/4) * Math.Max(1, ((ctex.height / (int)Math.Pow(2, i)) +3)/4)) * 16;
						GL.CompressedTexImage2D(TextureTarget.Texture2D, i, InternalFormat.CompressedRgbaS3tcDxt5Ext, ctex.width, ctex.height, 0, size, (IntPtr)(b + offset));
						offset += (uint)size;
					}
				}					
			}

            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.Repeat);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureWrapMode.Repeat);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.LinearMipmapLinear);

			GL.GenerateMipmap(GenerateMipmapTarget.Texture2D);

			GL.BindTexture(TextureTarget.Texture2D, 0);
		}*/

		//Could use the convert to rgba function for all formats but i wanted textures decompressed on the gpu
		public unsafe Texture(igImage2 image)
		{
			textureId = GL.GenTexture();

			GL.ActiveTexture(TextureUnit.Texture0);
			GL.BindTexture(TextureTarget.Texture2D, textureId);
			
			if(image._format == null)
			{
				Console.WriteLine($"{image._name} has Unsupported Texture Format");
				return;
			}

			igMetaImage.SimpleMetaImageFormat format = image._format.GetSimpleMetaImageFormat();

			uint offset = 0;
			int width = image._width;
			int height = image._height;
			int size = 0;
			InternalFormat compressedFormat = InternalFormat.Srgb;	//This is a default value
			bool useCompression = image._format._isCompressed;

			fixed(byte* b = image._data.buffer)
			{
				for(int i = 0; i < 1; i++)
				{
					byte[]? uncompressedRGBAData = null;
					switch(format)
					{
						case igMetaImage.SimpleMetaImageFormat.DXT1:
						case igMetaImage.SimpleMetaImageFormat.DXT1_SWIZZLE_WII:
						case igMetaImage.SimpleMetaImageFormat.DXT1_SWIZZLE_WIIU:
							size = (int)(Math.Max( 1, ((width+3)/4) ) * Math.Max(1, ( (height + 3) / 4 ) )) * 8;
							if(image._format._isSrgb) compressedFormat = InternalFormat.CompressedSrgbS3tcDxt1Ext;
							else                      compressedFormat = InternalFormat.CompressedRgbS3tcDxt1Ext;
							break;
						case igMetaImage.SimpleMetaImageFormat.DXT3:
						case igMetaImage.SimpleMetaImageFormat.DXT3_SWIZZLE_WIIU:
							size = (int)(Math.Max( 1, ((width+3)/4) ) * Math.Max(1, ( (height + 3) / 4 ) )) * 16;
							if(image._format._isSrgb) compressedFormat = InternalFormat.CompressedSrgbAlphaS3tcDxt3Ext;
							else                      compressedFormat = InternalFormat.CompressedRgbaS3tcDxt3Ext;
							break;
						case igMetaImage.SimpleMetaImageFormat.DXT5:
						case igMetaImage.SimpleMetaImageFormat.DXT5_SWIZZLE_WIIU:
							size = (int)(Math.Max( 1, ((width+3)/4) ) * Math.Max(1, ( (height + 3) / 4 ) )) * 16;
							if(image._format._isSrgb) compressedFormat = InternalFormat.CompressedSrgbAlphaS3tcDxt5Ext;
							else                      compressedFormat = InternalFormat.CompressedRgbaS3tcDxt5Ext;
							break;
						case igMetaImage.SimpleMetaImageFormat.PVRTC2:
						case igMetaImage.SimpleMetaImageFormat.PVRTC4:
							uncompressedRGBAData = image.ConvertToRGBA();
							useCompression = false;
							break;
						default:
							throw new Exception("invalid SimpleMetaImageFormat");
					}

					if(useCompression)
					{
						if(compressedFormat == InternalFormat.Srgb) throw new Exception();
						GL.CompressedTexImage2D(TextureTarget.Texture2D, i, compressedFormat, width, height, 0, size, (IntPtr)(b + offset));
					}
					else
					{
						if(image._format._isSrgb)
						{
							GL.TexImage2D(TextureTarget.Texture2D, i, PixelInternalFormat.Srgb8Alpha8, image._width, image._height, 0, PixelFormat.Rgba, PixelType.UnsignedByte, uncompressedRGBAData);
						}
						else
						{
							GL.TexImage2D(TextureTarget.Texture2D, i, PixelInternalFormat.Rgba, image._width, image._height, 0, PixelFormat.Rgba, PixelType.UnsignedByte, uncompressedRGBAData);
						}
					}

					offset += (uint)size;
				}
			}

            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.Repeat);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureWrapMode.Repeat);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.LinearMipmapLinear);

			GL.GenerateMipmap(GenerateMipmapTarget.Texture2D);

			GL.BindTexture(TextureTarget.Texture2D, 0);
		}

		public void Use()
		{
			GL.ActiveTexture(TextureUnit.Texture0);
			GL.BindTexture(TextureTarget.Texture2D, textureId);
		}
	}
}