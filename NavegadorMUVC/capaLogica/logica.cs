using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using capaDatos;

namespace capaLogica
{
    public class logica
    {
        public DataTable consultaLogica(string dato, string campo, string tabla)  //obtener datos de la consulta
        {
            Sentencias sn = new Sentencias();
            MySqlDataAdapter dt = sn.consultaBD(dato, campo, tabla);
            DataTable table = new DataTable();
            dt.Fill(table);
            return table;
        }

        public DataTable InsertBD(string dat1, string dat2, string dat3, string dat4, string dat5, string dat6)  //obtener datos de la consulta
        {
            Sentencias sn = new Sentencias();
            MySqlDataAdapter dt = sn.InsertBD(dat1, dat2, dat3,dat4,dat5,dat6);
            DataTable table = new DataTable();
            dt.Fill(table);
            return table;
        }


        public DataTable Insert2BD(string dat1, string dat2, string dat3, string dat4, string dat5)  //obtener datos de la consulta
        {
            Sentencias sn = new Sentencias();
            MySqlDataAdapter dt = sn.Insert2BD(dat1, dat2, dat3, dat4, dat5);
            DataTable table = new DataTable();
            dt.Fill(table);
            return table;
        }
    }
}
