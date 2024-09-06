//using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Data.SqlClient;

namespace ProjectBlazorTurnos.Server.Context
{
    public class DapperContext

    {

        private readonly IConfiguration _configuration;

        private readonly string _connectionString;

        public DapperContext(IConfiguration configuration)

        {

            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("CONEXIONSQL");
            
        }

        public IDbConnection CreateConnection()
               => new SqlConnection(_connectionString);
        //=> new OracleConnection(_connectionString);

    }

}

