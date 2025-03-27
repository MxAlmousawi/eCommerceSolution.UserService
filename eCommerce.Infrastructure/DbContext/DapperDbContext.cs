using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace eCommerce.Infrastructure.DbContext
{
    public class DapperDbContext
    {
        private readonly IConfiguration configuration;
        private readonly IDbConnection connection;

        public DapperDbContext(IConfiguration configuration)
        {
            this.configuration = configuration;
            string connectionString = configuration.GetConnectionString("PostgresConnection");
            this.connection = new NpgsqlConnection(connectionString);
        }

        public IDbConnection DbConnection => connection;
    }
}
