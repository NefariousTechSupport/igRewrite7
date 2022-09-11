namespace igLibrary.Entity
{
	public class igEntityBolt : igObject
	{
		[igField(typeof(igHandleMetaField<igEntity>), 0x09, 0x00, 0x08, 0x10, "_entityToBoltTo")]
		public igHandle _entityToBoltTo;
	}
}