using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Practice_20220107.Data
{
    class Conexion
    {
        SqlConnection conn;
        public Conexion()
        {
            conn = new SqlConnection([INSERTAR CONNECTION STRING AQUI]);
        }

        public SqlConnection Conectar()
        {
            try
            {
                conn.Open();
                return conn;
            }catch (Exception ex)
            {
                return null;
            }
        }

        public bool Desconectar()
        {
            try
            {
                conn.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
