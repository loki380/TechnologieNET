using System;
using System.Collections.Generic;
using System.Text;

namespace RejestrPracownikow
{
    public class Rejestr
    {
        public List<Pracownik> Pracownicy { get; set; }
        public Rejestr()
        {
            Pracownicy = new List<Pracownik>();
        }
        public void Dodaj(Pracownik pracownik)
        {
            foreach (Pracownik x in Pracownicy)
            {
                if (x.Id == pracownik.Id) throw new ArgumentException();
            }
            Pracownicy.Add(pracownik);
        }
        public void Dodaj(Pracownik[] pracownicy)
        {
            foreach (Pracownik x in Pracownicy)
            {
                foreach(Pracownik y in pracownicy)
                {
                    if (x.Id == y.Id) throw new ArgumentException();
                }
            }
            Pracownicy.AddRange(pracownicy);
        }
        public void Usun(int id)
        {
            foreach(Pracownik x in Pracownicy){
                if (x.Id == id) Pracownicy.Remove(x);
            }
        }
        public void Wyswietl()
        {
            Pracownicy.Sort();
            Pracownicy.ForEach(Console.WriteLine);
        }
        public void Wyswietl(String miasto)
        {
            foreach(Pracownik pracownik in Pracownicy)
            {
                if (pracownik.Adres.Miasto.Equals(miasto)) Console.WriteLine(pracownik);
            }
        }
        public void WyswietlWartosci()
        {
            foreach (Pracownik pracownik in Pracownicy)
            {
                Console.WriteLine(pracownik + "     Wartość: "+pracownik.Wartosc());
            }
        }
    }
}
