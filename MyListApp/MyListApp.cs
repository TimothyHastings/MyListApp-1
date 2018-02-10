//
// Copyright (c), 2017. Object Training Pty Ltd. All rights reserved.
// Written by Dr Tim Hastings.
//

using System;
using Xamarin.Forms;

namespace MyListApp
{
	/// <summary>
	/// The App.
	/// </summary>
	public class App : Application
	{
		public App()
		{
			MainPage = new NavigationPage(new MyListPage());
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
