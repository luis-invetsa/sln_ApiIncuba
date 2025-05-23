using ApiIncuba.Models;
using System;
using System.Data;
using System.Data.SqlClient;

namespace ApiIncuba.Dao
{
    public class DA_Usuario
    {
        string cadConexion = "Server=192.168.1.160; Database=BD_LINCE_PERU_QA_20250514; User Id=adminwebsql;Password=4dm1nweb.sql;";

        
        public BE_Usuario ValidarSessionUsuario(string login)//, string clave
        {
            BE_Usuario item = new BE_Usuario();

            try
            {
                SqlConnection conn = new SqlConnection(cadConexion);
                SqlCommand cmd = conn.CreateCommand();
                conn.Open();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "SELECT * FROM T_USUARIO WHERE Login = '" + login + "'";// AND Clave = '" + clave + "'";
                cmd.CommandTimeout = 0;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        item.IdUsuario = Convert.ToInt32(reader["IdUsuario"]);
                        item.Login = reader["Login"].ToString();
                        item.Clave = reader["Clave"].ToString();
                        item.Nombres = reader["Nombres"].ToString();
                        item.Apellidos = reader["Apellidos"].ToString();
                    }
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }

            return item;
        }
    }
}
