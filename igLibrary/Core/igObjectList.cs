namespace igLibrary.Core
{
	[sizeofSize(0xFF, 0x18, 0x28)]
	public class igObjectList<T> : igDataList<T, igObjectRefMetaField<T>> where T : igObject
	{
		public igObjectList() : base(){}
	}
	[sizeofSize(0xFF, 0x18, 0x28)]
	public class igObjectList : igObjectList<igObject>{}
}