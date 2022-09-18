namespace igRewrite7
{
	public class EntityManager
	{
		static Lazy<EntityManager> lazy = new Lazy<EntityManager>(() => new EntityManager());

		public static EntityManager Singleton => lazy.Value;

		public List<Entity> entities = new List<Entity>();

		private Dictionary<string, igObjectDirectory> loadedDirs = new Dictionary<string, igObjectDirectory>();
		public Dictionary<string, List<Entity>> loadedEntities = new Dictionary<string, List<Entity>>();

		public void Load(igObjectDirectory dir)
		{
			CDrawable quad = new CDrawable();
			quad.SetVertexPositions(new float[]
			{
				-1, -1,  0, 1,
				-1,  1,  0, 1,
				 1,  1,  0, 1,
				 1, -1,  0, 1,
			});
			quad.SetVertexTexCoords(new float[]
			{
				0, 0, 0, 1,
				0, 1, 0, 1,
				1, 1, 0, 1,
				1, 0, 0, 1,
			});
			quad.SetVertexColours(new float[]
			{
				0, 0, 0, 1,
				0, 1, 0, 1,
				1, 1, 0, 1,
				1, 0, 0, 1,
			});
			quad.SetIndices(new uint[]
			{
				0, 1, 2,
				2, 3, 0
			});
			quad.SetMaterial(new Material(MaterialManager.materials["stdv;ulitf"]));

			igStringRefList stringRefs = dir._objectList[0] as igStringRefList;
			
			for(int i = 0; i < stringRefs._count; i++)
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
		}

		private void LoadEntities(igObjectDirectory dir, IDrawableCommon nullModel)
		{
			if(loadedEntities.ContainsKey(dir._path)) return;
			loadedEntities.Add(dir._path, new List<Entity>());
			/*loadedDirs.Add(dir._path, dir);
			for(int i = 0; i < dir._dependancies.Count; i++)
			{
				if(!loadedDirs.ContainsKey(dir._dependancies[i]._path))
				{
					LoadEntities(dir._dependancies[i], nullModel);
				}
			}*/
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
			for(int i = 0; i < entities.Count; i++)
			{
				entities[i].Draw();
			}
			/*if(MobyHandles.Sum(x => x.Value.Count) != mobys.Count)
			{
				ReallocEntities();
			}
			mobys = mobys.OrderByDescending(x => (x.transform.Position + Camera.transform.Position).LengthSquared).ToList();
			for(int i = 0; i < mobys.Count; i++)
			{
				mobys[i].Draw();
			}*/
		}
	}

	public class Entity
	{
		public object instance;					//Is either a Region.CMobyInstance or a TieInstance depending on if it's a moby or tie repsectively
		public IDrawableCommon drawable;
		public int id;
		public string name = string.Empty;

		public Transform transform;

		//xyz is pos, w is radius
		public Vector4 boundingSphere;

		public Entity(){}
		public Entity(igEntity ce)
		{
			Vector3 eulerRot = Vector3.Zero;
			if(ce is CActor ca)
			{
				CActorData caData = (CActorData)ce._entityData;
				drawable = AssetManager.Singleton.LoadDrawable(caData._skin, true);
				if(ca._transform != null)
				{
					eulerRot = Utils.ToOpenTKVector3(ca._transform._parentSpaceRotation);
				}
			}
			else if(ce is CGameEntity cge)
			{
				CGameEntityData cged = (CGameEntityData)cge._entityData;
				drawable = AssetManager.Singleton.LoadDrawable(cged._modelName, false);
				if(drawable == null)
				{
					drawable = AssetManager.Singleton.LoadDrawable(cged._skinName, true);
				}
				if(cge._transform != null)
				{
					eulerRot = Utils.ToOpenTKVector3(cge._transform._parentSpaceRotation);
				}
			}
			if(ce._transform != null)
			{
				transform = new Transform(Utils.ToOpenTKVector3(ce._parentSpacePosition), eulerRot, Vector3.One * ce._entityData._scale);
			}
			else
			{
				transform = new Transform();
			}
		}
		public Entity(CStaticEntity cse)
		{
			drawable = AssetManager.Singleton.LoadDrawable(cse._entityData._modelName, false);
			Vector3 rot = Utils.ToOpenTKVector3(cse._rotation);
			rot.X = MathHelper.DegreesToRadians(rot.X);
			rot.Y = MathHelper.DegreesToRadians(rot.Y);
			rot.Z = MathHelper.DegreesToRadians(rot.Z);
			transform = new Transform(Utils.ToOpenTKVector3(cse._position), rot, Utils.ToOpenTKVector3(cse._scale));
		}
		public void SetPosition(Vector3 position)
		{
			transform.position = position;
			drawable.UpdateTransform(transform);
		}
		public void Draw()
		{
			drawable.Draw(transform);
		}
		public bool IntersectsRay(Vector3 dir, Vector3 position)
		{
			Vector3 m = position - boundingSphere.Xyz;
			float b = Vector3.Dot(m, dir);
			float c = Vector3.Dot(m, m) - boundingSphere.W * boundingSphere.W;

			if(c > 0 && b > 0) return false;

			float discriminant = b*b - c;

			return discriminant >= 0;
		}
	}
}