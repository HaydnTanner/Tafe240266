using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{

	class CurrencyValues
	{
		public double USD;
		public double Euro;
		public double BritishPound;
		public double IndianRupee;

		public string Symbol = "";
		public string Name = "";

		public CurrencyValues(double USD, double Euro, double BritishPound, double IndianRupee, string Symbol, string Name)
		{
			this.USD = USD;
			this.Euro = Euro;
			this.BritishPound = BritishPound;
			this.IndianRupee = IndianRupee;
			this.Symbol = Symbol;
			this.Name = Name;
		}
	}

}
