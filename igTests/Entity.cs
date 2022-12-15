namespace igRewrite7
{
	public class Entity
	{
		public igObject instance;
		public IDrawableCommon? drawable;
		public int id;
		public string name = string.Empty;
		public bool draw = true;

		public Transform transform;

		//xyz is pos, w is radius
		public Vector4 boundingSphere;

		public static uint drawCalls;

		public Entity()
		{
			transform = new Transform();
		}
		public Entity(igEntity entity)
		{
			instance = entity;

			transform = new Transform();
			transform.Position = Utils.ToOpenTKVector3(entity._parentSpacePosition);

			if(entity is CActor actor)
			{
				CActorData actorData = (CActorData)actor._entityData;

				drawable = AssetManager.Singleton.LoadDrawable(actorData._skin, true);
			}
			else if(entity is CGameEntity gameEntity)
			{
				CGameEntityData gameEntityData = (CGameEntityData)gameEntity._entityData;

				if(gameEntityData._modelName != null)
				{
					drawable = AssetManager.Singleton.LoadDrawable(gameEntityData._modelName, false);
				}
				else
				{
					drawable = AssetManager.Singleton.LoadDrawable(gameEntityData._skinName, true);
				}
			}

			if(entity is CEntity cEntity)
			{
				draw = !cEntity._startHidden;
				if(cEntity._scaleSource == CEntity.EScaleSource.eSS_Entity)
				{
					//TODO: Fix this
					//transform.Scale = Vector3.One * cEntity._transform._runtimeParentSpaceScale;
					transform.Scale = Vector3.One;
				}
				else if(cEntity._scaleSource == CEntity.EScaleSource.eSS_EntityData)
				{
					transform.Scale = Vector3.One * cEntity._entityData._scale;
				}
			}

			if(entity._transform != null)
			{
				transform.EulerRotation = Utils.ToOpenTKVector3(entity._transform._parentSpaceRotation);
			}
		}
		public Entity(CStaticEntity cse)
		{
			instance = cse;
			draw = true;
			if(cse._entityData == null)
			{
				transform = new Transform();
				return;
			}
			drawable = AssetManager.Singleton.LoadDrawable(cse._entityData._modelName, false);
			Vector3 rot = Utils.ToOpenTKVector3(cse._rotation);
			rot.X = MathHelper.DegreesToRadians(rot.X);
			rot.Y = MathHelper.DegreesToRadians(rot.Y);
			rot.Z = MathHelper.DegreesToRadians(rot.Z);
			transform = new Transform(Utils.ToOpenTKVector3(cse._position), rot, Utils.ToOpenTKVector3(cse._scale));
		}
		public void SetPosition(Vector3 position)
		{
			transform.Position = position;
			if(drawable != null) drawable.UpdateTransform(transform);
		}
		public void Draw()
		{
			if(drawable == null) return;
			if(name.Contains("eater", StringComparison.OrdinalIgnoreCase))
				;
			//Frustum culling is currently not used because idk how the bounding boxes work
			//if(cull.DoFrustumCull()) return;
			if(!EntityManager.Singleton.ignoreDraw || draw) drawable.Draw(transform);
		}
	}
}