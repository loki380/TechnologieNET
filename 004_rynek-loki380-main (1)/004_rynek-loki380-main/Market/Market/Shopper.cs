using System;
using System.Collections.Generic;
using System.Text;
using Market.Interface;

namespace Market
{
    public class Shopper : IVisitor, IObserver<Seller>, IObserver<CentralBank>
    {
        private Dictionary<Product, int> _needs = new Dictionary<Product, int>();
        private double _inflation;
        private double _credit;

        public Shopper()
        {
        }

        public double Inflation
        {
            get { return _inflation; }
            set { _inflation = value; }
        }
        public Dictionary<Product, int> Needs
        {
            get { return _needs; }
            set { _needs = value; }
        }
        public double Credit
        {
            get { return _credit; }
            set { _credit = value; }
        }
        public void AddNeeds(Product p)
        {
            Random rnd = new Random();
            int x = rnd.Next(11);
            _needs.Add(p, x);
        }
        public void RemoveNeeds(Product p)
        {
            _needs.Remove(p);
        }
        public Double GetPrice(ProductPrice p, double inflation)
        {
            return (p.ProductionCost + p.Margin) * inflation;
        }

        public void Update(Seller element)
        {
            foreach(ProductPrice x in element.Products)
            {

                if (x.Amount == 0)
                {
                    element.RemoveProduct(x.Product);
                }
                else if(_needs.ContainsKey(x.Product))
                {
                    if (x.Pricerise)
                    {
                        _needs[x.Product]--;
                    }
                    else if (!x.Pricerise)
                    {
                        _needs[x.Product]++;
                    }
                    if (_needs[x.Product] >= 10)
                    {
                        _credit -= GetPrice(x, Inflation);
                        _needs.Remove(x.Product);
                        x.Accept(this);
                    }
                }
            }
        }

        public void Update(CentralBank element)
        {
            Inflation = element.Inflation;
        }

        public void Visit(ProductPrice element)
        {
            element.Amount--;
        }
    }
}
