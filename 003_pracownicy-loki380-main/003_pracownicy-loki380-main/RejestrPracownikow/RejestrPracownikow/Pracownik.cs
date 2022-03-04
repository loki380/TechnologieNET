using System;
using System.Collections.Generic;
using System.Text;

namespace RejestrPracownikow
{
    public struct Address
    {
        public String Miasto;
        public String Ulica;
        public int NumerBudynku;
        public int NumerLokalu;

        public Address(string miasto, string ulica, int numerBudynku, int numerLokalu)
        {
            Miasto = miasto;
            Ulica = ulica;
            NumerBudynku = numerBudynku;
            NumerLokalu = numerLokalu;
        }

        public override string ToString()
        {
            return Miasto +
                ", ul." + Ulica +
                " " + NumerBudynku +
                "/" + NumerLokalu;
        }
    }
    public abstract class Pracownik : IComparable
    {
        public int Id { get; set; }
        public String Imie { get; set; }
        public String Nazwisko { get; set; }
        public int Wiek { get; set; }
        public int Doswiadczenie { get; set; }
        public Address Adres { get; set; }

        protected Pracownik(int id, string imie, string nazwisko, int wiek, int doswiadczenie, Address adres)
        {
            Id = id;
            Imie = imie;
            Nazwisko = nazwisko;
            Wiek = wiek;
            Doswiadczenie = doswiadczenie;
            Adres = adres;
        }

        public override string ToString()
        {
            return "\nId: " + Id +
                    "   Imie: " + Imie +
                    "   Nazwisko: " + Nazwisko +
                    "   Wiek: " + Wiek +
                    "   Doświadczenie: " + Doswiadczenie +
                    "   Adres: " + Adres;
        }

        public int CompareTo(object obj)
        {
            Pracownik pr = obj as Pracownik;
            if (this.Doswiadczenie > pr.Doswiadczenie) return -1;
            else if (this.Doswiadczenie < pr.Doswiadczenie) return 1;
            else
            {
                if (this.Wiek > pr.Wiek) return 1;
                else if (this.Wiek < pr.Wiek) return -1;
                else
                {
                    return String.Compare(this.Nazwisko, pr.Nazwisko);
                }
            }
        }
        public abstract Double Wartosc();
    }
}
