using System;
using System.Collections.Generic;
using System.Text;
using Market.Interface;

namespace Market
{
    public class ProductPrice : Product, IElement
    {
        private Product _product;
        private int _amount;
        private double _margin;
        private bool _pricerise = false;

        public ProductPrice(Product product, int amount, double margin) : base(product.Name, product.ProductionCost)
        {
            Product = product;
            Amount = amount;
            Margin = margin;
        }
        public bool Pricerise
        {
            get { return _pricerise; }
            set { _pricerise = value; }
        }
        public Product Product
        {
            get { return _product; }
            set { _product = value; }
        }

        public int Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }
        public double Margin
        {
            get { return _margin; }
            set { _margin = value; }
        }

        public void Accept(IVisitor aVisitor)
        {
            aVisitor.Visit(this); 
        }
        public override string ToString()
        {
            return "Name: " + Name + " Margin: "+ Margin+" Amount: "+Amount;
        }
    }
}
