using NUnit.Framework;
using RejestrPracownikow;
using System;

namespace RejestrPracownikowTEST
{
    public class Tests
    {
        Rejestr rejestr;
        Address a;
        [SetUp]
        public void Setup()
        {
            rejestr = new Rejestr();
            a = new Address("Bytów", "Rolna", 5, 1);
        }

        [Test]
        public void SprawdzTestowanie()
        {
            Assert.Pass();
        }
        [Test]
        public void SprawdzUtworzenieRejestru()
        {
            Assert.That(rejestr, Is.Not.Null);
        }
        [Test]
        public void SprawdzUtworzeniePracownikaBiurowego()
        {
            var pracownik = new PracownikBiurowy(1, "Jas", "Kuper", 25, 36, a, 5, 70);
            Assert.That(pracownik, Is.Not.Null);
        }
        [Test]
        public void SprobujUtworzycPracownikaBiurowegoZBlednymiAgrumentami()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new PracownikBiurowy(1, "Jas", "Kuper", 25, 36, a, 6, 60));
        }
        [Test]
        public void SprobujUtworzycPracownikaBiurowegoZIstniejacymIdBiurowym()
        {
            var pracownik = new PracownikBiurowy(1, "Jas", "Kuper", 25, 36, a, 8, 80);

            Assert.Throws<ArgumentException>(() => new PracownikBiurowy(2, "Jas", "Kuper", 25, 36, a, 8, 80));
        }
        [Test]
        public void SprawdzUtworzeniePracownikaFizycznego()
        {
            var pracownik = new PracownikFizyczny(1, "Jas", "Kuper", 25, 36, a, 100);
            Assert.That(pracownik, Is.Not.Null);
        }
        [Test]
        public void SprobujUtworzycPracownikaFizycznegoZBlednymiAgrumentami()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new PracownikFizyczny(1, "Jas", "Kuper", 25, 36, a, 120));
        }
        [Test]
        public void SprawdzUtworzenieHandlarza()
        {
            var pracownik = new Handlarz(1, "Jas", "Kuper", 25, 36, a, Wydajnosc.NISKA, 1);
            Assert.That(pracownik, Is.Not.Null);
        }
        [Test]
        public void SprobujDodacPracownikaDoRejestru()
        {
            var pracownik = new Handlarz(1, "Jas", "Kuper", 25, 36, a, Wydajnosc.NISKA, 1);
            rejestr.Dodaj(pracownik);
            var result = false;
            foreach(Pracownik x in rejestr.Pracownicy)
            {
                if (x == pracownik) result = true;
            }
            Assert.That(result, Is.True);
        }
        [Test]
        public void SprobujDodacPracownikaZIstniej¹cymId()
        {
            var pracownik = new Handlarz(1, "Jas", "Kuper", 25, 36, a, Wydajnosc.NISKA, 1);
            var pracownik1 = new Handlarz(1, "Konrad", "Kuper", 25, 36, a, Wydajnosc.NISKA, 1);
            rejestr.Dodaj(pracownik);
            Assert.Throws<ArgumentException>(() => rejestr.Dodaj(pracownik1));
        }
        [Test]
        public void SprobujDodacKilkuPracownikaDoRejestru()
        {
            var p1 = new Handlarz(1, "Jas", "Kuper", 25, 36, a, Wydajnosc.NISKA, 1);
            var p2 = new PracownikBiurowy(2, "Jas", "Kuper", 25, 36, a, 3, 70);
            var p3 = new PracownikFizyczny(3, "Jas", "Kuper", 25, 36, a, 100);
            Pracownik[] p = new Pracownik[] { p1, p2, p3 };
            rejestr.Dodaj(p);
            var result = 0;
            foreach (Pracownik x in rejestr.Pracownicy)
            {
                foreach (Pracownik y in p)
                {
                    if (y == x) result++;
                }
            }
            Assert.That(result, Is.EqualTo(p.Length));
        }
        [Test]
        public void SprobujDodacKilkuPracownikowZIstniej¹cymId()
        {
            var p1 = new Handlarz(1, "Jas", "Kuper", 25, 36, a, Wydajnosc.NISKA, 1);
            var p2 = new PracownikBiurowy(2, "Jas", "Kuper", 25, 36, a, 2, 70);
            var p3 = new PracownikFizyczny(3, "Jas", "Kuper", 25, 36, a, 100);
            var p4 = new PracownikFizyczny(1, "Jas", "Kuper", 25, 36, a, 100);

            rejestr.Dodaj(p4);
            Pracownik[] p = new Pracownik[] { p1, p2, p3 };

            Assert.Throws<ArgumentException>(() => rejestr.Dodaj(p));
        }
        [Test]
        public void SprawdzWartoscPracownikaBiurowego()
        {
            var p = new PracownikBiurowy(1, "Jas", "Kuper", 25, 6, a, 1, 70);
            Assert.That(p.Wartosc(), Is.EqualTo(420));
        }
        [Test]
        public void SprawdzWartoscPracownikaFizycznego()
        {
            var p = new PracownikFizyczny(1, "Jas", "Kuper", 26, 5, a, 100);
            Assert.That(p.Wartosc(), Is.EqualTo(19.23));
        }
        [Test]
        public void SprawdzWartoscHandlarzaWydajnoscNiska()
        {
            var p = new Handlarz(1, "Jas", "Kuper", 25, 4, a, Wydajnosc.NISKA, 1);
            Assert.That(p.Wartosc(), Is.EqualTo(240));
        }
        [Test]
        public void SprawdzWartoscHandlarzaWydajnoscSrednia()
        {
            var p = new Handlarz(1, "Jas", "Kuper", 25, 4, a, Wydajnosc.ŒREDNIA, 1);
            Assert.That(p.Wartosc(), Is.EqualTo(360));
        }
        [Test]
        public void SprawdzWartoscHandlarzaWydajnoscWysoka()
        {
            var p = new Handlarz(1, "Jas", "Kuper", 25, 4, a, Wydajnosc.WYSOKA, 1);
            Assert.That(p.Wartosc(), Is.EqualTo(480));
        } 
    }
}