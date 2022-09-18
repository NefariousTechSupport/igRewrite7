namespace igLibrary
{
	public class CPhysicalEntityData : CGameEntityData
	{
		[igField(typeof(igUnsignedIntMetaField), 0x09, 0x00, 0x58, 0x8C, "_physicalEntityFlags")]
		public uint _physicalEntityFlags;
		[igField(typeof(igIntMetaField), 0x09, 0x01, 0x5C, 0x90, "_health")]
		public int _health;
		[igField(typeof(igIntMetaField), 0x09, 0x02, 0x60, 0x98, "_healthMax")]
		public int _healthMax;
		[igField(typeof(igEnumMetaField<EVulnerability>), 0x09, 0x03, 0x64, 0xA0, "_vulnerability")]
		public EVulnerability _vulnerability;
	}
}