﻿using ScreenSaver.ViewModel.ViewModels;
using System.Configuration;
using System.Data;
using System.Windows;

namespace ScreenSaver.View
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		protected override void OnStartup(StartupEventArgs e)
		{
			base.OnStartup(e);

			MainWindow = new MainWindow();
			MainWindow.DataContext = new MainViewModel();

			MainWindow.Show();
		}

	}

}
