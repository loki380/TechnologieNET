using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FVAT
{
    public struct BankAccount
    {
        public String Number;
        public String AccountName;

        public void generateNumber()
        {
            var rand = new Random();
            for (int i = 1; i <= 26; i++)
                Number += rand.Next(0, 10);
        }

        public BankAccount(string accountName) : this()
        {
            AccountName = accountName;
            generateNumber();
        }
    }
    public struct Adress
    {
        public String City;
        public String Postcode;
        public String Street;
        public int numberhouse;
        public Adress(string city, string postcode, string street, int numberhouse)
        {
            City = city;
            Postcode = postcode;
            Street = street;
            this.numberhouse = numberhouse;
        }
        public override string ToString()
        {
            return "\nMiasto: " + City +
                "\nKod-pocztowy: " + Postcode +
                "\nUlica: " + Street +
                "\nNr: " + numberhouse;
        }
    }
    public class Firm
    {
        public String Firmname { get; set; }
        public String email { get; set; }
        public Adress Adress { get; set; }
        public long Nip { get; set; }

        public Firm(string firmname,String email,  Adress adress, long nip)
        {
            Firmname = firmname;
            this.email = email;
            Adress = adress;
            Nip = nip;
        }
        public override string ToString()
        {
            return "\nNazwa firmy: " + Firmname +
                "\nEmail: " + email +
                "\nAdres: " + Adress.ToString() +
                "\nNIP: " + Nip;
        }
    }
}
