namespace igLibrary.Core
{
	public class igFilePath
	{
		public string _media { get; private set; }
		public string _directory { get; private set; }
		public string _file { get; private set; }
		public string _extension { get; private set; }
		public string _mediaDirectory { get; private set; }
		public string _fileExtension { get; private set; }
		public string _path { get; private set; }
		public string _nativePath { get; private set; }
		public static string _defaultMedia = "isHostFileSystemMountedInternal";

		public string NativePrefix => string.Empty;
		public string NativeAllowRelativePaths => string.Empty;
		public char NativeSeperator => '/';
		public string NativeActivePrefix => string.Empty;
		public bool NativeCaseSensitive => true;

		public igFilePath()
		{
			_media = string.Empty;
			_directory = string.Empty;
			_file = string.Empty;
			_extension = string.Empty;
			_mediaDirectory = string.Empty;
			_fileExtension = string.Empty;
			_path = string.Empty;
			_nativePath = string.Empty;
		}

		public void Set(string path)
		{
			path.Replace('\\', '/');
			int mediaIndex = path.IndexOf(':');
			if(mediaIndex >= 0)
			{
				_media = path.Substring(0, mediaIndex);
			}
			_mediaDirectory = igFileContext.Singleton.GetMediaDirectory(_media);
			int finalDir = -1;
			_directory = path.Substring(mediaIndex + 1);
			for(int i = 0; i < _directory.Length; i++)
			{
				if(_directory[i] == '/') finalDir = i;
			}
			if(finalDir >= 0) _directory = _directory.Substring(0, finalDir + 1);
			else _directory = string.Empty;

			int fileStart = finalDir + mediaIndex + 2;
			int extensionStart = -1;
			for(int i = fileStart; i < path.Length; i++)
			{
				if(path[i] == '.') extensionStart = i;
			}
			_file = path.Substring(fileStart, extensionStart - fileStart);
			_extension = path.Substring(extensionStart);

			_fileExtension = string.Empty;
			if(_extension.Length > 0)
			{
				if(_extension[0] != '.') _fileExtension += '.';
				_fileExtension += _extension;
			}
			
			_path = GeneratePath(_mediaDirectory);
			_nativePath = _path.Replace('/', NativeSeperator);
			_nativePath = _nativePath.Replace('\\', NativeSeperator);
		}
		public string GeneratePath(string mediaDirectory)
		{
			string nativePath = mediaDirectory;
			int mediaLen = mediaDirectory.Length;
			if(mediaLen != 0)
			{
				nativePath = nativePath.TrimEnd('/', '\\');
			}
			nativePath += _directory;
			if(_directory.Length > 0)
			{
				char finalChar = _directory.Last();
				if(finalChar != '/' && finalChar != '\\') nativePath += '/';
			}
			nativePath += _file;
			nativePath += _fileExtension;
			nativePath = nativePath.Replace('\\', '/');
			return nativePath;
		}
	}
}