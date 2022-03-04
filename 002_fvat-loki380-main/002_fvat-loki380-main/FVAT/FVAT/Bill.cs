using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace FVAT
{
    public class Bill
    {
        public struct Position
        {
            public String name;
            public int count;
            public double netto;
            public double fullnetto;
            public int vat;
            public double fullbrutto;

            public Position(string name, int count, double netto, int vat)
            {
                this.name = name;
                this.count = count;
                this.netto = netto;
                this.fullnetto = netto*count;
                this.vat = vat;
                this.fullbrutto = netto*count*(1 + ((double)vat / 100));
            }
        }
        private static int number=0;
        public Basket Trolley { get; set; }
        public DateTime documentdate { get; set; }
        public DateTime paymentdate { get; set; }
        public List<Position> Positions { get; set; }
        public double BruttoPrice { get; set; }
        public Bill(Basket trolley)
        {
            number++;
            documentdate = DateTime.Now;
            paymentdate = DateTime.Now.AddDays(7);
            Trolley = trolley;
            Positions = new List<Position>();
            UpdatePositions();
            BruttoPrice = GetFinalBrutto();
        }

        private void UpdatePositions()
        {
            foreach (var element in Trolley.Content)
            {
                Position tmp = new Position(element.Key.Name, element.Value, element.Key.netto, element.Key.Vat);
                Positions.Add(tmp);
            }
        }

        private double GetFinalBrutto()
        {
            double tmp = 0;
            foreach (var element in Positions) { tmp += element.fullbrutto; }
            return tmp;
        }

        public override string ToString()
        {
            String tmp = "";
            foreach (var element in Positions)
            {
                tmp += element.name+", "+element.count+", "+element.netto+", "+element.vat+", "+element.fullnetto+", "+element.fullbrutto+"\n";
            }

            return "Faktura nr: " + number +
                    "\nDane klienta: " + Trolley.Bussines.ToString()+
                    "\nPozycje: \n" + tmp +
                    "\nCałkowita wartość brutto: " + this.BruttoPrice +
                    "\nData wystawienia dokumentu: " + documentdate +
                    "\nData sprzedaży: " + Trolley.saledate +
                    "\nData zaplaty: " + paymentdate;
        }
    }
}
