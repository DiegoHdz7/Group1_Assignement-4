using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group1_Assignement_4
{
    struct Transaction
    {
        public string AccountNumber { get; }
        public double Amount { get; }
        public Person Originator { get; }
        public DayTime Time { get; }

        public Transaction(string accountNumber, double amount, Person person, DayTime time)
        {
            AccountNumber = accountNumber;
            Amount = amount;
            Originator = person;
            Time = time;
        }
        public override string ToString()
        {
            return $"{AccountNumber} {Math.Abs(Amount):C} {(Amount < 0 ? "withdrawn" : "deposited")} by {Originator.Name} on {Time} ";
        
        }

       
    }

}
