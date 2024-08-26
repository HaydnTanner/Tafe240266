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
	public sealed partial class CurrencyPage : Page
	{

		private CurrencyValues FromUSD = new CurrencyValues(1, 0.85189982, 0.72872436, 74.257327, "$", "US Dollars");
		private CurrencyValues FromEuro = new CurrencyValues(1.1739732, 1, 0.8556672, 87.00755, "€", "Euros");
		private CurrencyValues FromBritishPound = new CurrencyValues(1.371907, 1.1686692, 1, 101.68635, "£", "British Pounds");
		private CurrencyValues FromIndianRupee = new CurrencyValues(0.011492628, 0.013492774, 0.0098339397, 1, "₹", "Indian Rupees");

		enum CurrencyIDs
		{
			USDollar = 0,
			Euro = 1,
			BritishPound = 2,
			IdianRupee = 3
		}


		public CurrencyPage()
		{
			this.InitializeComponent();
		}

		private void CalculateButton_Click(object sender, RoutedEventArgs e)
		{

			//error checking for currency input

			CurrencyValues SelectedValues = null;

			switch (ConvertFromComboBox.SelectedIndex)
			{
				case (int)CurrencyIDs.USDollar:
					SelectedValues = FromUSD;
					break;
				case (int)CurrencyIDs.Euro:
					SelectedValues = FromEuro;
					break;
				case (int)CurrencyIDs.BritishPound:
					SelectedValues = FromBritishPound;
					break;
				case (int)CurrencyIDs.IdianRupee:
					SelectedValues = FromIndianRupee;
					break;
			}

			if (SelectedValues == null)
				return;

			double Converted = ConvertCurrency(SelectedValues, ConvertToComboBox.SelectedIndex, double.Parse(CurrencyInput.Text));


			UserCurrencyOutput.Text = $"{CurrencyInput.Text} {SelectedValues.Name} =";
			UserCurrencyConversionOutput.Text = $"{Converted} ";


		}


		private double ConvertCurrency(CurrencyValues From, int To, double toConvert)
		{
			switch(To)
			{
				case (int)CurrencyIDs.USDollar:
					return toConvert * From.USD;
				case (int)CurrencyIDs.Euro:
					return toConvert * From.Euro;
				case (int)CurrencyIDs.BritishPound:
					return toConvert * From.BritishPound;
				case (int)CurrencyIDs.IdianRupee:
					return toConvert * From.IndianRupee;
			}

			return -1;
		}


	}
}
