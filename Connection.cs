using Microsoft.Data.SqlClient;
using System.Data;
using System.Numerics;
using System.Text.Json.Nodes;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Sql.Connection
{
    class Connection
    {
        public string ejecutar(string sql)
        {
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

                string respuesta = "[";

                builder.DataSource = "storage.cv8go4kwvjyu.us-east-1.rds.amazonaws.com, 1433";
                builder.UserID = "admin";
                builder.Password = "administrador";
                builder.InitialCatalog = "storage";
                builder.TrustServerCertificate = true;

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    connection.Open();
                    //String sql = "SELECT name, collation_name FROM sys.databases";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                if(respuesta != "[") { respuesta += ", "; }
                                respuesta += "{ \"id_product\": \"" + reader.GetInt32(0) + "\", \"name_product\": \"" + reader.GetString(1)+ "\", \"status_product\": \"" + reader.GetString(2) + "\", \"defective_product\": \"" + reader.GetString(3) + "\" }";
                            }
                        }
                    }
                }

                return respuesta+"]";
            }
            catch (SqlException e)
            {
                return e.ToString();
            }
        }
    }
}