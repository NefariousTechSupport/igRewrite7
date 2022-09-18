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

		public unsafe Texture(igImage2 image)
		{
			textureId = GL.GenTexture();

			GL.ActiveTexture(TextureUnit.Texture0);
			GL.BindTexture(TextureTarget.Texture2D, textureId);
			
			byte[]? data = image.ConvertToRGBA();
			if(data == null)
			{
				Console.WriteLine($"{image._name} has Unsupported Texture Format");
				return;
			}

			//File.WriteAllBytes(image._name, data);

			fixed(byte* b = data)
			{
				uint offset = 0;
				for(int i = 0; i < 1; i++)
				{
					if(image._format._isSrgb)
					{
						GL.TexImage2D(TextureTarget.Texture2D, i, PixelInternalFormat.Srgb8Alpha8, image._width, image._height, 0, PixelFormat.Rgba, PixelType.UnsignedByte, (IntPtr)(b + offset));
					}
					else
					{
						GL.TexImage2D(TextureTarget.Texture2D, i, PixelInternalFormat.Rgba, image._width, image._height, 0, PixelFormat.Rgba, PixelType.UnsignedByte, (IntPtr)(b + offset));
					}
					offset += (uint)(image._width * image._height * 4);
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