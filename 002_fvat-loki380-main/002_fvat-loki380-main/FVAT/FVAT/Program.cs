using System;

namespace FVAT
{
    class Program
    {
        static void Main(string[] args)
        {
            Product p1 = new Product("maka", 1.2,8);
            Product p2 = new Product("cukier", 2.3,10);
            Product p3 = new Product("sol", 4,23);
            Product p4 = new Product("olej", 10,23);
            Product p5 = new Product("mleko", 1.4,23);
            Product p6 = new Product("batonik", 3.1,23);

            Adress a1 = new Adress("Kościerzyna", "83-124", "Kartuska", 11);
            Adress a2 = new Adress("Kościerzyna", "83-1212", "Kartuska", 12);
            BankAccount b1 = new BankAccount("kiolp");

            Firm klient = new Firm("KMJ", "kmj113@gmail.com", a1, 1231231234);
            Seller seller = new Seller(b1, "Media", "kj113@gmail.com", a2, 1231231235);

            Basket basket = new Basket(klient, seller);
            basket.AddProduct(p2, 3);
            basket.AddProduct(p3, 2);
            basket.Buy();
            Bill Invoice = new Bill(basket);
            Console.WriteLine(Invoice.ToString());
        }
    }
}
