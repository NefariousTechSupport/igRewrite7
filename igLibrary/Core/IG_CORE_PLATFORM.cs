namespace igLibrary.Core
{
	//While this is really nice to have, it can't be used for reading the igz header since IG_CORE_PLATFORM changes between games, hence you see the tomfoolery happen
	public enum IG_CORE_PLATFORM : uint
	{
		[igMetaEnumMember(0xFF, 0x00, "IG_CORE_PLATFORM_DEFAULT")]
		DEFAULT,

		[igMetaEnumMember(0x06, 0x03, "IG_CORE_PLATFORM_DEPRECATED")]
		[igMetaEnumMember(0x08, 0x0C, "IG_CORE_PLATFORM_DEPRECATED")]
		DEPRECATED,

		[igMetaEnumMember(0xFF, 0x01, "IG_CORE_PLATFORM_WIN32")]
		WIN32,		//32-bit Windows

		[igMetaEnumMember(0xFF, 0x02, "IG_CORE_PLATFORM_WII")]
		WII,		//Wii

		[igMetaEnumMember(0xFF, 0x03, "IG_CORE_PLATFORM_DURANGO")]
		DURANGO,	//Xbox One

		[igMetaEnumMember(0xFF, 0x04, "IG_CORE_PLATFORM_ASPEN")]
		ASPEN,		//32-bit iOS

		[igMetaEnumMember(0xFF, 0x05, "IG_CORE_PLATFORM_XENON")]
		XENON,		//Xbox 360

		[igMetaEnumMember(0xFF, 0x06, "IG_CORE_PLATFORM_PS3")]
		PS3,		//PS3

		[igMetaEnumMember(0xFF, 0x07, "IG_CORE_PLATFORM_OSX")]
		OSX,		//Mac

		[igMetaEnumMember(0xFF, 0x08, "IG_CORE_PLATFORM_WIN64")]
		WIN64,		//64-bit Windows

		[igMetaEnumMember(0xFF, 0x09, "IG_CORE_PLATFORM_CAFE")]
		CAFE,		//Wii U

		[igMetaEnumMember(0x06, 0x0A, "IG_CORE_PLATFORM_NGP")]
		NGP,		//PS Vita

		[igMetaEnumMember(0x07, 0x0C, "IG_CORE_PLATFORM_MARMALADE")]
		MARMALADE,	//Something NVIDEA made https://youtu.be/uC16fCnI62Y

		[igMetaEnumMember(0xFF, 0x0A, "IG_CORE_PLATFORM_RASPI")]
		RASPI,		//Raspberry Pi

		[igMetaEnumMember(0xFF, 0x0B, "IG_CORE_PLATFORM_ANDROID")]
		ANDROID,	//Android

		[igMetaEnumMember(0x09, 0x0C, "IG_CORE_PLATFORM_ASPEN64")]
		ASPEN64,	//64-bit iOS

		[igMetaEnumMember(0xFF, 0x0D, "IG_CORE_PLATFORM_LGTV")]
		LGTV,		//LG TV

		[igMetaEnumMember(0xFF, 0x0E, "IG_CORE_PLATFORM_PS4")]
		PS4,		//PS4

		[igMetaEnumMember(0xFF, 0x0F, "IG_CORE_PLATFORM_WP8")]
		WP8,		//Windows Phone 8 (presumably)

		[igMetaEnumMember(0xFF, 0x10, "IG_CORE_PLATFORM_LINUX")]
		LINUX,		//Linux

		[igMetaEnumMember(0x06, 0x0D, "IG_CORE_PLATFORM_MAX")]
		[igMetaEnumMember(0xFF, 0x11, "IG_CORE_PLATFORM_MAX")]
		MAX			//Platform count
	}
}