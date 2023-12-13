using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace AvansProjeServer.DAL.Context
{
    public class MyConnectionContext
    {
        private readonly IConfiguration _conf;
        string _connectionString = null;

        public MyConnectionContext(IConfiguration conf)
        {
            _conf = conf;
            _connectionString = conf.GetConnectionString("conn");
        }
        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}
