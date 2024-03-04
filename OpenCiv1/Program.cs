using Avalonia;

namespace OpenCiv1
{
	public static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// Initialization code. Don't use any Avalonia, third-party APIs or any
		/// SynchronizationContext-reliant code before AppMain is called: things aren't initialized
		/// yet and stuff might break.
		/// </summary>
		public static void Main(string[] args) =>
			BuildAvaloniaApp()
				.StartWithClassicDesktopLifetime(args);

		/// <summary>Avalonia configuration, don't remove; also used by visual designer.</summary>
		public static AppBuilder BuildAvaloniaApp() =>
			AppBuilder.Configure<App>()
				.UsePlatformDetect()
				.WithInterFont()
				.LogToTrace();
	}
}
