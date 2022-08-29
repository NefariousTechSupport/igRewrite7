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

		};

		static string _root = string.Empty;

		public void Initialize(string root)
		{
			igGfx.Initialize();
			_root = root;
			IG_CORE_PLATFORM[] platforms = Enum.GetValues<IG_CORE_PLATFORM>();
			foreach(IG_CORE_PLATFORM platform in platforms)
			{
				string platformName = string.Empty;
				     if(platform == IG_CORE_PLATFORM.WIN32)   platformName = "win";
				else if(platform == IG_CORE_PLATFORM.ASPEN)   platformName = "aspenLow";
				else if(platform == IG_CORE_PLATFORM.ASPEN64) platformName = "aspenHigh";
				else                                          platformName = igCore.GetPlatformString(platform);

				if(File.Exists(_root + $"/permanent_{platformName}.pak"))
				{
					igArchiveManager.Singleton.AddArchiveToPool("permanent.pak");
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
					igArchiveManager.Singleton.AddArchiveToPool($"InstantPortraits.pak");
					igArchiveManager.Singleton.AddArchiveToPool($"QuestIcons.pak");
					igArchiveManager.Singleton.AddArchiveToPool($"PortalMasterPerkIcons.pak");
				}
			}
		}

		public igFileDescriptor Open(string path)
		{
			Console.WriteLine($"Opening {path}");
			if(path.StartsWith("<build>")) path = path.Substring(7);
			string[] parts = path.Split(':');
			if(parts.Length > 1)
			{
				if(_virtualDevices.ContainsKey(parts[0]))
				{
					path = _virtualDevices[parts[0]] + parts[1];
				}
			}
			if(Exists(path)) return _fileDescriptorPool.First(x => x._path == path);
			else
			{
				Stream ms;
				if(parts.Length > 1)
				{
					ms = new MemoryStream();
					igArchiveManager.Singleton.GetFile(path, ms);
				}
				else
				{
					ms = File.Open(_root + "/" + path, FileMode.Open);
				}
				_fileDescriptorPool.Add(new igFileDescriptor(ms, path.Split(':').Last().TrimStart('/', '\\')));
				Console.WriteLine($"{_fileDescriptorPool.Last()._path} added to pool");
				return _fileDescriptorPool.Last();
			}
		}
		public bool Exists(string path) => _fileDescriptorPool.Any(x => x._path == path);
	}
}