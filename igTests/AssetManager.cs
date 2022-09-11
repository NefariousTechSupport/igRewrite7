namespace igRewrite7
{
	public class AssetManager
	{
		static Lazy<AssetManager> lazy = new Lazy<AssetManager>(() => new AssetManager());
		public static AssetManager Singleton => lazy.Value;

		//igObjectDirectory name hash or file offset -> drawable
		public Dictionary<uint, IDrawableCommon> drawables = new Dictionary<uint, IDrawableCommon>();

		public IDrawableCommon LoadDrawable(string path, bool isActor)
		{
			if(string.IsNullOrEmpty(path) || path == "metaobject") return null;

			string internalPath = $"{(isActor ? "actors" : "models")}:/{path}.igz";
			igObjectDirectory meshDir = igObjectStreamManager.Singleton.Load(internalPath);
			if(drawables.ContainsKey(meshDir._name._hash)) return drawables[meshDir._name._hash];
			IDrawableCommon drawable;
			if(meshDir._objectList[0] is igModelInfo mi) drawable = new CDrawableListList(mi);
			else if(meshDir._objectList[1] is CGraphicsSkinInfo gsi) drawable = new CDrawableListList(gsi);
			else throw new NotImplementedException($"mesh type at {internalPath} not implemented");
			drawables.Add(meshDir._name._hash, drawable);
			return drawable;
		}
	}
}