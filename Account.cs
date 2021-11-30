using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group1_Assignement_4
{
    abstract class Account
    {
        protected readonly List<Person> users;
        public readonly List<Transaction> transactions;
        private static int LAST_NUMBER = 100_000;

        public double Balance { get; protected set; }
        public double LowestBalance { get; protected set; }
        public string Number { get; }

        public Account(string type, double balance)
        {
            Number = type + LAST_NUMBER;
            LAST_NUMBER++;
            Balance = balance;
            LowestBalance = balance;
            transactions = new List<Transaction>();
            users = new List<Person>();
        }

        public void Deposit(double amount, Person person)
        {
            Balance += amount;
            LowestBalance = Balance;
            Transaction transaction = new Transaction(Number, amount, person,Utils.);
            //transactions.Add(transaction);
        }

        public void AddUser(Person person)
        {
            users.Add(person);
        }

        public bool IsUser(string name)
        {
            bool boolean = false;
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].Name == name)
                {
                    boolean = true;
                }
                else
                {
                    boolean = false;
                }
            }
            return boolean;
        }

        public abstract void PrepareMonthlyReport();

        public virtual void OnTransactionOccur(object sender, EventArgs args)
        {

        }

        public override string ToString()
        {
            List<string> holder = new List<string>();
            foreach (var item in users)
            {
                holder.Add($"{Number}, {item.Name}, {Balance}, {transactions}");
            }
            foreach (var item in holder)
            {
                return item;
            }
            return "";
        }
    }
}
