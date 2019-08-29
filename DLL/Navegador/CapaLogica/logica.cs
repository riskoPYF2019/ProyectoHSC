using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDeDatos;
using System.Data;
using System.Data.Odbc;

namespace CapaLogica
{
  
    public class logica
    {
        sentencias sn = new sentencias();
        public DataTable consultaLogica(string tabla)  //obtener datos de la consulta
        {
            OdbcDataAdapter dt = sn.llenaTbl(tabla);
            DataTable table = new DataTable();
            dt.Fill(table);
            return table;
        }

        public string[] campos(string tabla)
        {
            string[] Campos = sn.obtenerCampos(tabla);

            return Campos;
        }

        public string[] tipos(string tabla)
        {
            string[] Tipos = sn.obtenerTipo(tabla);

            return Tipos;
        }

        public void nuevoQuery(String query)//trasporta el query de la capa de disenio a Datos
        {
            sn.ejecutarQuery(query);
        }


    }

}
