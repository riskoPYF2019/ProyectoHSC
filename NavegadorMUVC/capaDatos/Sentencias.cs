using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;


namespace capaDatos
{
    public class Sentencias
    {
        public MySqlDataAdapter consultaBD(string dato, string campo, string tabla)
        {
            conexion cn = new conexion();
            cn.probarConexion();
            string sql = "SELECT * FROM tblclientes WHERE " + campo + "='" + dato + "';";
            MySqlDataAdapter dataTable = new MySqlDataAdapter(sql, cn.probarConexion());
            return dataTable;
        }


        public MySqlDataAdapter InsertBD(string dat1, string dat2, string dat3, string dat4, string dat5, string dat6)
        {
            conexion cn1 = new conexion();
            cn1.probarConexion();
            string sql1 = "INSERT INTO tblclientes (codigo, nombres, apellidos, edad, telefono, correo) VALUES (" + dat1 + "," + dat2 + "," + dat3 + "," + dat5 + "," + dat5 + "," + dat6 +")"; 
            MySqlDataAdapter dataTable = new MySqlDataAdapter(sql1, cn1.probarConexion());
            return dataTable;
        }

        public MySqlDataAdapter Insert2BD(string dat1, string dat2, string dat3, string dat4, string dat5)
        {
            conexion cn1 = new conexion();
            cn1.probarConexion();
            string sql1 = "INSERT INTO tblproducto (codigo, nombreProducto, peso, marca, descripcion) VALUES(" + dat1 + "," + dat2 + "," + dat3 + "," + dat5 + "," + dat5 +  ")";
            MySqlDataAdapter dataTable = new MySqlDataAdapter(sql1, cn1.probarConexion());
            return dataTable;
        }
    }
}
