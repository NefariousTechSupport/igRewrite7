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

		public enum FileType : uint
		{
			kAuto,
			kIGB,
			kIGX,
			kDataStream,
			kIGZ
		}

		FileType type;

		public igObjectDirectory(){}
		public igObjectDirectory(string path)
		{
			_path = path;
			string extension = Path.GetExtension(path);
			_name.SetString(Path.GetFileNameWithoutExtension(path));
			//change this to happen in igObjectLoader once that exists
			switch(extension)
			{
				//hopefully bld and pak don't open igas
				case ".igz":
				case ".bld":
				case ".pak":
					type = FileType.kIGZ;
					igIGZ igz = new igIGZ(this, igFileContext.Singleton.Open(path));
					break;
				default:
					Console.WriteLine($"WARNING: {path} IS NOT AN IGOBJECT STREAM, SKIPPING...");
					break;
			}
		}
	}
}