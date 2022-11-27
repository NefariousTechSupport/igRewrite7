namespace igCauldron;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main(string[] args)
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
		if(args.Length > 0)
		{
			Application.Run(new IGZForm(System.IO.File.OpenRead(args[0])));
		}
		else
		{
	        Application.Run(new MainForm());
		}
    }    
}