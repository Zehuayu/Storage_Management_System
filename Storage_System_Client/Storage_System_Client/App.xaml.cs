﻿using Xamarin.Forms;

namespace Storage_System_Client
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			MainPage = new Storage_System_ClientPage();
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
