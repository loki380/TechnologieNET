using System;
using System.Collections.Generic;
using System.Text;

namespace RejestrPracownikow
{
    public class PracownikBiurowy : Pracownik
    {
        public static List<int> listId = new List<int>();
        public int IdBiurowe { get; set; }
        public int Intelekt { get; set; }
        public PracownikBiurowy(int id, string imie, string nazwisko, int wiek, int doswiadczenie, Address adres, int idBiurowe, int intelekt) 
            : base(id, imie, nazwisko, wiek, doswiadczenie, adres)
        {
            if (intelekt < 70 || intelekt > 150) throw new ArgumentOutOfRangeException();
            if(!sprawdzIdBiurowe(idBiurowe)) throw new ArgumentException();
            IdBiurowe = idBiurowe;
            Intelekt = intelekt;
            listId.Add(idBiurowe);
        }

        private bool sprawdzIdBiurowe(int id)
        {
            foreach (int x in listId)
            {
                if (x == id) return false;
            }
            return true;
        }

        public override double Wartosc()
        {
            return Doswiadczenie * Intelekt;
        }

        public override string ToString()
        {
            return base.ToString() + "  IdBiurowe: " + IdBiurowe + "    Intelekt:" + Intelekt;
        }
    }
}
