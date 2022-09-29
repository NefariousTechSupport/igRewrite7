namespace igLibrary.Core
{
	[sizeofSize(0xFF, 0x24, 0x40)]
	public class igInfo : igReferenceResolver
	{
		[igField(typeof(igObjectRefMetaField<igDirectory>), 0xFF, 0, 0x0C, 0x18, "_directory")]
		public igDirectory _directory;
		[igField(typeof(igBoolMetaField), 0xFF, 1, 0x10, 0x20, "_resolveState")]
		public bool _resolveState;
	}
}