﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Calculator
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class MainMenu : Page
	{
		public MainMenu()
		{
			this.InitializeComponent();
		}

		private void MathCalculatorButton_Click(object sender, RoutedEventArgs e)
		{
			Frame.Navigate(typeof(MainPage));
		}

		private void MortgageCalculatorButton_Click(object sender, RoutedEventArgs e)
		{
			Frame.Navigate(typeof(mortgage_page));
		}

		private void CurrencyCalculatorButton_Click(object sender, RoutedEventArgs e)
		{
			Frame.Navigate(typeof(CurrencyPage));
		}

		private void ExitButton_Click(object sender, RoutedEventArgs e)
		{
			Application.Current.Exit();
		}

		private async void TripCalculatorButton_Click(object sender, RoutedEventArgs e)
		{
			ContentDialog popup = new ContentDialog()
			{
				Title = "Trip calculator",
				Content = "Trip calculator c# code will be developed later",
				CloseButtonText = "Ok"
			};

			await popup.ShowAsync();
		}
	}
}
