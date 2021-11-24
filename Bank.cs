using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group1_Assignement_4
{
    // TODO: Review this class
    static class Bank
    {
        public static Dictionary<string, Account> ACCOUNTS { get; }
        public static Dictionary<string, Person> USERS { get; }

          static Bank()
        {
         


        }

        public static void PrintAccounts() {
            foreach ( KeyValuePair<string, Account> account in ACCOUNTS) {
                Console.WriteLine(account);

            }
        }

        public static void PrintPersons()
        {
            foreach (KeyValuePair<string, Person> person in USERS)
            {
                Console.WriteLine(person);

            }
        }

        public static Person GetPerson(string name) {

            Person rtnPerson=null;
            foreach (KeyValuePair<string, Person> person in USERS) {
                if (person.Key.Equals(name))
                {
                    rtnPerson = person.Value;
                }
                else {

                    throw new Exception(new AccountException(ExceptionEnum.USER_DOES_NOT_EXIST).ToString());
                }
            }

            return rtnPerson;
        }

        public static Account GetAccount(string number) {

            Account rtnAccount=null;

            foreach (KeyValuePair<string, Account> account in ACCOUNTS)
            {
                if (account.Key.Equals(number))
                {
                    rtnAccount = account.Value;
                }
                else
                {

                    throw new Exception(new AccountException(ExceptionEnum.ACCOUNT_DOES_NOT_EXIST).ToString());
                }
            }


            return rtnAccount;
        }

        public static void AddPerson(string name, string sin) {

            Person person = new Person(name, sin);

            //EventHandler.CreateDelegate(Logger.LoginHandler);
        }


    }

    
}
