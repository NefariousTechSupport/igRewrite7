namespace igLibrary.Core
{
	public class igObjectDirectory
	{
		public string _path;
		public igName _name;
		public List<igObjectDirectory> _dependancies = new List<igObjectDirectory>();
		public igObjectList _objectList = new igObjectList();
		public bool _useNameList = false;
		public igNameList? _nameList = null;
		public igIGZ _loader;

		public enum FileType : uint
		{
			kAuto,
			kIGB,
			kIGX,
			kDataStream,
			kIGZ,
			kInvalid,	//This isn't real
		}

		FileType type;

		public igObjectDirectory(){}
		public igObjectDirectory(string path, igName nameSpace)
		{
			_path = path;
			_name = nameSpace;
		}
		public igObjectDirectory(string path)
		{
			_path = path;
			_name = new igName(Path.GetFileNameWithoutExtension(path).ToLower());
		}
		
		public void ReadFile(FileType type, Stream stream, bool readDependancies = true)
		{
			switch(type)
			{
				case FileType.kIGZ:
					_loader = new igIGZ(this, stream, readDependancies);
					break;
				default:
					Console.WriteLine($"WARNING: {_path} IS NOT AN IGOBJECT STREAM, SKIPPING...");
					break;
			}
		}
		public void ReadFile(bool readDependancies = true)
		{
			//change this to happen in igObjectLoader once that exists
			type = GetLoader(_path);
			switch(type)
			{
				case FileType.kIGZ:
					_loader = new igIGZ(this, igFileContext.Singleton.Open(_path), readDependancies);
					break;
				default:
					Console.WriteLine($"WARNING: {_path} IS NOT AN IGOBJECT STREAM, SKIPPING...");
					break;
			}
		}
		public static igObjectDirectory? LoadDependancyDefault(string filePath, igName nameSpace)
		{
			return igObjectStreamManager.Singleton.Load(filePath, nameSpace);
		}
		public static FileType GetLoader(string filePath)
		{
			igFilePath path = new igFilePath();
			path.Set(filePath);
			switch(path._fileExtension)
			{
				case ".igz":
				case ".lng":
				case ".pak":	//not to be confused with the archive extension
				case ".bld":	//not to be confused with the archive extension
					return FileType.kIGZ;
				default:
					return FileType.kInvalid;
					//throw new InvalidOperationException($"Invalid filetype {path._fileExtension}");
			}
		}
		public void BuildIGZ(string path)
		{
			
		}
	}
}