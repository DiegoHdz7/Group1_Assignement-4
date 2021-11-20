using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group1_Assignement_4
{
     class AccountException : Exception
    {
        public AccountException(ExceptionEnum reason)
            : base(reason.ToString()) { } // adding arugement to the parent constructor Exception
    }
}
