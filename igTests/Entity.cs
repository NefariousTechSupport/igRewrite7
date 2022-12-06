namespace igRewrite7
{
	public class Entity
	{
		public igObject instance;
		public IDrawableCommon drawable;
		public int id;
		public string name = string.Empty;
		public bool draw;

		public Transform transform;

		//xyz is pos, w is radius
		public Vector4 boundingSphere;

		public Entity(){}
		public Entity(igEntity ce)
		{
			Vector3 eulerRot = Vector3.Zero;
			instance = ce;
			if(ce is CActor ca)
			{
				CActorData caData = (CActorData)ce._entityData;
				drawable = AssetManager.Singleton.LoadDrawable(caData._skin, true);
				if(ca._transform != null)
				{
					eulerRot = Utils.ToOpenTKVector3(ca._transform._parentSpaceRotation);
				}
				draw = !ca._startHidden;
			}
			else if(ce is CGameEntity cge)
			{
				CGameEntityData cged = (CGameEntityData)cge._entityData;
				if(cged == null) goto finish;
				drawable = AssetManager.Singleton.LoadDrawable(cged._modelName, false);
				if(drawable == null)
				{
					drawable = AssetManager.Singleton.LoadDrawable(cged._skinName, true);
				}
				if(cge._transform != null)
				{
					eulerRot = Utils.ToOpenTKVector3(cge._transform._parentSpaceRotation);
				}
				draw = !cge._startHidden;
			}
			finish:
			if(ce._transform != null)
			{
				transform = new Transform(Utils.ToOpenTKVector3(ce._parentSpacePosition), eulerRot, Vector3.One * ce._transform._runtimeParentSpaceScale);
			}
			else
			{
				transform = new Transform();
			}
			if(drawable != null)
			{
				//drawable.AddDrawCall(transform);
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
			//drawable.AddDrawCall(transform);
		}
		public void SetPosition(Vector3 position)
		{
			transform.Position = position;
			drawable.UpdateTransform(transform);
		}
		public void Draw()
		{
			//if(this.name != "TunnelTrack") return;
			if(!EntityManager.Singleton.ignoreDraw || draw) drawable.Draw(transform);
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