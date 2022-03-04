using System;
using System.Collections.Generic;

namespace Market
{
    class Program
    {
        static void Main(string[] args)
        {
            Product p1 = new Product("Mleko", 1.25);
            Product p2 = new Product("Cukier", 1.08);
            Product p3 = new Product("Mąka", 2.1);
            Seller seller = new Seller();
            Shopper shopper = new Shopper();
            CentralBank centralBank = new CentralBank();
            centralBank.Attach(seller);
            centralBank.Attach(shopper);
            centralBank.Inflation = 1;
            seller.AddProduct(p1, 5, 0.25);
            seller.AddProduct(p2, 2, 0.1);
            seller.AddProduct(p3, 1, 0.3);
            seller.Attach(shopper);
            shopper.AddNeeds(p1);
            shopper.AddNeeds(p3);
            Console.WriteLine("PRÓBA 1\n");
            foreach (KeyValuePair<Product, int> kvp in shopper.Needs)
            {
                Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
            }
            seller.Products.ForEach(Console.WriteLine);
            Console.WriteLine("PRÓBA 2\n");
            centralBank.Inflation = 2;
            foreach (KeyValuePair<Product, int> kvp in shopper.Needs)
            {
                Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
            }
            seller.Products.ForEach(Console.WriteLine);
            Console.WriteLine("PRÓBA 3\n");
            centralBank.Inflation = 1.1;
            foreach (KeyValuePair<Product, int> kvp in shopper.Needs)
            {
                Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
            }
            seller.Products.ForEach(Console.WriteLine);
            Console.WriteLine("PRÓBA 4\n");
            centralBank.Inflation = 1.2;
            foreach (KeyValuePair<Product, int> kvp in shopper.Needs)
            {
                Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
            }
            seller.Products.ForEach(Console.WriteLine);
            Console.WriteLine("\nInflacja w banku = "+centralBank.Inflation);
            Console.WriteLine("Inflacja u sprzedawcy = " + seller.Inflation);
            Console.WriteLine("Inflacja u kupującego = " + shopper.Inflation);
        }
    }
}
