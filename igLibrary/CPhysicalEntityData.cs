namespace igLibrary
{
	public class CPhysicalEntityData : CGameEntityData
	{
		[igField(typeof(igUnsignedIntMetaField), 0x09, 0x00, 0x00, 0x8C, "_physicalEntityFlags")]
		public uint _physicalEntityFlags;
		[igField(typeof(igIntMetaField), 0x09, 0x00, 0x00, 0x90, "_health")]
		public int _health;
		[igField(typeof(igIntMetaField), 0x09, 0x00, 0x00, 0x98, "_healthMax")]
		public int _healthMax;
		[igField(typeof(igEnumMetaField<EVulnerability>), 0x09, 0x00, 0x00, 0xA0, "_vulnerability")]
		public EVulnerability _vulnerability;
	}
}