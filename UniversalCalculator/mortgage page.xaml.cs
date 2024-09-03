using System;
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
	public sealed partial class mortgage_page : Page
	{
		public mortgage_page()
		{
			this.InitializeComponent();
		}

		private void calculateButton_Click(object sender, RoutedEventArgs e)
		{
			double calculation = calculateMortgage();

			monthlyRepaymentTextBox.Text = calculation.ToString();
		}

		private double calculateMortgage()
		{
			double yearlyIntrestRate = double.Parse(yearlyIntrstRateTextBox.Text);
			double principleBorrow = double.Parse(principleBorrowTextBox.Text);
			int Years = int.Parse(yearsTextBox.Text);
			int andMonths = int.Parse(andMonthsTextBox.Text);

			double monthlyIntrestRate = yearlyIntrestRate / 12.0;
			monthlyIntrestRate = monthlyIntrestRate * 0.01;

			int numberOfPayments = Years * 12 + andMonths;

			double numerator = principleBorrow * Math.Pow(1 + monthlyIntrestRate, numberOfPayments) * monthlyIntrestRate;
			double denominator = Math.Pow(1 + monthlyIntrestRate, numberOfPayments) - 1;
			double monthlyRepayment = numerator / denominator;

			monthlyIntrstRateTextBox.Text = monthlyIntrestRate.ToString();

			return monthlyRepayment;
		}

		private void exitButton_Click(object sender, RoutedEventArgs e)
		{
			Frame.Navigate(typeof(MainMenu));
		}
	}
}
