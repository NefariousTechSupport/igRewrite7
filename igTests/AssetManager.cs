namespace igRewrite7
{
	public class AssetManager
	{
		static Lazy<AssetManager> lazy = new Lazy<AssetManager>(() => new AssetManager());
		public static AssetManager Singleton => lazy.Value;

		//igObjectDirectory name hash or file offset -> asset
		public Dictionary<uint, IDrawableCommon> drawables = new Dictionary<uint, IDrawableCommon>();

		// (igHandleName._ns._hash << 32) | (igHandleName._name._hash) -> asset
		public Dictionary<ulong, Texture> textures = new Dictionary<ulong, Texture>();
		public Dictionary<ulong, Material> materials = new Dictionary<ulong, Material>();

		public IDrawableCommon LoadDrawable(string path, bool isActor)
		{
			if(string.IsNullOrEmpty(path) || path == "metaobject") return null;

			string internalPath = $"{(isActor ? "actors" : "models")}:/{path}.igz";
			igObjectDirectory meshDir = igObjectStreamManager.Singleton.Load(internalPath);
			if(drawables.ContainsKey(meshDir._name._hash)) return drawables[meshDir._name._hash];
			IDrawableCommon drawable;
			if(meshDir._objectList[0] is igModelInfo mi) drawable = new CDrawableList(mi);
			else if(meshDir._objectList[1] is CGraphicsSkinInfo gsi) drawable = new CDrawableList(gsi);
			else throw new NotImplementedException($"mesh type at {internalPath} not implemented");
			drawables.Add(meshDir._name._hash, drawable);
			return drawable;
		}
		public Texture? LoadTexture(igHandle handle)
		{
			if(handle._handleName._ns._hash == 0 || handle._handleName._name._hash == 0) return null;

			ulong key = (handle._handleName._ns._hash << 32) | handle._handleName._name._hash;

			if(textures.ContainsKey(key)) return textures[key];

			igImage2? image = handle.GetObject<igImage2>();
			Texture tex;
			if(image != null && image._format != null)
			{
				tex = new Texture(image);
			}
			else
			{
				if(image == null) Console.WriteLine($"Failed to load igImage2 from ns {handle._handleName._ns._string}");
				else if(image._format == null) Console.WriteLine($"Failed to load format for igImage2 from ns {handle._handleName._ns._string}");
				tex = null;
			}
			textures.Add(key, tex);
			return tex;
		}
		public Material LoadMaterial(igHandle handle)
		{
			ulong key = (handle._handleName._ns._hash << 32) | handle._handleName._name._hash;

			if(materials.ContainsKey(key)) return materials[key];

			igGraphicsMaterial? graphicsMaterial = handle.GetObject<igGraphicsMaterial>();

			Material glMaterial;

			if(graphicsMaterial == null)
			{
				glMaterial = new Material(MaterialManager.materials["stdv;ulitf"], null, PrimitiveType.Triangles);
			}
			else
			{
				glMaterial = new Material(MaterialManager.materials["stdv;ulitf"], graphicsMaterial);
			}

			materials.Add(key, glMaterial);

			return glMaterial;
		}
		public void ConsolidateDrawables()
		{
			foreach(KeyValuePair<uint, IDrawableCommon> drawable in drawables)
			{
				drawable.Value.ConsolidateDrawCalls();
			}
		}
		public void Render()
		{
			foreach(KeyValuePair<uint, IDrawableCommon> drawable in drawables)
			{
				drawable.Value.Draw();
			}
		}
	}
}