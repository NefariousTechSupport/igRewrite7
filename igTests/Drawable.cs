namespace igRewrite7
{
	//Buffers are split up due to how not all vertex attributes are currently known.
	//Creating one single buffer structure where the data is interweaved could lead to issues with excess memory usage for meshes where those extra vertex attributes aren't in use.
	//One example of such is blending, only some moby meshes have this and it would be a waste of memory to store this for ties, zone meshes, and shrubs.
	public class CDrawable : IDrawableCommon
	{
		public List<Transform> transforms = new List<Transform>();
		struct VertexAttribute
		{
			public int VBO;
			public bool enabled;
			public IG_VERTEX_USAGE usage;
			public uint index;
		}
		List<VertexAttribute> attributes = new List<VertexAttribute>();
		int VwBO;
		int VAO;
		int EBO;
		int indexCount;
		Material material;

		public CDrawable()
		{
			Prepare();
		}
		public CDrawable(igGraphicsVertexBuffer gvb, igGraphicsIndexBuffer gib)
		{
			Prepare();

			gvb.GetBuffer(out float[]? vPositions, IG_VERTEX_USAGE.POSITION);
			gvb.GetBuffer(out float[]? vTexCoords, IG_VERTEX_USAGE.TEXCOORD);
			gvb.GetBuffer(out float[]? vColours, IG_VERTEX_USAGE.COLOR);
			gib.GetBuffer(out uint[] indices);

			if(vPositions != null) SetVertexPositions(vPositions);
			if(vTexCoords != null) SetVertexTexCoords(vTexCoords);
			if(vColours != null)   SetVertexColours(vColours);
			SetIndices(indices);
			//SetMaterial(new Material(MaterialManager.materials["stdv;whitef"]));
		}

		public void Prepare()
		{
			VAO = GL.GenVertexArray();
			EBO = GL.GenBuffer();
		}

		public void SetIndices(uint[] indices)
		{
			GL.BindVertexArray(VAO);
			GL.BindBuffer(BufferTarget.ElementArrayBuffer, EBO);
			GL.BufferData(BufferTarget.ElementArrayBuffer, indices.Length * sizeof(uint), indices, BufferUsageHint.StaticDraw);
			indexCount = indices.Length;
		}

		//It goes:
		//	0: vertex positions  (3 floats)
		//	1: vertex tex coords (2 floats)
		public void SetVertexPositions(float[] vpositions)
		{
			VertexAttribute attr = new VertexAttribute();
			attr.usage = IG_VERTEX_USAGE.POSITION;
			attr.index = 0;
			attr.enabled = true;
			attr.VBO = GL.GenBuffer();

			GL.BindBuffer(BufferTarget.ArrayBuffer, attr.VBO);
			GL.BufferData(BufferTarget.ArrayBuffer, vpositions.Length * sizeof(float), vpositions, BufferUsageHint.StaticDraw);

			GL.BindVertexArray(VAO);
			GL.VertexAttribPointer(attr.index, 4, VertexAttribPointerType.Float, false, 4 * sizeof(float), 0);
			GL.EnableVertexAttribArray(attr.index);

			attributes.Add(attr);
		}
		public void SetVertexTexCoords(float[] vtexcoords)
		{
			VertexAttribute attr = new VertexAttribute();
			attr.usage = IG_VERTEX_USAGE.TEXCOORD;
			attr.index = 1;
			attr.enabled = true;
			attr.VBO = GL.GenBuffer();

			GL.BindBuffer(BufferTarget.ArrayBuffer, attr.VBO);
			GL.BufferData(BufferTarget.ArrayBuffer, vtexcoords.Length * sizeof(float), vtexcoords, BufferUsageHint.StaticDraw);

			GL.BindVertexArray(VAO);
			GL.VertexAttribPointer(attr.index, 4, VertexAttribPointerType.Float, false, 4 * sizeof(float), 0);
			GL.EnableVertexAttribArray(attr.index);

			attributes.Add(attr);
		}
		public void SetVertexColours(float[] vcolours)
		{
			VertexAttribute attr = new VertexAttribute();
			attr.usage = IG_VERTEX_USAGE.COLOR;
			attr.index = 2;
			attr.enabled = true;
			attr.VBO = GL.GenBuffer();

			GL.BindBuffer(BufferTarget.ArrayBuffer, attr.VBO);
			GL.BufferData(BufferTarget.ArrayBuffer, vcolours.Length * sizeof(float), vcolours, BufferUsageHint.StaticDraw);

			GL.BindVertexArray(VAO);
			GL.VertexAttribPointer(attr.index, 4, VertexAttribPointerType.Float, false, 4 * sizeof(float), 0);
			GL.EnableVertexAttribArray(attr.index);

			attributes.Add(attr);
		}
		public void SetMaterial(Material mat)
		{
			material = mat;
		}

		public void AddDrawCall(Transform transform)
		{
			transforms.Add(transform);
		}

		public void ConsolidateDrawCalls()
		{
			Matrix4[] transformMatrices = new Matrix4[transforms.Count];
			for(int i = 0; i < transformMatrices.Length; i++)
			{
				transformMatrices[i] = Matrix4.Transpose(transforms[i].GetLocalToWorldMatrix());
			}

			VwBO = GL.GenBuffer();
			GL.BindBuffer(BufferTarget.ArrayBuffer, VwBO);
			GL.BufferData(BufferTarget.ArrayBuffer, transformMatrices.Length * sizeof(float) * 16, transformMatrices, BufferUsageHint.DynamicDraw);	//Note: this should be edited in the future so things can be moved
			
			GL.BindVertexArray(VAO);

			for(int i = 0; i < 4; i++)
			{
				GL.VertexAttribPointer(4+i, 4, VertexAttribPointerType.Float, false, sizeof(float) * 16, sizeof(float) * 4 * i);
				GL.VertexAttribDivisor(4+i, 1);
				GL.EnableVertexAttribArray(4+i);
			}
		}

		public void Draw()
		{
			material.Use();
			material.SetMatrix4x4("worldToClip", Camera.WorldToView * Camera.ViewToClip);

			GL.BindVertexArray(VAO);
			GL.DrawElementsInstanced(PrimitiveType.Triangles, indexCount, DrawElementsType.UnsignedInt, IntPtr.Zero, transforms.Count);
		}

		public void Draw(Transform transform)
		{
			material.Use();
			material.SetMatrix4x4("world", transform.GetLocalToWorldMatrix() * Camera.WorldToView * Camera.ViewToClip);

			int index = attributes.FindIndex(x => x.usage == IG_VERTEX_USAGE.COLOR);
			material.SetBool("useVColour", index >= 0);

			GL.BindVertexArray(VAO);
			GL.DrawElements(PrimitiveType.Triangles, indexCount, DrawElementsType.UnsignedInt, IntPtr.Zero);
		}

		public void SimpleDraw()
		{
			material.SimpleUse();
			GL.BindVertexArray(VAO);
			GL.DrawElements(PrimitiveType.Triangles, indexCount, DrawElementsType.UnsignedInt, IntPtr.Zero);
		}

		public void UpdateTransform(Transform transform)
		{
			int index = transforms.FindIndex(0, transforms.Count, x => x == transform);

			GL.BindBuffer(BufferTarget.ArrayBuffer, VwBO);
			Matrix4[] matrix = new Matrix4[1] { Matrix4.Transpose(transform.GetLocalToWorldMatrix()) };
			
			GL.BufferSubData(BufferTarget.ArrayBuffer, (IntPtr)(sizeof(float) * 16 * index), sizeof(float) * 16, matrix);
		}
	}

	public class CDrawableList : List<CDrawable>, IDrawableCommon
	{
		public CDrawableList(igModelDrawCallData mdcd)
		{
			if(mdcd._platformData == null)
			{
				CDrawable drawable = new CDrawable(mdcd._graphicsVertexBuffer, mdcd._graphicsIndexBuffer);
				igGraphicsMaterial? gm = mdcd._materialHandle.GetObject<igGraphicsMaterial>();
				if(gm == null)
				{
					drawable.SetMaterial(new Material(MaterialManager.materials["stdv;ulitf"], null, PrimitiveType.Triangles));
				}
				else
				{
					drawable.SetMaterial(new Material(MaterialManager.materials["stdv;ulitf"], mdcd._materialHandle.GetObject<igGraphicsMaterial>()));
				}
				this.Add(drawable);
			}
			else throw new NotImplementedException("UNSUPPORTED GFX PLATFORM");
		}

		public void AddDrawCall(Transform transform)
		{
			for(int i = 0; i < Count; i++)
			{
				this[i].AddDrawCall(transform);
			}
		}
		public void ConsolidateDrawCalls()
		{
			for(int i = 0; i < Count; i++)
			{
				this[i].ConsolidateDrawCalls();
			}
		}

		public void Draw()
		{
			for(int i = 0; i < Count; i++)
			{
				this[i].Draw();
			}
		}

		public void Draw(Transform transform)
		{
			for(int i = 0; i < Count; i++)
			{
				this[i].Draw(transform);
			}
		}

		public void UpdateTransform(Transform transform)
		{
			for(int i = 0; i < Count; i++)
			{
				this[i].UpdateTransform(transform);
			}
		}
	}

	public class CDrawableListList : List<CDrawableList>, IDrawableCommon
	{
		public CDrawableListList(igModelInfo mi)
		{
			for(int i = 0; i < mi._modelData._drawCalls.Count; i++)
			{
				this.Add(new CDrawableList(mi._modelData._drawCalls[i]));
			}
		}
		public CDrawableListList(CGraphicsSkinInfo gsi)
		{
			for(int i = 0; i < gsi._skin._drawCalls.Count; i++)
			{
				this.Add(new CDrawableList(gsi._skin._drawCalls[i]));
			}
		}

		public void AddDrawCall(Transform transform)
		{
			for(int i = 0; i < Count; i++)
			{
				this[i].AddDrawCall(transform);
			}
		}
		public void ConsolidateDrawCalls()
		{
			for(int i = 0; i < Count; i++)
			{
				this[i].ConsolidateDrawCalls();
			}
		}
		public void Draw()
		{
			for(int i = 0; i < Count; i++)
			{
				this[i].Draw();
			}
		}
		public void Draw(Transform transform)
		{
			for(int i = 0; i < Count; i++)
			{
				this[i].Draw(transform);
			}
		}
		public void UpdateTransform(Transform transform)
		{
			for(int i = 0; i < Count; i++)
			{
				this[i].UpdateTransform(transform);
			}
		}
	}
	public interface IDrawableCommon
	{
		public void AddDrawCall(Transform transform);
		public void ConsolidateDrawCalls();
		public void Draw();
		public void Draw(Transform transform);
		public void UpdateTransform(Transform transform);
	}
}