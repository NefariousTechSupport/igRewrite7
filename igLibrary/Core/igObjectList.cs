namespace igLibrary.Core
{
	public class igObjectList<T> : igDataList<T, igObjectRefMetaField<T>> where T : igObject
	{
		public igObjectList() : base(){}
	}
	public class igObjectList : igObjectList<igObject>{}
}