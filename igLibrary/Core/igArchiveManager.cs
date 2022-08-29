namespace igLibrary.Core
{
	public class igArchiveManager : igSingleton<igArchiveManager>
	{
		public Dictionary<string, igArchive> archives = new Dictionary<string, igArchive>();

		public void AddArchiveToPool(string archivePath)
		{
			if(!archives.ContainsKey(archivePath))
			{
				igFileContext.Singleton.Open(Path.ChangeExtension(archivePath, "pak"));
				igArchive archive = new igArchive(archivePath);
				archives.Add(Path.GetFileNameWithoutExtension(archivePath), archive);
			}
		}

		public void GetFile(string filePath, Stream output)
		{
			string[] parts = filePath.Split(':');
			if(parts.Length > 1)
			{
				if(parts.Length > 2)
				{
					parts = new string[2]{$"{parts[0]}:{parts[1]}", parts[2]};
				}
				if(!archives.ContainsKey(parts[0]))
				{
					AddArchiveToPool(parts[0]);
				}
				archives[Path.GetFileNameWithoutExtension(parts[0])].ExtractFile(parts[1].TrimStart('/', '\\'), output);
			}
			else
			{
				bool fileFound = false;
				foreach(KeyValuePair<string, igArchive> archive in archives)
				{
					if(archive.Value.HasFile(filePath))
					{
						archive.Value.ExtractFile(filePath, output);
						fileFound = true;
						break;
					}
				}
				if(!fileFound) throw new FileNotFoundException($"COULD NOT FIND {filePath}");
			}
			output.Flush();
		}
	}
}