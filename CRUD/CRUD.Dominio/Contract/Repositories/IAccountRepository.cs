using CRUD.Dominio.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Dominio.Contract.Repositories
{
    public interface IAccountRepository
    {
        public Account Login(Account account);
        public Account Register(Account account);
        public IEnumerable<Account> GetLogins(Account account);
    }
}
