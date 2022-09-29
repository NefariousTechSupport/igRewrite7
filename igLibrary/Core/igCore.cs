namespace igLibrary.Core
{
	public static class igCore
	{
		public static Dictionary<string, Type> RegisteredTypes = GetRegisteredTypes();
		public static IG_CORE_PLATFORM platform;

		private static Dictionary<string, Type> GetRegisteredTypes()
		{
			Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
			Type[] types = assemblies.SelectMany(x => x.GetTypes()).Where(x => x.IsAssignableTo(typeof(igObject))).ToArray();
			Dictionary<string, Type> registers = new Dictionary<string, Type>();
			for(uint i = 0; i < types.Length; i++)
			{
				registers.Add(types[i].Name, types[i]);
			}

			return registers;
		}
		public static bool IsPlatformBigEndian(IG_CORE_PLATFORM platform)
		{
			switch(platform)
			{
				default:
				case IG_CORE_PLATFORM.DEFAULT:
				case IG_CORE_PLATFORM.DEPRECATED:
				case IG_CORE_PLATFORM.WIN32:
				case IG_CORE_PLATFORM.DURANGO:
				case IG_CORE_PLATFORM.ASPEN:
				case IG_CORE_PLATFORM.XENON:
				case IG_CORE_PLATFORM.WIN64:
				case IG_CORE_PLATFORM.ASPEN64:
				case IG_CORE_PLATFORM.PS4:
				case IG_CORE_PLATFORM.OSX:
				case IG_CORE_PLATFORM.NGP:
				case IG_CORE_PLATFORM.MARMALADE:
				case IG_CORE_PLATFORM.RASPI:
				case IG_CORE_PLATFORM.ANDROID:
				case IG_CORE_PLATFORM.LGTV:
				case IG_CORE_PLATFORM.WP8:
				case IG_CORE_PLATFORM.LINUX:
					return false;
				case IG_CORE_PLATFORM.PS3:
				case IG_CORE_PLATFORM.CAFE:
				case IG_CORE_PLATFORM.WII:
					return true;
			}
		}

		public static string GetPlatformString(IG_CORE_PLATFORM platform)
		{
			     if(platform == IG_CORE_PLATFORM.WIN32)   return "win";
			else if(platform == IG_CORE_PLATFORM.ASPEN)   return "aspenLow";
			else if(platform == IG_CORE_PLATFORM.ASPEN64) return "aspenHigh";
			else
			switch(platform)
			{
				case IG_CORE_PLATFORM.DEFAULT: return "unknown";
				case IG_CORE_PLATFORM.WIN32:   return "win32";
				case IG_CORE_PLATFORM.WII:     return "wii";
				case IG_CORE_PLATFORM.DURANGO: return "durango";
				case IG_CORE_PLATFORM.ASPEN:   return "aspen";
				case IG_CORE_PLATFORM.XENON:   return "xenon";
				case IG_CORE_PLATFORM.PS3:     return "ps3";
				case IG_CORE_PLATFORM.OSX:     return "osx";
				case IG_CORE_PLATFORM.WIN64:   return "win64";
				case IG_CORE_PLATFORM.CAFE:    return "cafe";
				case IG_CORE_PLATFORM.RASPI:   return "raspi";
				case IG_CORE_PLATFORM.ANDROID: return "android";
				case IG_CORE_PLATFORM.ASPEN64: return "aspen64";
				case IG_CORE_PLATFORM.LGTV:    return "lgtv";
				case IG_CORE_PLATFORM.PS4:     return "ps4";
				case IG_CORE_PLATFORM.WP8:     return "wp8";
				case IG_CORE_PLATFORM.LINUX:   return "linux";
				default:                       return string.Empty;
			}
		}
		public static IG_CORE_PLATFORM GetPlatform(uint version, uint rawPlatform)
		{
			switch(version)
			{
				case 0x06:
					switch(rawPlatform)
					{
						case 0x00: platform = IG_CORE_PLATFORM.DEFAULT; break;
						case 0x01: platform = IG_CORE_PLATFORM.WIN32; break;
						case 0x02: platform = IG_CORE_PLATFORM.WII; break;
						case 0x03: platform = IG_CORE_PLATFORM.DEPRECATED; break;
						case 0x04: platform = IG_CORE_PLATFORM.ASPEN; break;
						case 0x05: platform = IG_CORE_PLATFORM.XENON; break;
						case 0x06: platform = IG_CORE_PLATFORM.PS3; break;
						case 0x07: platform = IG_CORE_PLATFORM.OSX; break;
						case 0x08: platform = IG_CORE_PLATFORM.WIN64; break;
						case 0x09: platform = IG_CORE_PLATFORM.CAFE; break;
						case 0x0A: platform = IG_CORE_PLATFORM.NGP; break;
						case 0x0B: platform = IG_CORE_PLATFORM.ANDROID; break;
						case 0x0C: platform = IG_CORE_PLATFORM.MARMALADE; break;
						case 0x0D: platform = IG_CORE_PLATFORM.MAX; break;
					}
					break;
				case 0x07:
				case 0x08:
				case 0x09:
					switch(rawPlatform)
					{
						case 0x00: platform = IG_CORE_PLATFORM.DEFAULT; break;
						case 0x01: platform = IG_CORE_PLATFORM.WIN32; break;
						case 0x02: platform = IG_CORE_PLATFORM.WII; break;
						case 0x03: platform = IG_CORE_PLATFORM.DURANGO; break;
						case 0x04: platform = IG_CORE_PLATFORM.ASPEN; break;
						case 0x05: platform = IG_CORE_PLATFORM.XENON; break;
						case 0x06: platform = IG_CORE_PLATFORM.PS3; break;
						case 0x07: platform = IG_CORE_PLATFORM.OSX; break;
						case 0x08: platform = IG_CORE_PLATFORM.WIN64; break;
						case 0x09: platform = IG_CORE_PLATFORM.CAFE; break;
						case 0x0A: platform = IG_CORE_PLATFORM.RASPI; break;
						case 0x0B: platform = IG_CORE_PLATFORM.ANDROID; break;
						case 0x0C:
							if(version == 0x07)      platform = IG_CORE_PLATFORM.MARMALADE;
							else if(version == 0x08) platform = IG_CORE_PLATFORM.DEPRECATED;
							else                     platform = IG_CORE_PLATFORM.ASPEN64;
							break;
						case 0x0D: platform = IG_CORE_PLATFORM.LGTV; break;
						case 0x0E: platform = IG_CORE_PLATFORM.PS4; break;
						case 0x0F: platform = IG_CORE_PLATFORM.WP8; break;
						case 0x10: platform = IG_CORE_PLATFORM.LINUX; break;
						case 0x11: platform = IG_CORE_PLATFORM.MAX; break;
					}
					break;
				default:
					Console.WriteLine($"WARNING: IG_CORE_PLATFORM FOR VERSION {version} NOT IMPLEMENTED");
					break;
			}
			return platform;
		}
		public static bool IsPlatform64Bit(IG_CORE_PLATFORM platform)
		{
			switch(platform)
			{
				default:
				case IG_CORE_PLATFORM.DEFAULT:
				case IG_CORE_PLATFORM.DEPRECATED:
				case IG_CORE_PLATFORM.WIN32:
				case IG_CORE_PLATFORM.WII:
				case IG_CORE_PLATFORM.ASPEN:
				case IG_CORE_PLATFORM.XENON:
				case IG_CORE_PLATFORM.PS3:
				case IG_CORE_PLATFORM.OSX:
				case IG_CORE_PLATFORM.CAFE:
				case IG_CORE_PLATFORM.NGP:
				case IG_CORE_PLATFORM.MARMALADE:
				case IG_CORE_PLATFORM.RASPI:
				case IG_CORE_PLATFORM.ANDROID:
				case IG_CORE_PLATFORM.LGTV:
				case IG_CORE_PLATFORM.WP8:
				case IG_CORE_PLATFORM.LINUX:
				case IG_CORE_PLATFORM.MAX:
					return false;
				case IG_CORE_PLATFORM.DURANGO:
				case IG_CORE_PLATFORM.WIN64:
				case IG_CORE_PLATFORM.ASPEN64:
				case IG_CORE_PLATFORM.PS4:
					return true;
			}
		}
		public static byte GetSizeOfPointer(IG_CORE_PLATFORM platform)
		{
			switch(platform)
			{
				default:
				case IG_CORE_PLATFORM.DEFAULT:
				case IG_CORE_PLATFORM.DEPRECATED:
				case IG_CORE_PLATFORM.WIN32:
				case IG_CORE_PLATFORM.WII:
				case IG_CORE_PLATFORM.ASPEN:
				case IG_CORE_PLATFORM.XENON:
				case IG_CORE_PLATFORM.PS3:
				case IG_CORE_PLATFORM.OSX:
				case IG_CORE_PLATFORM.CAFE:
				case IG_CORE_PLATFORM.NGP:
				case IG_CORE_PLATFORM.MARMALADE:
				case IG_CORE_PLATFORM.RASPI:
				case IG_CORE_PLATFORM.ANDROID:
				case IG_CORE_PLATFORM.LGTV:
				case IG_CORE_PLATFORM.WP8:
				case IG_CORE_PLATFORM.LINUX:
				case IG_CORE_PLATFORM.MAX:
					return 4;
				case IG_CORE_PLATFORM.DURANGO:
				case IG_CORE_PLATFORM.WIN64:
				case IG_CORE_PLATFORM.ASPEN64:
				case IG_CORE_PLATFORM.PS4:
					return 8;
			}
		}
	}
}