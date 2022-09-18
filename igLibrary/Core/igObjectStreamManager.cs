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
		public igObjectDirectory Load(string path, bool readDependancies = true)
		{
			return Load(path, new igName(Path.GetFileNameWithoutExtension(path)), readDependancies);
		}
		public igObjectDirectory? Load(string filePath, igName nameSpace, bool readDependancies = true)
		{
			Console.Write($"igObjectStreamManager was asked to load {filePath}...");
			if(_directories.ContainsKey(nameSpace._hash))
			{
				Console.Write($"was previously loaded.\n");
				return _directories[nameSpace._hash];
			}
			Console.Write($"was not previously loaded.\n");

			igFilePath fp = new igFilePath();
			fp.Set(filePath);

			if(fp._fileExtension == ".igz" || fp._fileExtension == ".lng")
			{
				igObjectDirectory objDir = new igObjectDirectory(filePath, nameSpace);
				AddObjectDirectory(objDir);
				objDir.ReadFile(readDependancies);
				return objDir;
			}
			else
			{
				if(fp._fileExtension == ".bk2")
				{
					try
					{
						igArchiveManager.Singleton.AddArchiveToPool($"{fp._file}.pak");
					}
					catch(Exception){}
				}
				return null;
			}
		}
	}
}