namespace igLibrary.Core
{
	public static class igCore
	{
		public static Dictionary<string, Type> RegisteredTypes = GetRegisteredTypes();

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

		public static string GetPlatformString(IG_CORE_PLATFORM platform)
		{
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
		public static IG_CORE_PLATFORM GetPlatform(uint version, uint platform)
		{
			switch(version)
			{
				case 0x06:
					switch(platform)
					{
						case 0x00: return IG_CORE_PLATFORM.DEFAULT;
						case 0x01: return IG_CORE_PLATFORM.WIN32;
						case 0x02: return IG_CORE_PLATFORM.WII;
						case 0x03: return IG_CORE_PLATFORM.DEPRECATED;
						case 0x04: return IG_CORE_PLATFORM.ASPEN;
						case 0x05: return IG_CORE_PLATFORM.XENON;
						case 0x06: return IG_CORE_PLATFORM.PS3;
						case 0x07: return IG_CORE_PLATFORM.OSX;
						case 0x08: return IG_CORE_PLATFORM.WIN64;
						case 0x09: return IG_CORE_PLATFORM.CAFE;
						case 0x0A: return IG_CORE_PLATFORM.NGP;
						case 0x0B: return IG_CORE_PLATFORM.ANDROID;
						case 0x0C: return IG_CORE_PLATFORM.MARMALADE;
						case 0x0D: return IG_CORE_PLATFORM.MAX;
					}
					break;
				case 0x07:
				case 0x08:
				case 0x09:
					switch(platform)
					{
						case 0x00: return IG_CORE_PLATFORM.DEFAULT;
						case 0x01: return IG_CORE_PLATFORM.WIN32;
						case 0x02: return IG_CORE_PLATFORM.WII;
						case 0x03: return IG_CORE_PLATFORM.DURANGO;
						case 0x04: return IG_CORE_PLATFORM.ASPEN;
						case 0x05: return IG_CORE_PLATFORM.XENON;
						case 0x06: return IG_CORE_PLATFORM.PS3;
						case 0x07: return IG_CORE_PLATFORM.OSX;
						case 0x08: return IG_CORE_PLATFORM.WIN64;
						case 0x09: return IG_CORE_PLATFORM.CAFE;
						case 0x0A: return IG_CORE_PLATFORM.RASPI;
						case 0x0B: return IG_CORE_PLATFORM.ANDROID;
						case 0x0C:
							if(version == 0x07)      return IG_CORE_PLATFORM.MARMALADE;
							else if(version == 0x08) return IG_CORE_PLATFORM.DEPRECATED;
							else                     return IG_CORE_PLATFORM.ASPEN64;
						case 0x0D: return IG_CORE_PLATFORM.LGTV;
						case 0x0E: return IG_CORE_PLATFORM.PS4;
						case 0x0F: return IG_CORE_PLATFORM.WP8;
						case 0x10: return IG_CORE_PLATFORM.LINUX;
						case 0x11: return IG_CORE_PLATFORM.MAX;
					}
					break;
				default:
					Console.WriteLine($"WARNING: IG_CORE_PLATFORM FOR VERSION {version} NOT IMPLEMENTED");
					return IG_CORE_PLATFORM.DEFAULT;
			}
			return IG_CORE_PLATFORM.DEFAULT;
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