using CRUD.Dominio.Contract.Repositories;
using CRUD.Dominio.models;
using CRUD.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Service.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepositorio;

        public AccountService(IAccountRepository accountRepositorio)
        {
            _accountRepositorio = accountRepositorio;
        }

        public Account Register(Account account) => _accountRepositorio.Register(account);

        public Account Login(Account account) => _accountRepositorio.Login(account);

        public IEnumerable<Account> GetLogins(Account account) => _accountRepositorio.GetLogins(account);
    }
}
