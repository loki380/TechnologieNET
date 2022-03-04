using System;
using System.Collections.Generic;
using System.Text;

namespace Market
{
    public class Product
    {
        private string _name;

        private double _productionCost;

        public Product() { }
        public Product(string name, double productionCost)
        {
            _name = name;
            _productionCost = productionCost;
        }

        public double ProductionCost
        {
            get { return _productionCost; }
            set { _productionCost = value; }
        }

        public string Name
        {
            get { return _name; }
            set {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("First name must not be blank");
                _name = value;
            }
        }
    }
}
