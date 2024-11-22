using System;

namespace EconomicApplication
{
    public class Consumer : MarketEntity
    {
        // Unique properties for Consumer
        private int _age;
        private string _location;

        // Public properties for age and location
        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }

        public string Location
        {
            get { return _location; }
            set { _location = value; }
        }

        // Constructor
        public Consumer(string name, string identifier, int age, string location)
            : base(name, identifier)
        {
            _age = age;
            _location = location;
        }

        // Overriding the abstract method from MarketEntity
        public override string GetEntityInfo()
        {
            return "Consumer: " + Name + " (ID: " + Identifier + ") - Age: " + Age + ", Location: " + Location;
        }
    }
}