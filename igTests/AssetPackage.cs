namespace igRewrite7
{
	public class AssetPackage
	{
		//igObjectDirectory name hash or file offset -> asset
		public Dictionary<uint, IDrawableCommon> drawables = new Dictionary<uint, IDrawableCommon>();

		// (igHandleName._ns._hash << 32) | (igHandleName._name._hash) -> asset
		public Dictionary<ulong, Texture> textures = new Dictionary<ulong, Texture>();
		public Dictionary<ulong, Material> materials = new Dictionary<ulong, Material>();
		public Dictionary<uint, AssetPackage> packages = new Dictionary<uint, AssetPackage>();

		public string name;

		public AssetPackage(){}
		public void LoadAssets(igObjectDirectory package)
		{
			name = package._name._string;
			igStringRefList stringRefs = package._objectList[0] as igStringRefList;

			if(stringRefs == null) throw new InvalidOperationException($"Directory {package._path} is not a package");

			List<string> test = new List<string>();

			for(int i = 0; i < stringRefs._count; i += 2)
			{
				string type = stringRefs[i+0];
				string path = stringRefs[i+1];

				igObjectDirectory dir = igObjectStreamManager.Singleton.Load(path);

				switch(type)
				{
					case "texture":
						LoadTextureFromDir(dir);
						break;
					case "material_instances":
						LoadMaterialsFromDir(dir);
						break;
					case "model":
					case "actorskin":
						LoadDrawableFromDir(dir);
						break;
					case "igx_entities":
						EntityManager.Singleton.AddMapFile(dir);
						break;
					case "pkg":
						packages.Add(dir._name._hash, AssetManager.Singleton.AddPackage(dir));
						break;
					default:
						if(!test.Contains(type))
						{
							Console.WriteLine($"{type} is unsupported");
							test.Add(type);
						}
						break;
				}
			}
		}

		public void LoadTextureFromDir(igObjectDirectory dir)
		{
			igHandle handle = new igHandle();
			handle._handleName._ns = dir._name;
			handle._handleName._name.SetString("image");

			ulong key = AssetManager.GenerateKeyFromHandle(handle);

			igImage2? image = dir._objectList[0] as igImage2;
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
		}
		public void LoadMaterialsFromDir(igObjectDirectory dir)
		{
			if(dir._objectList._count == 0) return;

			igHandle handle = new igHandle();
			handle._handleName._ns = dir._name;

			for(int i = 0; i < dir._nameList._count; i++)
			{
				Material? glMaterial = null;

				handle._handleName._name = dir._nameList[i];
				ulong key = AssetManager.GenerateKeyFromHandle(handle);

				if(dir._objectList[i] is igGraphicsMaterial graphicsMaterial)
				{
					glMaterial = new Material(MaterialManager.materials["stdv;ulitf"], graphicsMaterial);
				}

				if(glMaterial == null)
				{
					glMaterial = new Material(MaterialManager.materials["stdv;ulitf"], null, PrimitiveType.Triangles);
				}

				materials.Add(key, glMaterial);
			}
		}

		public void LoadDrawableFromDir(igObjectDirectory dir)
		{
			IDrawableCommon drawable;
			if(dir._objectList[0] is igModelInfo mi) drawable = new CDrawableList(mi);
			else if(dir._objectList[1] is CGraphicsSkinInfo gsi) drawable = new CDrawableList(gsi);
			else throw new NotImplementedException($"mesh type at {dir._path} not implemented");
			drawables.Add(dir._name._hash, drawable);
		}

		public IDrawableCommon LoadDrawable(string path, bool isActor)
		{
			if(string.IsNullOrEmpty(path) || path == "metaobject") return null;

			string internalPath = $"{(isActor ? "actors" : "models")}:/{path}.igz";
			igObjectDirectory meshDir = igObjectStreamManager.Singleton.Load(internalPath);
			if(drawables.ContainsKey(meshDir._name._hash)) return drawables[meshDir._name._hash];

			throw new KeyNotFoundException($"{(isActor ? "Actor" : "Model")} not loaded");
		}
		public Texture? LoadTexture(igHandle handle)
		{
			if(handle._handleName._ns._hash == 0 || handle._handleName._name._hash == 0) return null;

			ulong key = AssetManager.GenerateKeyFromHandle(handle);

			if(textures.ContainsKey(key)) return textures[key];

			throw new KeyNotFoundException("Texture not loaded");
		}
		public Material LoadMaterial(igHandle handle)
		{
			ulong key = AssetManager.GenerateKeyFromHandle(handle);

			if(materials.ContainsKey(key)) return materials[key];

			throw new KeyNotFoundException("Material not loaded");
		}
	}
}