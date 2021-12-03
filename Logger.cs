using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group1_Assignement_4
{
    //test
    public static class Logger
    {
        private static List<string> loginEvents = new List<string>();
        private static List<string> transactionEvents = new List<string>();


        public static void LoginHandler(object sender, EventArgs args) { 
            LoginEventArgs lgnEvtArgs = args as LoginEventArgs;
            string evt = $"{lgnEvtArgs.PersonName} {lgnEvtArgs.Success} {Utils.Now}";
            loginEvents.Add(evt);
        }


         public static void TransactionHandler(object sender, EventArgs args) { 
            TransactionEventArgs trEvent = args as TransactionEventArgs;
            string trEventStr = $"{trEvent.PersonName} {trEvent.Amount} {trEvent.Success} {Utils.Now}";
            transactionEvents.Add(trEventStr);
        }

        public static void ShowLoginEvents() { 
            Console.WriteLine(Utils.Now);
            int i=0;
            foreach (var evt in loginEvents ) {
                Console.WriteLine($"{++i} {evt}");
            }
        }

        public static void ShowTransactionEvents() { 
            Console.WriteLine(Utils.Now);
            int i=0;
            foreach (var evt in transactionEvents ) {
                Console.WriteLine($"{++i} {evt}");
            }
        }
    }
}
