namespace igLibrary
{
	public class CEntityData : Entity.igEntityData
	{
		[igField(typeof(igUnsignedIntMetaField), 0x09, 0x00, 0x10, 0x1C, "_entityFlags")]
		public uint _entityFlags;
		[igField(typeof(igUnsignedIntMetaField), 0x09, 0x01, 0x14, 0x20, "_actionEntityFlags")]
		public uint _actionEntityFlags;
		[igField(typeof(igEnumMetaField<EEntityTeam>), 0x09, 0x02, 0x18, 0x24, "_team")]
		public EEntityTeam _team;
		[igField(typeof(igEnumMetaField<EEntityTeamFaction>), 0x09, 0x03, 0x1C, 0x28, "_teamFaction")]
		public EEntityTeamFaction _teamFaction;
		[igField(typeof(igObjectRefMetaField<igObject>), 0x09, 0x04, 0x20, 0x30, "_tags")]
		public igObject _tags;	//CEntityTagSet

		public enum EEntityTeam : int
		{
			eET_None = 0,
			eET_Hero = 1,
			eET_Enemy = 2,
			eET_AltEnemy = 3
		}

		public enum EEntityTeamFaction : int
		{
			eETF_None = 0,
			eETF_Faction_2 = 2,
			eETF_Faction_3 = 3,
			eETF_Faction_4 = 4,
			eETF_Faction_5 = 5,
			eETF_Faction_6 = 6,
			eETF_Faction_7 = 7,
			eETF_Faction_8 = 8,
		}
	}
}