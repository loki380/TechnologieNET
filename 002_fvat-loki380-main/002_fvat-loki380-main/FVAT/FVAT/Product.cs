using System;
using System.Collections.Generic;
using System.Text;

namespace FVAT
{
    public class Product
    {
        public String Name { get; set; }
        public double netto { get; set; }
        public int Vat { get; set; }

        public Product(string name, double netto, int vat)
        {
            Name = name;
            this.netto = netto;
            Vat = vat;
        }
        public Product()
        {
        }
    }
}
