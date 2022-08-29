namespace igLibrary.Core
{
	public class igObjectStreamManager : igSingleton<igObjectStreamManager>
	{
		//change to Dictionary<igName, igObjectDirectory>
		public Dictionary<string, igObjectDirectory> _directories = new Dictionary<string, igObjectDirectory>();
		public void AddObjectDirectory(igObjectDirectory dir)
		{
			_directories.Add(dir._path, dir);
		}
		public igObjectDirectory GetDirectoryByName(string path)
		{
			if(_directories.ContainsKey(path))
			{
				return _directories[path];
			}
			else
			{
				return Load(path);
			}
		}
		public igObjectDirectory Load(string path)
		{
			//igArchiveManager.Singleton.GetFile(path, directoryStream);
			igFileDescriptor fd = igFileContext.Singleton.Open(path);
			igObjectDirectory objDir = new igObjectDirectory(fd._path);
			_directories.Add(path, objDir);
			return objDir;
		}
	}
}