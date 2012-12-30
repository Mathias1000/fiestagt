using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Net;

namespace FiestaGT.DataAccess
{
    public class BaseDataAccess
    {
        public string CadenaConexion()
        {
            SqlConnectionStringBuilder connectionString = new SqlConnectionStringBuilder();

            connectionString.DataSource = @"(local)\SQLSERVER2008";
            
            connectionString.InitialCatalog = "FIESTAGT";
            connectionString.IntegratedSecurity = true;

            return connectionString.ConnectionString;
        }

    }
}
