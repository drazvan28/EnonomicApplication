using System;

namespace EconomicApplication
{
    public class Product
    {
        // Private fields
        private string _name;
        private double _price;
        private string _category;

        // Public properties for name, price, and category
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public double Price
        {
            get { return _price; }
            set { _price = value; }
        }

        public string Category
        {
            get { return _category; }
            set { _category = value; }
        }

        // Constructor
        public Product(string name, double price, string category)
        {
            _name = name;
            _price = price;
            _category = category;
        }

        // Method to display product details
        public string GetProductDetails()
        {
            return "Product: " + Name + " - Price: " + Price.ToString("C") + ", Category: " + Category;
        }
    }
}