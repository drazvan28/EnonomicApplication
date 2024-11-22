using System;

namespace EconomicApplication
{
    public abstract class MarketEntity
    {
        // Private fields
        private string _name;
        private string _identifier;

        // Public properties
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Identifier
        {
            get { return _identifier; }
            set { _identifier = value; }
        }

        // Constructor
        public MarketEntity(string name, string identifier)
        {
            _name = name;
            _identifier = identifier;
        }

        // Abstract method to be overridden by subclasses
        public abstract string GetEntityInfo();

        // Override ToString method
        public override string ToString()
        {
            return "Name: " + Name + ", Identifier: " + Identifier;
        }
    }
}