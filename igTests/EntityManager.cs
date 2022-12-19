namespace igRewrite7
{
	public class EntityManager
	{
		static Lazy<EntityManager> lazy = new Lazy<EntityManager>(() => new EntityManager());

		public static EntityManager Singleton => lazy.Value;

		public List<Entity> entities = new List<Entity>();

		private Dictionary<string, igObjectDirectory> loadedDirs = new Dictionary<string, igObjectDirectory>();
		public Dictionary<string, List<Entity>> loadedEntities = new Dictionary<string, List<Entity>>();
		public List<EntityGroup> groups = new List<EntityGroup>();
		public uint loadedMap = 0;

		public bool ignoreDraw = false;

		public void AddMapFile(igObjectDirectory dir)
		{
			LoadEntities(dir, null);
		}

		public void Load(igObjectDirectory dir)
		{
			CDrawable quad = new CDrawable();
			quad.SetVertexPositions(new float[]
			{
				-1, -1, -1, 1,
				-1,  1, -1, 1,
				 1,  1, -1, 1,
				 1, -1, -1, 1,
				-1, -1,  1, 1,
				-1,  1,  1, 1,
				 1,  1,  1, 1,
				 1, -1,  1, 1,
			});
			quad.SetVertexTexCoords(new float[]
			{
				0, 0, 0, 1,
				0, 0, 0, 1,
				0, 0, 0, 1,
				0, 0, 0, 1,
				0, 0, 0, 1,
				0, 0, 0, 1,
				0, 0, 0, 1,
				0, 0, 0, 1,
			});
			quad.SetVertexColours(new float[]
			{
				1, 1, 0, 1,
				1, 1, 0, 1,
				1, 1, 0, 1,
				1, 1, 0, 1,
				1, 1, 0, 1,
				1, 1, 0, 1,
				1, 1, 0, 1,
				1, 1, 0, 1,
			});
			quad.SetIndices(new uint[]
			{
				4, 2, 0, 
				2, 7, 3, 
				6, 5, 7, 
				1, 7, 5, 
				0, 3, 1, 
				4, 1, 5, 
				4, 6, 2, 
				2, 6, 7, 
				6, 4, 5, 
				1, 3, 7, 
				0, 2, 3, 
				4, 0, 1,
			});
			quad.SetMaterial(new Material(MaterialManager.materials["stdv;ulitf"]));

			igStringRefList stringRefs = dir._objectList[0] as igStringRefList;

			//Parallel.For(0, stringRefs._count, (i, p) => LoadDirectory(stringRefs[(int)i], quad));
			for(int i = 1; i < stringRefs._count; i += 2)
			{
				if(stringRefs[i-1] != "igx_entities") continue;

				try
				{
					igObjectDirectory mapDir = igObjectStreamManager.Singleton.Load(stringRefs[i]);
					if(mapDir != null)
					{
						AddMapFile(mapDir);
						groups.Last().LoadEntities(quad);
					}
				}
				catch(FileNotFoundException){}
			}
			//AssetManager.Singleton.ConsolidateDrawables();
		}

		private void LoadEntities(igObjectDirectory dir, IDrawableCommon nullModel)
		{
			if(groups.Any(x => x._directory == dir)) return;
			groups.Add(new EntityGroup(dir, nullModel));
		}

		private void ReallocEntities()
		{
		}

		public void Render()
		{
			for(int j = 0; j < groups.Count; j++)
			{
				RenderMap(j);
			}
		}
		public void RenderMap(int mapIndex)
		{
			groups[mapIndex].Render();
		}
	}
}