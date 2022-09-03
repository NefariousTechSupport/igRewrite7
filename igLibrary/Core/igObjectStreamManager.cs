namespace igLibrary.Core
{
	public class igObjectStreamManager : igSingleton<igObjectStreamManager>
	{
		//change to Dictionary<igName, igObjectDirectory>
		public Dictionary<uint, igObjectDirectory> _directories = new Dictionary<uint, igObjectDirectory>();
		public void AddObjectDirectory(igObjectDirectory dir)
		{
			_directories.Add(dir._name._hash, dir);
		}
		public igObjectDirectory Load(string path)
		{
			//igArchiveManager.Singleton.GetFile(path, directoryStream);
			igFileDescriptor fd = igFileContext.Singleton.Open(path);
			if(fd == null) return null;
			igObjectDirectory objDir = new igObjectDirectory(fd._path._path);
			AddObjectDirectory(objDir);
			objDir.ReadFile();
			return objDir;
		}
		public igObjectDirectory Load(string filePath, igName nameSpace)
		{
			Console.Write($"igObjectStreamManager was asked to load {filePath}...");
			if(_directories.ContainsKey(nameSpace._hash))
			{
				Console.Write($"was previously loaded.\n");
				return _directories[nameSpace._hash];
			}
			Console.Write($"was not previously loaded.\n");

			igObjectDirectory objDir = new igObjectDirectory(filePath, nameSpace);
			AddObjectDirectory(objDir);
			objDir.ReadFile();
			return objDir;
		}
	}
}