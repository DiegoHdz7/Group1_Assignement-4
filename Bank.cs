using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group1_Assignement_4
{
    // TODO: Review this class
    //Diego Saul Hernandez Gonzalez
    static class Bank
    {
        public static Dictionary<string, Account> ACCOUNTS = new Dictionary<string, Account>();
        public static Dictionary<string, Person> USERS = new Dictionary<string, Person>();
        public static List<Transaction> transactions;
          static Bank()
        {
            AddPerson("Narendra", "1234-5678");    //0
            AddPerson("Ilia", "2345-6789");        //1
            AddPerson("Mehrdad", "3456-7890");     //2
AddPerson("Vinay", "4567-8901");       //3
AddPerson("Arben", "5678-9012");       //4
AddPerson("Patrick", "6789-0123");     //5
AddPerson("Yin", "7890-1234");         //6
AddPerson("Hao", "8901-2345");         //7
AddPerson("Jake", "9012-3456");        //8
AddPerson("Mayy", "1224-5678");        //9
AddPerson("Nicoletta", "2344-6789");   //10


            //initialize the ACCOUNTS collection
            AddAccount(new VisaAccount());              //VS-100000
            AddAccount(new VisaAccount(150, -500));     //VS-100001
            AddAccount(new SavingAccount(5000));        //SV-100002
            AddAccount(new SavingAccount());            //SV-100003
            AddAccount(new CheckingAccount(2000));      //CK-100004
            AddAccount(new CheckingAccount(1500, true));//CK-100005
            AddAccount(new VisaAccount(50, -550));      //VS-100006
            AddAccount(new SavingAccount(1000));        //SV-100007 

            //associate users with accounts
            string number = "VS-100000";
            AddUserToAccount(number, "Narendra");
            AddUserToAccount(number, "Ilia");
            AddUserToAccount(number, "Mehrdad");

            number = "VS-100001";
            AddUserToAccount(number, "Vinay");
            AddUserToAccount(number, "Arben");
            AddUserToAccount(number, "Patrick");

            number = "SV-100002";
            AddUserToAccount(number, "Yin");
            AddUserToAccount(number, "Hao");
            AddUserToAccount(number, "Jake");

            number = "SV-100003";
            AddUserToAccount(number, "Mayy");
            AddUserToAccount(number, "Nicoletta");

            number = "CK-100004";
            AddUserToAccount(number, "Mehrdad");
            AddUserToAccount(number, "Arben");
            AddUserToAccount(number, "Yin");

            number = "CK-100005";
            AddUserToAccount(number, "Jake");
            AddUserToAccount(number, "Nicoletta");

            number = "VS-100006";
            AddUserToAccount(number, "Ilia");
            AddUserToAccount(number, "Vinay");

            number = "SV-100007";
            AddUserToAccount(number, "Patrick");
            AddUserToAccount(number, "Hao");




        }

        public static void PrintAccounts() {
            foreach (KeyValuePair<string, Account> account in ACCOUNTS)
            {
                Console.WriteLine(account.Value);

            }

        }

        public static void PrintPersons()
        {
            foreach (KeyValuePair<string, Person> person in USERS)
            {
                Console.WriteLine(person.Value);

            }
        }

        public static Person GetPerson(string name) {

            Person rtnPerson=null;
            foreach (KeyValuePair<string, Person> person in USERS) {
                if (person.Key.Equals(name))
                {
                    rtnPerson = person.Value;
                    break;
                }
               
            }

            if(rtnPerson == null)  new Exception(new AccountException(ExceptionEnum.USER_DOES_NOT_EXIST).ToString());

            return rtnPerson;
        }

        public static Account GetAccount(string number) {

            Account rtnAccount=null;

            foreach (KeyValuePair<string, Account> account in ACCOUNTS)
            {
                if (account.Key.Equals(number))
                {
                    rtnAccount = account.Value;
                    return rtnAccount;
                }
              
            }

            if (rtnAccount == null) new Exception(new AccountException(ExceptionEnum.ACCOUNT_DOES_NOT_EXIST).ToString());// Console.WriteLine("Exeption thow");


            return rtnAccount;
        }

        public static void AddPerson(string name, string sin) {

            Person person = new Person(name, sin);
            Console.WriteLine(person.Name);
            LoginEventArgs args = new LoginEventArgs(person.Name,true);
            Logger.LoginHandler(person, args);
            USERS.Add(name, person);
        }

        public static void AddAccount(Account account) {

            TransactionEventArgs args = new TransactionEventArgs(account.Number,account.Balance,true);
            Logger.TransactionHandler(account, args);

            ACCOUNTS.Add(account.Number, account);
        }

        public static void AddUserToAccount(string number, string name) {

            Account acc = null;
            Person person = null;
             foreach (KeyValuePair<string, Account> account in ACCOUNTS)
            {
               if(account.Key.Equals(number)) acc = account.Value;
            }

             foreach (KeyValuePair<string, Person> prs in USERS)
            {
               if(prs.Key.Equals(name)) person = prs.Value;
            }


             acc.AddUser(person);
        }

        public static List<Transaction> GetAllTransactions() {

            //account number, amount, person, time
            transactions = new List<Transaction>();

            foreach (KeyValuePair<string, Account> account in ACCOUNTS)
            {
                foreach (Transaction transaction in account.Value.transactions) {

                    transactions.Add(transaction);
                }

            }

            return transactions;
        }
    }

    
}
