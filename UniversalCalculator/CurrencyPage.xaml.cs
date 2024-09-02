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


		private CurrencyValues FromUSD = new CurrencyValues(1, 0.85189982, 0.72872436, 74.257327, "$", "US Dollar");
		private CurrencyValues FromEuro = new CurrencyValues(1.1739732, 1, 0.8556672, 87.00755, "€", "Euro");
		private CurrencyValues FromBritishPound = new CurrencyValues(1.371907, 1.1686692, 1, 101.68635, "£", "British Pound");
		private CurrencyValues FromIndianRupee = new CurrencyValues(0.011492628, 0.013492774, 0.0098339397, 1, "₹", "Indian Rupee");

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


		private void Page_Loaded(object sender, RoutedEventArgs e)
		{
			CalculateButton_Click(sender, e);
		}

		private void CalculateButton_Click(object sender, RoutedEventArgs e)
		{

			//error checking for currency input

			CurrencyValues FromValues = null;
			CurrencyValues ToValues = null;


			//Two switch statements to figure out which currencys the user wants to convert
			switch (ConvertFromComboBox.SelectedIndex)
			{
				case (int)CurrencyIDs.USDollar:
					FromValues = FromUSD;
					break;
				case (int)CurrencyIDs.Euro:
					FromValues = FromEuro;
					break;
				case (int)CurrencyIDs.BritishPound:
					FromValues = FromBritishPound;
					break;
				case (int)CurrencyIDs.IdianRupee:
					FromValues = FromIndianRupee;
					break;
			}
			switch (ConvertToComboBox.SelectedIndex)
			{
				case (int)CurrencyIDs.USDollar:
					ToValues = FromUSD;
					break;
				case (int)CurrencyIDs.Euro:
					ToValues = FromEuro;
					break;
				case (int)CurrencyIDs.BritishPound:
					ToValues = FromBritishPound;
					break;
				case (int)CurrencyIDs.IdianRupee:
					ToValues = FromIndianRupee;
					break;
			}

			//check if there has been a error with selecting the currencys
			if (FromValues == null || ToValues == null)
				return;

			//convert the users inputed amount
			double Converted = ConvertCurrency(FromValues, ToValues.Name, double.Parse(CurrencyInput.Text));
			//output the date on to the page
			UserCurrencyOutput.Text = $"{CurrencyInput.Text} {FromValues.Name} =";
			UserCurrencyConversionOutput.Text = $"{ToValues.Symbol}{Converted} {ToValues.Name}";

			//the bellow code could be done better as it is currently calculating values from one unit of currencys
			//however the base numbers in the CurrencyValues classes are already the expected values from the calculations
			//so it would be best to create a way to get these numbers in stead of calculating them
			Converted = ConvertCurrency(FromValues, ToValues.Name, 1);
			OneUnitConversionFrom.Text = $"1 {FromValues.Name} = {Converted} {ToValues.Name}";

			Converted = ConvertCurrency(ToValues, FromValues.Name, 1);
			OneUnitConversionTo.Text = $"1 {ToValues.Name} = {Converted} {FromValues.Name}";
		}


		private double ConvertCurrency(CurrencyValues From, string ToName, double toConvert)
		{

			//i dont like having hard coded values here in the switch statement
			switch (ToName)
			{
				case "US Dollar":
					return toConvert * From.USD;
				case "Euro":
					return toConvert * From.Euro;
				case "British Pound":
					return toConvert * From.BritishPound;
				case "Indian Rupee":
					return toConvert * From.IndianRupee;
			}

			//return -1 if there is a error
			return -1;
		}

	}
}
