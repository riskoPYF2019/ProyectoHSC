using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos
{
    class conexion
    {
        public OdbcConnection probarConexion()
        {
            OdbcConnection conn = new OdbcConnection("Dsn=cine");// creacion de la conexion via ODBC

            try
            {
              
                conn.Open();
            }
            catch (OdbcException ex)
            {
                Console.WriteLine("no conecto");
            }
            return conn;
        }
       
    }
}
