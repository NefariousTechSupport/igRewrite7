namespace igRewrite7
{
	public class AssetManager
	{
		static Lazy<AssetManager> lazy = new Lazy<AssetManager>(() => new AssetManager());
		public static AssetManager Singleton => lazy.Value;

		public List<AssetPackage> packages = new List<AssetPackage>();

		public AssetPackage AddPackage(string packagePath)
		{
			return AddPackage(igObjectStreamManager.Singleton.Load(packagePath));
		}
		public AssetPackage AddPackage(igObjectDirectory packageDir)
		{
			AssetPackage pkg = new AssetPackage();
			packages.Add(pkg);
			pkg.LoadAssets(packageDir);
			return pkg;
		}

		public IDrawableCommon LoadDrawable(string path, bool isActor)
		{
			if(string.IsNullOrEmpty(path) || path == "metaobject") return null;

			string internalPath = $"{(isActor ? "actors" : "models")}:/{path}.igz";
			igObjectDirectory meshDir = igObjectStreamManager.Singleton.Load(internalPath);

			for(int i = 0; i < packages.Count; i++)
			{
				if(packages[i].drawables.ContainsKey(meshDir._name._hash)) return packages[i].drawables[meshDir._name._hash];
			}

			throw new KeyNotFoundException($"{(isActor ? "Actor" : "Model")} not loaded");
		}
		public Texture? LoadTexture(igHandle handle)
		{
			if(handle._handleName._ns._hash == 0 || handle._handleName._name._hash == 0) return null;

			ulong key = GenerateKeyFromHandle(handle);

			if(key == 0) return null;

			for(int i = 0; i < packages.Count; i++)
			{
				if(packages[i].textures.ContainsKey(key)) return packages[i].textures[key];
			}

			throw new KeyNotFoundException("Texture not loaded");
		}
		public Material LoadMaterial(igHandle handle)
		{
			ulong key = GenerateKeyFromHandle(handle);

			if(key == 0) return null;

			for(int i = 0; i < packages.Count; i++)
			{
				if(packages[i].materials.ContainsKey(key)) return packages[i].materials[key];
			}

			return new Material(MaterialManager.materials["stdv;ulitf"], null, PrimitiveType.Triangles);
			throw new KeyNotFoundException("Material not loaded");
		}

		public static ulong GenerateKeyFromHandle(igHandle handle)
		{
			return ((ulong)handle._handleName._ns._hash << 32) | handle._handleName._name._hash;
		}
	}
}