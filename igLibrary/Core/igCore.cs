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
		public static byte GetSizeOfPointer(IG_CORE_PLATFORM platform) => IsPlatform64Bit(platform) ? (byte)8 : (byte)4;
	}
}