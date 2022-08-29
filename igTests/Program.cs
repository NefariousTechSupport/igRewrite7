namespace igRewrite7
{
	public static class Program
	{
		public static void Main(string[] args)
		{
			Window wnd = new Window(
				new GameWindowSettings()
				{
					IsMultiThreaded = false
				},
				new NativeWindowSettings()
				{
					Size = new Vector2i(1280, 720),
					Title = "igRewrite7",
					Flags = ContextFlags.ForwardCompatible
				},
				args
			);

			wnd.Run();
		}
	}
}