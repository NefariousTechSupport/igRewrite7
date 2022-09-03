namespace igLibrary.Core
{
	public struct igHandle
	{
		public igHandleName _handleName;

		public igHandle(igHandleName name)
		{
			_handleName = name;
		}
		public T GetObject<T>() where T : igObject
		{
			Dictionary<uint, igObjectDirectory> dirs = igObjectStreamManager.Singleton._directories;
			if(dirs.ContainsKey(_handleName._ns._hash))
			{
				igObjectDirectory dir = dirs[_handleName._ns._hash];
				for(int i = 0; i < dir._nameList._count; i++)
				{
					if(dir._nameList[i]._hash == _handleName._name._hash)
					{
						return (T)dir._objectList[i];
					}
				}				
			}
			Console.WriteLine($"failed to load {_handleName._ns._string}:/{_handleName._name._string}");
			return null;
		}
	}
}