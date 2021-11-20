using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group1_Assignement_4
{
    public class Person
    {
        private string password;



        public event EventHandler OnLogin;



        public string Sin { get; }



        public string Name { get; }



        public bool IsAuthenticated { get; private set; }
        public Person(string name, string sin)
        {
            Name = name;
            Sin = sin;
            password = sin.Substring(0, 3);
        }
        public void Login(string password)
        {
            if (this.password != password)
            {
                IsAuthenticated = false;
                throw new AccountException(ExceptionEnum.PASSWORD_INCORRECT);
            }
            else
            {
                IsAuthenticated = true;
            }
        }
        public void Logout()
        => IsAuthenticated = false;



        public override string ToString()
        => $"{Name} {Sin} {IsAuthenticated} {password}";




        public static void RunTest()
        {
            Person person = new Person("Sahasan", "123456789");
            Console.WriteLine(person);
            person.Login("123");
            Console.WriteLine(person);
            person.Logout();
            Console.WriteLine(person);



            person.Login("123");
            Console.WriteLine(person);



            try // try catch block, to ensure program doesnt crash instead it prints the message
            {
                person.Login("231");
                Console.WriteLine(person);
            }catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
