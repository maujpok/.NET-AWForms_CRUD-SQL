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
            conn = new SqlConnection("Server=tcp:curso-net.database.windows.net,1433;Initial Catalog=Practice_20220107;Persist Security Info=False;User ID=maujpok;Password=Pizza2021;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
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