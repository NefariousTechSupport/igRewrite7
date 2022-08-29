namespace igLibrary.Core
{
	public class igSingleton<T> where T : class, new()
	{
		private static Lazy<T> lazy = new Lazy<T>(() => new T());
		public static T Singleton => lazy.Value;
	}
}