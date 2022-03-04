using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FVAT
{
    public class Seller : Firm
    {
        public BankAccount bank { get; set; }
        public Seller(BankAccount bankAccount, string firmname,String email,  Adress address, long nip) : base(firmname, email, address, nip)
        {
            bank = bankAccount;
        }
    }
}
