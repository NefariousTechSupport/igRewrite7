namespace igRewrite7
{
	public class EntityManager
	{
		static Lazy<EntityManager> lazy = new Lazy<EntityManager>(() => new EntityManager());

		public static EntityManager Singleton => lazy.Value;

		public List<Entity> entities = new List<Entity>();

		private Dictionary<string, igObjectDirectory> loadedDirs = new Dictionary<string, igObjectDirectory>();
		public Dictionary<string, List<Entity>> loadedEntities = new Dictionary<string, List<Entity>>();
		public uint loadedMap = 0;

		public bool ignoreDraw = false;

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
				try
				{
					igObjectDirectory mapDir = igObjectStreamManager.Singleton.Load(stringRefs[i]);
					if(mapDir != null)
					{
						LoadEntities(mapDir, quad);
					}
				}
				catch(FileNotFoundException){}
			}
			//AssetManager.Singleton.ConsolidateDrawables();
		}

		private void LoadEntities(igObjectDirectory dir, IDrawableCommon nullModel)
		{
			if(loadedEntities.ContainsKey(dir._path)) return;
			loadedEntities.Add(dir._path, new List<Entity>());
			List<igObject> objs = dir._objectList.ToCSList();
			for(int i = 0; i < objs.Count; i++)
			{
				if(objs[i] is igEntity ent)
				{
					Entity e = new Entity(objs[i] as igEntity);
					if(e.drawable == null) e.drawable = nullModel;
					e.name = dir._nameList[i]._string;
					entities.Add(e);
					loadedEntities[dir._path].Add(e);
					/*if(ent._entityData != null)
					{
						if(ent._entityData._componentData != null)
						{
							igComponentData[] cds = ent._entityData._componentData.internalHashTable.Values.ToArray();
							for(int j = 0; j < ent._entityData._componentData._hashItemCount; j++)
							{
								if(cds[j] is igPrefabComponentData pcd)
								{
									if(pcd._prefabEntities != null)
									{
										LoadEntities(pcd._prefabEntities.ToCSList().Cast<igObject>().ToList(), nullModel);
									}
								}
							}
						}
					}*/
				}
				if(objs[i] is CStaticEntity cse)
				{
					Entity e = new Entity(cse);
					if(e.drawable == null) e.drawable = nullModel;
					e.name = dir._nameList[i]._string;
					entities.Add(e);					
					loadedEntities[dir._path].Add(e);
				}
			}
		}

		private void ReallocEntities()
		{
		}

		public void Render()
		{
			Entity.drawCalls = 0;
			for(int i = 0; i < entities.Count; i++)
			{
				entities[i].Draw();
			}
			//Console.WriteLine(Entity.drawCalls);
			/*KeyValuePair<string, List<Entity>> map = EntityManager.Singleton.loadedEntities.ElementAt((int)loadedMap);
			for(int j = 0; j < map.Value.Count; j++)
			{
				map.Value[j].Draw();
			}*/
		}
	}
}