using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group1_Assignement_4
{
    class CheckingAccount : Account, ITransaction
    {
        private static double COST_PER_TRANSACTION = 0.05;
        private static double INTEREST_RATE = 0.005;
        private bool HasOverdraft;

        public CheckingAccount (double balance = 0, bool hasOverdraft = false)
            :base("CK-",balance)
        {
            HasOverdraft = hasOverdraft;
        }

        public new void Deposit(double amount, Person person)
        {
            base.Deposit(amount, person);
            base.OnTransactionOccur(null, null); 
        }

        public void Withdraw(double amount, Person person)
        {
            foreach (var item in base.users)
            {
                if(person.Name != item.Name)
                {
                    base.OnTransactionOccur(null, null); 
                    throw new AccountException(ExceptionEnum.NAME_NOT_ASSOCIATED_WITH_ACCOUNT);
                }
                else if (person.IsAuthenticated)
                {
                    base.OnTransactionOccur(null, null); 
                    throw new AccountException(ExceptionEnum.USER_NOT_LOGGED_IN);
                }
                else if(amount > base.Balance && HasOverdraft == false)
                {
                    base.OnTransactionOccur(null, null); 
                    throw new AccountException(ExceptionEnum.NO_OVERDRAFT);
                }
                else
                {
                    base.Deposit(-amount, person);
                }
            }
        }

        public override void PrepareMonthlyReport()
        {
            int transCount = base.transactions.Count;
            double serviceCharge = transCount * COST_PER_TRANSACTION;
            double interest = LowestBalance * INTEREST_RATE / 12;
            Balance += interest;
            Balance -= serviceCharge;
            transactions.Clear();
            throw new NotImplementedException();
        }
    }
}
