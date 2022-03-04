using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Transactions;

namespace FVAT
{
    public class Basket
    {
        public Dictionary<Product, int> Content { get; set; }
        public double Value { get; set; }

        public Firm Bussines { get; set; }

        public Seller Seller { get; set; }

        public DateTime saledate { get; set; }

        public Basket(Firm bussines, Seller seller){
            Content = new Dictionary<Product, int>();
            Bussines = bussines;
            Seller = seller;
            Value = 0;
        }

        public void AddProduct(Product product)
        {
            if (!Content.ContainsKey(product))
            {
                Content.Add(product, 1);
            }
            else
            {
                Content[product] = Content[product] + 1;
            }
/*            Console.WriteLine("Product {0} added. Amount = {1}",
                product.Name, Content[product]);*/
            UpdateValue();
        }
        public void AddProduct(Product product, int count)
        {
            if (!Content.ContainsKey(product))
            {
                Content.Add(product, count);
            }
            else
            {
                Content[product] = Content[product] + count;
            }
/*            Console.WriteLine("Product {0} added. Amount = {1}",
                product.Name, Content[product]);*/
            UpdateValue();
        }
        public void RemoveProduct(Product product)
        {
            if (!Content.ContainsKey(product))
            {
                throw new KeyNotFoundException();
            }
            else
            {
                Content[product] = Content[product] - 1;
            }
/*            Console.WriteLine("Product {0} removed. Amount = {1}",
                product.Name, Content[product]);*/
            UpdateValue();
        }
        public void RemoveProduct(Product product, int count)
        {
            if (!Content.ContainsKey(product))
            {
                throw new KeyNotFoundException();
            }
            else
            {
                if (Content[product] <= count) Content.Remove(product);
                else
                    Content[product] = Content[product] - count;
            }
/*            Console.WriteLine("Product {0} removed. Amount = {1}",
                product.Name, Content[product]);*/
            UpdateValue();
        }
        public void UpdateProduct(Product product, int count)
        {
            if (!Content.ContainsKey(product))
            {
                Content.Add(product, count);
            }
            else
            {
                Content[product] = count;
            }
/*            Console.WriteLine("Product {0} update. Amount = {1}",
                product.Name, Content[product]);*/
            UpdateValue();
        }
        public void UpdateValue()
        {
            foreach (var element in Content)
            {
                Value += element.Key.netto * element.Value;
            }
        }
        public double ItemValue(Product product)
        {
            return Content[product] * product.netto;
        }
        public void Buy()
        {
            saledate = DateTime.Now;
/*            Bill Invoice = new Bill(this);*/
        }
    }
}
