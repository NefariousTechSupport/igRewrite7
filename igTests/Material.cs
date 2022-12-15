namespace igRewrite7
{
	public class Material
	{
		public int programId;
		Texture? albedo;
		public PrimitiveType drawType;
		public uint numUsing = 0;
		private igCommandStreamDecoder? decoder;
		private igCommandStream? stateStream;

		Dictionary<string, int> uniforms = new Dictionary<string, int>();

		public Material(int handle, Texture? albedo = null, PrimitiveType primitiveType = PrimitiveType.Triangles)
		{
			this.albedo = albedo;
			this.programId = handle;
			this.drawType = primitiveType;
		}

		public Material(int handle, igGraphicsMaterial material)
		{
			this.programId = handle;
			this.drawType = PrimitiveType.Triangles;
			this.stateStream = material._commonState;

			if(material._graphicsObjects._objects.Any(x => x is igGraphicsTexture))
			{
				igGraphicsTexture tex = (igGraphicsTexture)material._graphicsObjects._objects.First(x => x is igGraphicsTexture);
				this.albedo = AssetManager.Singleton.LoadTexture(tex._imageHandle);
			}
			else
			{
				this.albedo = null;
			}

			if(stateStream != null) decoder = new igCommandStreamDecoder();
		}

		public void Use()
		{
			SimpleUse();
			SetFloat4("tint", Vector4.One);
			if(decoder != null && stateStream != null)
			{
				decoder.Decode(stateStream);
			}
			if(albedo != null)
			{
				albedo.Use();
				SetInt("albedo", 0);
				SetBool("useTexture", true);
			}
			else
			{
				SetBool("useTexture", false);
			}
		}
		public void SimpleUse()
		{
			GL.UseProgram(programId);
		}

		public void SetMatrix4x4(string name, Matrix4 data) => GL.UniformMatrix4(GetUniformLocation(name), true, ref data);

		public void SetBool(string name, bool data) => SetInt(name, data ? 1 : 0);

		public void SetFloat(string name, float data) => GL.Uniform1(GetUniformLocation(name), data);
		public void SetFloat4(string name, Vector4 data) => GL.Uniform4(GetUniformLocation(name), data);
		public void SetInt(string name, int data) => GL.Uniform1(GetUniformLocation(name), data);

		private int GetUniformLocation(string name)
		{
			if(!uniforms.ContainsKey(name))
			{
				uniforms.Add(name, GL.GetUniformLocation(programId, name));
			}
			return uniforms[name];
		}

		public void Dispose()
		{
			GL.DeleteProgram(programId);
		}
	}
}