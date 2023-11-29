using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Practica
{
    public class Conexion
    {
        SqlConnection conexion = new SqlConnection();

        public Conexion(string server, string user, string pass, string BDname)
        {
            conexion.ConnectionString = $"Data Source={server}; User={user}; Password={pass}; Initial Catalog={BDname}";
        }

        

        public void CrearTabla()
        {
            SqlCommand cmd = new SqlCommand();
            conexion.Open();
            cmd.CommandText = "create table Cobros (tipo varchar(1),monto int)";
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 1000;
            cmd.Connection = conexion;      
            cmd.ExecuteNonQuery();   
            conexion.Close();
        }

        public void InsertarCobros(string tipo, int monto)
        {
            SqlCommand cmd = new SqlCommand();
            conexion.Open();
            cmd.Parameters.Add(new SqlParameter("tipo", SqlDbType.VarChar));
            cmd.Parameters.Add(new SqlParameter("monto", SqlDbType.Int));
            cmd.Parameters["tipo"].Value = tipo;
            cmd.Parameters["monto"].Value = monto;
            cmd.CommandText = "insert into Cobros values (@tipo, @monto)";
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 1000;
            cmd.Connection = conexion;
            cmd.ExecuteNonQuery();
            conexion.Close();
        }

    }
}
