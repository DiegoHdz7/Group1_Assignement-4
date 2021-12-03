using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group1_Assignement_4
{
    class LoginEventArgs : EventArgs
    {
        public string PersonName { get; }
        public bool Success { get; }

        public LoginEventArgs(string name , bool success)
            : base () //invoking base constructor
        {
            PersonName = name;
            Success = success;
        }
    }
}
