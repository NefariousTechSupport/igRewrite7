namespace MiscTests.IGZGen
{
	public static class Program
	{
		public static void Main(string[] args)
		{
			igObjectDirectory dir = new igObjectDirectory();
			dir._objectList.Append(new igObject());
			igIGZSaver saver = new igIGZSaver(dir);
			saver.Save(args[0], IG_CORE_PLATFORM.PS3, 0x09);
		}
	}
}