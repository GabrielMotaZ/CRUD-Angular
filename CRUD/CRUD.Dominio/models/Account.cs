using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Dominio.models
{
    public class Account
    {
        public Account(int ID, string login, string password, string email)
        {
            this.ID = ID;
            this.login = login;
            this.password = password;
            this.email = email;
        }

        public Account() { }

        public int? ID { get; set; }
        public string? login { get; set; }
        public string? password { get; set; }
        public string? email { get; set; }

    }
}
