namespace igLibrary.Gfx
{
	public enum IG_VERTEX_USAGE : byte
	{
		POSITION = 0x00,
		NORMAL = 0x01,
		TANGENT = 0x02,
		BINORMAL = 0x03,
		COLOR = 0x04,
		TEXCOORD = 0x05,
		BLENDWEIGHTS = 0x06,
		UNUSED_0 = 0x07,
		BLENDINDICIES = 0x08,
		FOGCOORD = 0x09,
		PSIZE = 0x0A,
	}
}