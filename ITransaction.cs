using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group1_Assignement_4
{
     interface ITransaction
    {
        void Withdraw(double amount, Person person);
        void Deposit(double amount, Person person); 
    }
}


