using Practice_20220107.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Practice_20220107.Data
{
    class EmpleadoDB
    {
        public static bool GuardarEmpleado(EmpleadoClass e)
        {
            try
            {
                Conexion conn = new Conexion();
                string sql = "INSERT INTO tb_empleados VALUES('" +e.Documento1+ "', '" + e.Nombre1 + "', '" + e.Apellido1 + "', "+ e.Edad1 +", '" + e.Domicilio1 + "', '" + e.Fecha_Nacimiento1 + "')";
                SqlCommand cmd = new SqlCommand(sql, conn.Conectar());
                int qty = cmd.ExecuteNonQuery();
                conn.Desconectar();
                if (qty == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }catch(Exception ex)
            {
                var error = ex;
                return false;
            }
        }

        public static DataTable MostrarEmpleados()
        {
            try
            {
                Conexion conn = new Conexion();
                string sql = "SELECT * FROM tb_empleados";
                SqlCommand cmd = new SqlCommand(sql, conn.Conectar());
                SqlDataReader read = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                DataTable dt = new DataTable();
                dt.Load(read);
                conn.Desconectar();
                return dt;
            }
            catch (Exception ex)
            {
                var error = ex;
                return null;
            }
        }

        public static EmpleadoClass ConsultarEmpleado(string documento)
        {
            try
            {
                Conexion conn = new Conexion();
                string sql = "SELECT * FROM tb_empleados WHERE Documento='"+documento+"'";
                SqlCommand cmd = new SqlCommand(sql, conn.Conectar());
                SqlDataReader read = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                
                EmpleadoClass em = new EmpleadoClass();
                if (read.Read())
                {
                    em.Documento1 = read["Documento"].ToString();
                    em.Nombre1 = read["Nombre"].ToString();
                    em.Apellido1= read["Apellido"].ToString();
                    em.Edad1 = Convert.ToInt32(read["Edad"].ToString());
                    em.Domicilio1 = read["Domicilio"].ToString();
                    em.Fecha_Nacimiento1 = read["Fecha_Nacimiento"].ToString();
                    conn.Desconectar();
                    return em;
                }
                else
                {
                    conn.Desconectar();
                    return null;
                }
            }
            catch (Exception ex)
            {
                var error = ex;
                return null;
            }
        }

        public static bool ActualizarEmpleado(EmpleadoClass e)
        {
            try
            {
                Conexion conn = new Conexion();
                string sql = "UPDATE tb_empleados SET Documento='" + e.Documento1 + "', Nombre='" + e.Nombre1 + "', Apellido='" + e.Apellido1 + "', Edad=" + e.Edad1 + ", Domicilio='" + e.Domicilio1 + "', Fecha_Nacimiento='" + e.Fecha_Nacimiento1 + "' WHERE Documento='" + e.Documento1 + "'";
                SqlCommand cmd = new SqlCommand(sql, conn.Conectar());
                int qty = cmd.ExecuteNonQuery();
                
                if (qty == 1)
                {
                    conn.Desconectar();
                    return true;
                }
                else
                {
                    conn.Desconectar();
                    return false;
                }
            }
            catch (Exception ex)
            {
                var error = ex;
                return false;
            }
        }

        public static bool EliminarEmpleado(string documento)
        {
            try
            {
                Conexion conn = new Conexion();
                string sql = "DELETE FROM tb_empleados WHERE Documento='" + documento + "'";
                SqlCommand cmd = new SqlCommand(sql, conn.Conectar());
                int qty = cmd.ExecuteNonQuery();

                if (qty == 1)
                {
                    conn.Desconectar();
                    return true;
                }
                else
                {
                    conn.Desconectar();
                    return false;
                }
            }
            catch (Exception ex)
            {
                var error = ex;
                return false;
            }
        }
    }
}
