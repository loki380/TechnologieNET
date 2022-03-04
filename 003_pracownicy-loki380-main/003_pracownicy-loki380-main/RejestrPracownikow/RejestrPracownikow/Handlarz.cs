using System;
using System.Collections.Generic;
using System.Text;

namespace RejestrPracownikow
{
    public enum Wydajnosc
    {
        NISKA,
        ŚREDNIA,
        WYSOKA
    }
    public class Handlarz : Pracownik
    {
        public Wydajnosc Skutecznosc { get; set; }
        public int Prowizja { get; set; }
        public Handlarz(int id, string imie, string nazwisko, int wiek, int doswiadczenie, Address adres, Wydajnosc skutecznosc, int prowizja)
            : base(id, imie, nazwisko, wiek, doswiadczenie, adres)
        {
            Skutecznosc = skutecznosc;
            Prowizja = prowizja;
        }

        public override double Wartosc()
        {
            if (Skutecznosc == Wydajnosc.NISKA) return Math.Round((double)Doswiadczenie * 60, 2);
            else if(Skutecznosc == Wydajnosc.ŚREDNIA) return Math.Round((double)Doswiadczenie * 90, 2);
            else return Math.Round((double)Doswiadczenie * 120, 2);
        }
        public override string ToString()
        {
            return base.ToString() + "  Skuteczność: " + Skutecznosc + "    Prowizja: " + Prowizja +"%";
        }
    }
}
