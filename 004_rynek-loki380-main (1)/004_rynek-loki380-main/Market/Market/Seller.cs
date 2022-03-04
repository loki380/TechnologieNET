using System;
using System.Collections.Generic;
using System.Text;
using Market.Interface;

namespace Market
{
    public class Seller : IObserver<CentralBank>, IObservable<Seller>
    {
        private List<IObserver<Seller>> _list = new List<IObserver<Seller>>();
        private List<ProductPrice> _products;
        private double _inflation;

        public Seller()
        {
            _products = new List<ProductPrice>();
        }
        
        public double Inflation
        {
            get { return _inflation; }
            set { _inflation = value; }
        }
        public List<ProductPrice> Products
        {
            get { return _products; }
            set { _products = value; }
        }
        public List<IObserver<Seller>> List
        {
            get { return _list; }
            set
            { _list = value; }
        }
        public void AddProduct(Product p, int amount, double margin)
        {
            _products.Add(new ProductPrice(p,amount,margin));
        }

        public void Attach(IObserver<Seller> obs)
        {
            _list.Add(obs);
        }

        public void Detach(IObserver<Seller> obs)
        {
            _list.Remove(obs);
        }

        public void Notify()
        {
            foreach (IObserver<Seller> p in _list)
            {
                p.Update(this);
            }
        }

        public void RemoveProduct(Product p)
        {
            foreach(ProductPrice x in Products)
            {
                if (x.Product == p)
                {
                    _products.Remove(x);
                    break;
                }
            }
        }
        public Double GetPrice(ProductPrice p, double inflation)
        {
            return (p.ProductionCost + p.Margin) * inflation;
        }

        public void Update(CentralBank element)
        {
            foreach (ProductPrice x in Products)
            {
                double tmp = GetPrice(x, Inflation);
                double y = tmp / element.Inflation - x.ProductionCost;
                if (y > 0)
                {
                    x.Margin = y;
                }
                if (GetPrice(x, Inflation) < GetPrice(x, element.Inflation)) x.Pricerise = true;
                else x.Pricerise = false;
            }
            Inflation = element.Inflation;
            Notify();
        }
    }
}
