using ScreenSaver.ViewModel.Interfaces;
using System.Diagnostics;
using System.Windows;

namespace ScreenSaver.ViewModel.Services;

public class ApplicationRestartService : IApplicationRestartService
{
	public void Restart()
	{
		var applicationPath = Environment.ProcessPath;

		if (applicationPath == null)
		{
			throw new ArgumentNullException("Application path is null");
		}

		Process.Start(applicationPath);

		Application.Current.Shutdown();
	}
}
