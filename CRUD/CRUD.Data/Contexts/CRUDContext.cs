using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Data.Contexts
{
    public class CRUDContext : IDisposable
    {
        private readonly IDbConnection _dbConnection;
        private bool _disposedValue;
        public CRUDContext(IConfiguration configuration)
        {
            _dbConnection = new SqlConnection(configuration.GetConnectionString("CRUDConnectionString"));
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IDbConnection GetConnection()
        {
            if (_dbConnection.State.Equals(ConnectionState.Closed)) _dbConnection.Open();

            return _dbConnection ??
                   throw new NullReferenceException("Couldn't make a connection");
        }

        private void Dispose(bool disposing)
        {
            if (!_disposedValue)
                if (disposing)
                    _dbConnection.Dispose();

            _disposedValue = true;
        }
    }
}
