namespace igLibrary.Core
{
	public class igFileContext : igSingleton<igFileContext>
	{
		List<igFileDescriptor> _fileDescriptorPool = new List<igFileDescriptor>();
		
		Dictionary<string, string> _virtualDevices = new Dictionary<string, string>()
		{
			{"actors", "actors"},
			{"anims", "anims"},
			{"behavior_events", "behavior_events"},
			{"animation_events", "animation_events"},
			{"behaviors", "behaviors"},
			{"cutscene", "cutscene"},
			{"data", ""},
			{"fonts", "fonts"},
			{"graphs", "graphs"},
			{"vsc", "vsc"},
			{"loosetextures", "loosetextures"},
			{"luts", "loosetextures/luts"},
			{"maps", "maps"},
			{"materials", "materialInstances"},
			{"models", "models"},
			{"motionpaths", "motionpaths"},
			{"renderer", "renderer"},
			{"scripts", "scripts"},
			{"shaders", "shaders"},
			{"sky", "sky"},
			{"sounds", "sounds"},
			{"spawnmeshes", "spawnmeshes"},
			{"textures", "textures"},
			{"ui", "ui"},
			{"vfx", "vfx"},
			{"cwd", ""},
		};

		public string _root { get; private set;}

		public igFileContext()
		{
			_root = string.Empty;
		}

		public string GetMediaDirectory(string media)
		{
			string lower = media.ToLower();
			if(_virtualDevices.ContainsKey(lower))
			{
				return _virtualDevices[lower];
			}
			else return media;
		}

		public void Initialize(string root)
		{
			igGfx.Initialize();
			_root = root.TrimEnd('/');
			_root = _root.TrimEnd('\\');
			IG_CORE_PLATFORM[] platforms = Enum.GetValues<IG_CORE_PLATFORM>();
			foreach(IG_CORE_PLATFORM platform in platforms)
			{
				string platformName = igCore.GetPlatformString(platform);

				if(File.Exists($"{_root}/archives/permanent_{platformName}.pak"))
				{
					igArchiveManager.Singleton.AddArchiveToPool("permanent.pak");
					igArchiveManager.Singleton.AddArchiveToPool("permanentdeveloper.pak");
					igArchiveManager.Singleton.AddArchiveToPool($"permanent_{platformName}.pak");
					igArchiveManager.Singleton.AddArchiveToPool($"shaders_{platformName}.pak");
					igArchiveManager.Singleton.AddArchiveToPool($"loosefiles.pak");
					igArchiveManager.Singleton.AddArchiveToPool($"CollectibleTrackerIcons.pak");
					igArchiveManager.Singleton.AddArchiveToPool($"skystonesSmashPortraits.pak");
					igArchiveManager.Singleton.AddArchiveToPool($"ToyCollectionMaterials.pak");
					igArchiveManager.Singleton.AddArchiveToPool($"LevelIcons.pak");
					igArchiveManager.Singleton.AddArchiveToPool($"Minimaps.pak");
					igArchiveManager.Singleton.AddArchiveToPool($"TrophyBlueprints.pak");
					igArchiveManager.Singleton.AddArchiveToPool($"soundbankdata.pak");
					igArchiveManager.Singleton.AddArchiveToPool($"zoneinfos.pak");
					igArchiveManager.Singleton.AddArchiveToPool($"juicedomain_story.pak");
					igArchiveManager.Singleton.AddArchiveToPool($"QuestIcons.pak");
					igArchiveManager.Singleton.AddArchiveToPool($"PortalMasterPerkIcons.pak");
				}
			}
		}

		public igFileDescriptor Open(string path)
		{
			igFilePath fp = new igFilePath();
			fp.Set(path);
			int fdIndex = _fileDescriptorPool.FindIndex(x => x._path._path == fp._path);

			if(fdIndex >= 0) return _fileDescriptorPool[fdIndex];
			else
			{
				Stream ms;
				if(igArchiveManager.Singleton.ExistsInOpenArchives(path))
				{
					ms = new MemoryStream();
					igArchiveManager.Singleton.GetFile(path, ms);
				}
				else
				{
					if(File.Exists($"{_root}/{fp._path}"))
					{
						ms = File.Open(_root + "/" + fp._path, FileMode.Open);
					}
					else throw new FileNotFoundException($"Did not find {fp._path}");
				}
				_fileDescriptorPool.Add(new igFileDescriptor(ms, fp._path));
				Console.WriteLine($"{_fileDescriptorPool.Last()._path._path} added to pool");
				return _fileDescriptorPool.Last();
			}
		}
		public bool Exists(string path) => _fileDescriptorPool.Any(x => x._path._path == path);
	}
}