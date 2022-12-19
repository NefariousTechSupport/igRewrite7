namespace igRewrite7
{
	public class EntityGroup
	{
		public List<Entity> _entities = new List<Entity>();
		public igObjectDirectory? _directory;

		public EntityGroup(igObjectDirectory mapDirectory, IDrawableCommon nullModel)
		{
			_directory = mapDirectory;
		}

		public void LoadEntities(IDrawableCommon nullModel)
		{
			List<igObject> objs = _directory._objectList.ToCSList();
			for(int i = 0; i < objs.Count; i++)
			{
				if(objs[i] is igEntity ent)
				{
					Entity e = new Entity(objs[i] as igEntity);
					if(e.drawable == null) e.drawable = nullModel;
					e.name = _directory._nameList[i]._string;
					_entities.Add(e);
				}
				if(objs[i] is CStaticEntity cse)
				{
					Entity e = new Entity(cse);
					if(e.drawable == null) e.drawable = nullModel;
					e.name = _directory._nameList[i]._string;
					_entities.Add(e);
				}
			}
		}
		public void Render()
		{
			for(int i = 0; i < _entities.Count; i++)
			{
				_entities[i].Draw();
			}
		}
	}
}