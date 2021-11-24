using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group1_Assignement_4
{
    class SavingAccount : Account, ITransaction
    {
        public void Deposit(double amount, Person person)
        {
            throw new NotImplementedException();
        }

        public void Withdraw(double amount, Person person)
        {
            throw new NotImplementedException();
        }
    }
}
