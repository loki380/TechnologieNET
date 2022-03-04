using Market;
using Market.Interface;
using System;
using NUnit.Framework;

namespace MarketTEST
{
    public class Tests
    {
        
        Product p1;
        Product p2;
        Product p3;
        Seller seller;
        Shopper shopper;
        CentralBank centralBank;

        [SetUp]
        public void Setup()
        {
            p1 = new Product("Mleko", 1.25);
            p2 = new Product("Cukier", 1.08);
            p3 = new Product("M¹ka", 2.1);
            seller = new Seller();
            shopper = new Shopper();
            centralBank = new CentralBank();
        }

        [Test]
        public void CheckTestPass()
        {
            Assert.Pass();
        }
        [Test]
        public void CheckBankCreate()
        {
            Assert.That(centralBank, Is.Not.Null);
        }
        [Test]
        public void CheckSellerCreate()
        {
            Assert.That(seller, Is.Not.Null);
        }
        [Test]
        public void CheckShopperCreate()
        {
            Assert.That(shopper, Is.Not.Null);
        }
        [Test]
        public void CheckProductCreate()
        {
            Assert.That(p1, Is.Not.Null);
        }
        [Test]
        public void CheckBankAttach()
        {
            centralBank.Attach(seller);
            centralBank.Attach(shopper);
            Assert.That(centralBank.List.Contains(seller), Is.True);
            Assert.That(centralBank.List.Contains(shopper), Is.True);
        }
        [Test]
        public void CheckBankDetach()
        {
            centralBank.Detach(seller);
            centralBank.Detach(shopper);
            Assert.That(centralBank.List.Contains(seller), Is.False);
            Assert.That(centralBank.List.Contains(shopper), Is.False);
        }
        [Test]
        public void CheckBankNotify_OneChange()
        {
            centralBank.Attach(seller);
            centralBank.Attach(shopper);
            centralBank.Inflation = 5;
            Assert.That(shopper.Inflation, Is.EqualTo(5));
            Assert.That(seller.Inflation, Is.EqualTo(5));
        }
        [Test]
        public void CheckBankNotify_TwoChanges()
        {
            centralBank.Attach(seller);
            centralBank.Attach(shopper);
            centralBank.Inflation = 5;
            centralBank.Inflation = 7;
            Assert.That(shopper.Inflation, Is.EqualTo(7));
            Assert.That(seller.Inflation, Is.EqualTo(7));
        }
        [Test]
        public void CheckAddProductToSeller()
        {
            seller.AddProduct(p1,1,0.2);
            ProductPrice result = seller.Products.Find(x => x.Product == p1);
            Assert.That(result, Is.Not.Null);
        }
        [Test]
        public void CheckRemoveProductFromSeller()
        {
            seller.AddProduct(p1, 1, 0.2);
            seller.RemoveProduct(p1);
            ProductPrice result = seller.Products.Find(x => x.Product == p1);
            Assert.That(result, Is.Null);
        }
        [Test]
        public void CheckRemoveNotExistProductFromSeller() {
            seller.RemoveProduct(p1);
            ProductPrice result = seller.Products.Find(x => x.Product == p1);
            Assert.That(result, Is.Null);
        }
        [Test]
        public void CheckSellerAttach()
        {
            seller.Attach(shopper);
            Assert.That(seller.List.Contains(shopper), Is.True);
        }
        [Test]
        public void CheckSellerDetach()
        {
            seller.Attach(shopper);
            seller.Detach(shopper);
            Assert.That(seller.List.Contains(shopper), Is.False);
        }
        [Test]
        public void Seller_Notify()
        {
            centralBank.Attach(seller);
            centralBank.Attach(shopper);
            centralBank.Inflation = 1;
            seller.AddProduct(p1, 5, 0.25);
            seller.AddProduct(p2, 2, 0.1);
            seller.AddProduct(p3, 1, 0.3);
            seller.Attach(shopper);
            shopper.AddNeeds(p1);
            shopper.AddNeeds(p3);
            shopper.Needs[p1] = 5;
            centralBank.Inflation = 2;
            Assert.That(shopper.Needs[p1], Is.EqualTo(4));
        }
        [Test]
        public void CheckGetPrice()
        {
            ProductPrice result = new ProductPrice(p1, 2, 0.25);
            Assert.That(shopper.GetPrice(result,1), Is.EqualTo(1.5));
        }
        [Test]
        public void CheckAddNeedsToShooper()
        {
            shopper.AddNeeds(p1);
            Assert.That(shopper.Needs.ContainsKey(p1), Is.True);
        }
        [Test]
        public void CheckRemoveNeedsFromShooper()
        {
            shopper.AddNeeds(p1);
            shopper.RemoveNeeds(p1);
            Assert.That(shopper.Needs.ContainsKey(p1), Is.False);
        }
    }
}