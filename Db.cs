using System;
using System.Data.SqlClient;

namespace el_amparo
{
    internal static class Db
    {
        public static SqlConnection Open(string database)
        {
            SqlConnection connection = new SqlConnection(
                "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=" + database + ";Integrated Security=SSPI;");
            connection.Open();
            return connection;
        }
    }
}
