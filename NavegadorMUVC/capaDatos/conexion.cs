using MySql.Data.MySqlClient;
using System;

namespace capaDatos
{
    public class conexion
    {
        public MySqlConnection probarConexion()
        {
            MySqlConnection conn = new MySqlConnection();
            string myConnectionString;

            myConnectionString = "Server=localhost;Database=bdcapacitacion; Uid=root;Pwd='';";

            try
            {
                conn.ConnectionString = myConnectionString;
                conn.Open();
                
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.WriteLine("no conecto");
            }
            return conn;
        }
    }
}
