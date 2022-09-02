using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Dominio.models
{
    [Serializable]
    public class AccountError : Exception
    {
        
        public AccountError() : base() { }

        public AccountError(string message) : base(message) { }

        public AccountError(string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
