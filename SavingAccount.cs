using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group1_Assignement_4
{
    class SavingAccount: Account, ITransaction
    {
       
        private static double COST_PER_TRANSACTION = 0.5;
        private static double INTEREST_RATE = 0.015;
        
        public SavingAccount (double balance = 0)
            :base("SV-", balance)
        {

        }

        public new void Deposit(double amount, Person person)
        {
            base.Deposit(amount, person);
            base.OnTransactionOccur(null, null); //todo
        }

        public void Withdraw (double amount, Person person)
        {

            Boolean flag=false;
            foreach (var item in base.users)
            {
                if (person.Name.Equals(item.Name) == false)
                {
                    flag = true;
                }

            }

            if (flag == false) {
                base.OnTransactionOccur(null, null);
                throw new AccountException(ExceptionEnum.NAME_NOT_ASSOCIATED_WITH_ACCOUNT);
            }

            else if (person.IsAuthenticated!=true)
            {
                Console.WriteLine(person);
                base.OnTransactionOccur(null, null);
                throw new AccountException(ExceptionEnum.USER_NOT_LOGGED_IN);
            }
            else if (amount > base.Balance) //overdraft missing
            {
                base.OnTransactionOccur(null, null);
                 new AccountException(ExceptionEnum.NO_OVERDRAFT);
            }
            else
            {
                base.OnTransactionOccur(null, null);
                base.Deposit(-amount, person);
            }

        }

        public override void PrepareMonthlyReport()
        {
            int count = base.transactions.Count;
            double serviceCharge = count * COST_PER_TRANSACTION;
            double interest = LowestBalance * INTEREST_RATE / 12;
            Balance += interest;
            Balance -= serviceCharge;
            transactions.Clear();
        }



    }
}
