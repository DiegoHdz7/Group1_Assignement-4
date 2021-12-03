using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group1_Assignement_4
{
    class VisaAccount : Account, ITransaction
    {
       private double CreditLimit;
        private static double INTEREST_RATE = 0.1995;

        public VisaAccount(double balance = 0, double creditLimit = 1200)
            : base("VS-", balance)
        {
            CreditLimit = creditLimit;
        }

        public void DoPayment(double amount, Person person)
        {
            base.Deposit(amount, person);
            base.OnTransactionOccur(null, null); 
        }

        public void DoPurchase(double amount, Person person)
        {
            foreach (var item in base.users)
            {
                if (person.Name != item.Name)
                {
                    base.OnTransactionOccur(null, null); 
                    throw new AccountException(ExceptionEnum.NAME_NOT_ASSOCIATED_WITH_ACCOUNT);
                }
                else if (person.IsAuthenticated)
                {
                    base.OnTransactionOccur(null, null); 
                    throw new AccountException(ExceptionEnum.USER_NOT_LOGGED_IN);
                }
                else if (amount > CreditLimit)
                {
                    base.OnTransactionOccur(null, null); 
                    throw new AccountException(ExceptionEnum.CREDIT_LIMIT_HAS_BEEN_EXCEEDED);
                }
                else
                {
                    base.OnTransactionOccur(null, null); 
                    base.Deposit(-amount, person);
                }
            }
        }

        public override void PrepareMonthlyReport()
        {
            double interest = base.LowestBalance * INTEREST_RATE / 12;
            Balance -= interest;
            transactions.Clear();

        }
    }
}
