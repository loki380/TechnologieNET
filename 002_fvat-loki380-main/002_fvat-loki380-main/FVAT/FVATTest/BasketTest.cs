using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using FVAT;

namespace FVATTest
{
    public class Tests
    {
        private Product p1;
        private Product p2;
        private Adress a1;
        private Adress a2;
        private BankAccount b1;
        private Firm klient;
        private Seller seller;
        private Basket basket;
        private Bill Invoice;

        [SetUp]
        public void Setup()
        {
            p1 = new Product("Mleko", 5, 23);
            p2 = new Product("Cukier", 2, 23);
            a1 = new Adress("Kościerzyna", "83-124", "Kartuska", 11);
            a2 = new Adress("Kościerzyna", "83-1212", "Kartuska", 12);
            b1 = new BankAccount("kiolp");
            klient = new Firm("KMJ", "kmj113@gmail.com", a1, 1231231234);
            seller = new Seller(b1, "x", "kj113@gmail.com", a2, 1231231235);
            basket = new Basket(klient, seller);
            basket.AddProduct(p1, 3);
            basket.AddProduct(p2, 2);
            basket.Buy();
            Invoice = new Bill(basket);
        }
        [Test]
        public void CheckIfTestWorks()
        {
            Assert.Pass();
        }
        [Test]
        public void CheckIfCreateProductExist()
        {
            var product = new Product();
            Assert.That(product, Is.Not.Null);
        }
        [Test]
        public void CheckIfBankAccountExist()
        {
            Assert.That(b1, Is.Not.Null);
        }
        [Test]
        public void CheckIfAdressExist()
        {
            Assert.That(a1, Is.Not.Null);
        }
        [Test]
        public void CheckIfKlientExist()
        {
            Assert.That(klient, Is.Not.Null);
        }
        [Test]
        public void CheckIfSellerExist()
        {
            Assert.That(klient, Is.Not.Null);
        }
        [Test]
        public void CheckIfBasketExist()
        {
            Assert.That(basket, Is.Not.Null);
        }
        [Test]
        public void CheckIfInvoiceExist()
        {
            Assert.That(Invoice, Is.Not.Null);
        }
        [Test]
        public void CheckPropertyProduct()
        {
            Assert.That(p1.Name, Is.EqualTo("Mleko"));
            Assert.That(p1.netto, Is.EqualTo(5));
            Assert.That(p1.Vat, Is.EqualTo(23));
        }
        [Test]
        public void CheckBankAccountLenghtNumber()
        {
            Assert.That(b1.Number.Length, Is.EqualTo(26));
        }
        [Test]
        public void CheckPositionListLenght()
        {
            Assert.That(Invoice.Positions.Count, Is.EqualTo(2));
        }
        [Test]
        public void CheckFirstPositionInvoiceCreate()
        {
            var position = Invoice.Positions[0];
            Assert.That(position.name, Is.EqualTo("Mleko"));
            Assert.That(position.count, Is.EqualTo(3));
            Assert.That(position.netto, Is.EqualTo(5));
            Assert.That(position.fullnetto, Is.EqualTo(15));
            Assert.That(position.vat, Is.EqualTo(23));
            Assert.That(position.fullbrutto, Is.EqualTo(18.45));
        }
        [Test]
        public void TryAddOneProduct()
        {
            var p3 = new Product("Sol", 4, 23);
            basket.AddProduct(p3);
            Assert.That(basket.Content.ContainsKey(p3), Is.EqualTo(true));
        }
        [Test]
        public void TryAddExistProduct()
        {
            var tmp = basket.Content[p2]+3;
            basket.AddProduct(p2,3);
            
            Assert.That(basket.Content[p2], Is.EqualTo(tmp));
        }
        [Test]
        public void TryRemoveOneAmountOfProduct()
        {
            var tmp = basket.Content[p1]-1;
            basket.RemoveProduct(p1);
            Assert.That(basket.Content[p1], Is.EqualTo(tmp));
        }
        [Test]
        public void TryRemoveMoreProduct() {

            var tmp = basket.Content[p1] - 2;
            basket.RemoveProduct(p1, 2);
            Assert.That(basket.Content[p1], Is.EqualTo(tmp));
        }
        [Test]
        public void TryRemoveNotExistProduct()
        {
            basket.RemoveProduct(p1, 3);
            Assert.Throws<KeyNotFoundException>(() => basket.RemoveProduct(p1));
        }
        [Test]
        public void TryUpdateProduct()
        {
            basket.UpdateProduct(p1, 3);
            Assert.That(basket.Content[p1], Is.EqualTo(3));
        }
        [Test]
        public void CheckGetFinalBrutto()
        {
            var basket1 = new Basket(klient, seller);
            basket1.AddProduct(p1, 2);
            var Invoice1 = new Bill(basket1);
            var tmp = Invoice1.BruttoPrice;
            Assert.That(tmp, Is.EqualTo(12.3));
        }
    }
}
