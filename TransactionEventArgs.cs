using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group1_Assignement_4
{
    class TransactionEventArgs: LoginEventArgs
    {
        public double Amount { get; }

        public TransactionEventArgs(string name, double amount, bool success)
            :base (name, success)
        {
            Amount = amount;
        }


    }
}
