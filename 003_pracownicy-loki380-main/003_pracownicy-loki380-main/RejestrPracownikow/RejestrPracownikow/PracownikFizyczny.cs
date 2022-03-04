using System;
using System.Collections.Generic;
using System.Text;

namespace RejestrPracownikow
{
    public class PracownikFizyczny : Pracownik
    {
        public int Sila { get; set; }
        public PracownikFizyczny(int id, string imie, string nazwisko, int wiek, int doswiadczenie, Address adres, int sila)
            : base(id, imie, nazwisko, wiek, doswiadczenie, adres)
        {
            if(sila<1 || sila > 100) throw new ArgumentOutOfRangeException();
            Sila = sila;
        }

        public override double Wartosc()
        {
            return Math.Round((double) Doswiadczenie * Sila / Wiek, 2);
        }

        public override string ToString()
        {
            return base.ToString() + "  Siła: "+ Sila;
        }
    }
}
