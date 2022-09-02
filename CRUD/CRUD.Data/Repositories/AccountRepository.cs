using CRUD.Data.Contexts;
using CRUD.Dominio.Contract.Repositories;
using CRUD.Dominio.models;
using Dapper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Data.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly CRUDContext _crudContext;

        public AccountRepository(CRUDContext crudContext)
        {
            _crudContext = crudContext;
        }
        public Account Register(Account account)
        {
            var sql = "INSERT INTO Account(ID,login,password,email) output inserted.* VALUES(ISNULL((SELECT MAX(ID) FROM Account),0)+1,@login,@password,@email)";

            var connection = _crudContext.GetConnection();

            Account registeredAccount = connection.QuerySingle<Account>(sql, account);

            if (registeredAccount != null)
            {
                return registeredAccount;
            }
            else
            {
                throw new Exception("Registration error");
            }

        }

        public Account Login(Account account)
        {
            var sql = @"SELECT [ID]
                             ,[login]
                             ,[email]
                         FROM [dbo].[Account]
                         WHERE login = @login AND password = @password";

            var connection = _crudContext.GetConnection();

            Account? loggedAccount = new Account();

            loggedAccount = connection.QuerySingleOrDefault<Account>(sql, account);

            return loggedAccount != null ? loggedAccount : new Account();
        }

        public IEnumerable<Account> GetLogins(Account account)
        {
            var sql = @"SELECT [ID]
                             ,[login]
                             ,[email]
                         FROM [dbo].[Account]
                         WHERE 1 = 1 ";

            if (account.email != null)
            {
                sql += "email = @email ";
            }

            if (account.login != null)
            {
                sql += "login = @login ";
            }

            var connection = _crudContext.GetConnection();

            IEnumerable<Account> logins = connection.Query<Account>(sql, account);

            return logins;
        }
    }
}
