namespace igLibrary.Core
{
	//While this is really nice to have, it can't be used for reading the igz header since IG_CORE_PLATFORM changes between games, hence you see the tomfoolery happen
	public enum IG_CORE_PLATFORM : uint
	{
		DEFAULT,
		DEPRECATED,
		WIN32,		//32-bit Windows
		WII,		//Wii
		DURANGO,	//Xbox One
		ASPEN,		//32-bit iOS
		XENON,		//Xbox 360
		PS3,		//PS3
		OSX,		//Mac
		WIN64,		//64-bit Windows
		CAFE,		//Wii U
		NGP,		//PS Vita
		MARMALADE,	//Something NVIDEA made https://youtu.be/uC16fCnI62Y
		RASPI,		//Raspberry Pi
		ANDROID,	//Android
		ASPEN64,	//64-bit iOS
		LGTV,		//LG TV
		PS4,		//PS4
		WP8,		//Windows Phone 8 (presumably)
		LINUX,		//Linux
		MAX			//Platform count
	}
}