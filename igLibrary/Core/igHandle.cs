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
			Dictionary<string, igObjectDirectory> dirs = igObjectStreamManager.Singleton._directories;
			foreach(KeyValuePair<string, igObjectDirectory> dir in dirs)
			{
				if(dir.Value._name._hash == _handleName._ns._hash)
				{
					for(int i = 0; i < dir.Value._nameList._count; i++)
					{
						if(dir.Value._nameList[i]._hash == _handleName._name._hash)
						{
							return (T)dir.Value._objectList[i];
						}
					}
				}
			}
			Console.WriteLine($"failed to load {_handleName._ns._string}:/{_handleName._name._string}");
			return null;
		}
	}
}