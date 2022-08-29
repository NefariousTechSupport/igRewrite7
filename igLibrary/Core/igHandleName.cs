namespace igLibrary.Core
{
	[igStruct(0xFF, 0x10, 0x20)]
	public struct igHandleName
	{
		public igName _ns;		//probably namespace
		public igName _name;	//probably object name
	}
}