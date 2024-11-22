using System;

namespace EconomicApplication
{
    public class Market : MarketEntity
    {
        // Unique properties for Market
        private string _industry;
        private double _annualRevenue;

        // Public properties for industry and annualRevenue
        public string Industry
        {
            get { return _industry; }
            set { _industry = value; }
        }

        public double AnnualRevenue
        {
            get { return _annualRevenue; }
            set { _annualRevenue = value; }
        }

        // Constructor
        public Market(string name, string identifier, string industry, double annualRevenue)
            : base(name, identifier)
        {
            _industry = industry;
            _annualRevenue = annualRevenue;
        }

        // Overriding the abstract method from MarketEntity
        public override string GetEntityInfo()
        {
            return "Market: " + Name + " (ID: " + Identifier + ") - Industry: " + Industry + ", Annual Revenue: " + AnnualRevenue.ToString("C");
        }
    }
}