using Practice_20220107.Data;
using Practice_20220107.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practice_20220107
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
        private void CompletarGrid()
        {
            DataTable datos = EmpleadoDB.MostrarEmpleados();
            if (datos == null)
            {
                MessageBox.Show("No se logró cargar los datos");
            }
            else
            {
                Listado.DataSource = datos.DefaultView;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CompletarGrid();
        }

        private void LimpiarCampos()
        {
            txtDocumento.Text = "";
            txtNombres.Text = "";
            txtApellidos.Text = "";
            intEdad.Text = "";
            txtDomicilio.Text = "";
            txtFNacimiento.Text = "";
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            if(txtDocumento.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar un documento válido");
            }
            else if (txtNombres.Text.Trim().Length < 4)
            {
                MessageBox.Show("Debe ingresar un nombre válido");
            }
            else if (intEdad.Text.Trim().Length < 2)
            {
                MessageBox.Show("Debe ingresar una edad válida");
            }
            else if (txtApellidos.Text.Trim().Length < 4)
            {
                MessageBox.Show("Debe ingresar un apellido válido");
            }
            else if (txtDomicilio.Text.Trim().Length < 5)
            {
                MessageBox.Show("Debe ingresar un domicilio válido");
            }
            else
            {
                try
                {
                    EmpleadoClass em = new EmpleadoClass();
                    em.Documento1 = txtDocumento.Text.Trim();
                    em.Nombre1 = txtNombres.Text.Trim();
                    em.Apellido1 = txtApellidos.Text.Trim();
                    em.Edad1 = Convert.ToInt32(intEdad.Text.Trim());
                    em.Domicilio1 = txtDomicilio.Text.Trim();
                    em.Fecha_Nacimiento1 = txtFNacimiento.Value.Year + "-" + txtFNacimiento.Value.Month + "-" + txtFNacimiento.Value.Day;

                    if (EmpleadoDB.GuardarEmpleado(em))
                    {
                        CompletarGrid();
                        LimpiarCampos();
                        MessageBox.Show("Empleado guardado correctamente");
                    }
                    else
                    {
                        MessageBox.Show("ERROR - No se pudo guardar");
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        bool fueConsultado = false;
        private void btn_consulta_Click(object sender, EventArgs e)
        {
            if (txtDocumento.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar un documento válido");
            }
            else
            {
                EmpleadoClass em = EmpleadoDB.ConsultarEmpleado(txtDocumento.Text.Trim());
                if(em == null)
                {
                    MessageBox.Show("No existe empleado con documento " + txtDocumento.Text);
                    LimpiarCampos();
                    fueConsultado = false;
                }
                else
                {
                    txtDocumento.Text = em.Documento1;
                    txtNombres.Text = em.Nombre1;
                    txtApellidos.Text = em.Apellido1;
                    intEdad.Text = em.Edad1.ToString();
                    txtDomicilio.Text = em.Domicilio1;
                    txtFNacimiento.Text = em.Fecha_Nacimiento1;
                    fueConsultado = true;
                }
            }
        }

        private void btn_actualizar_Click(object sender, EventArgs e)
        {
            if (!fueConsultado)
            {
                MessageBox.Show("Debe hacer la consulta por documento primero");
            }
            else
            {
                if (txtDocumento.Text.Trim() == "")
                {
                    MessageBox.Show("Debe ingresar un documento válido");
                }
                else if (txtNombres.Text.Trim().Length < 4)
                {
                    MessageBox.Show("Debe ingresar un nombre válido");
                }
                else if (intEdad.Text.Trim().Length < 2)
                {
                    MessageBox.Show("Debe ingresar una edad válida");
                }
                else if (txtApellidos.Text.Trim().Length < 4)
                {
                    MessageBox.Show("Debe ingresar un apellido válido");
                }
                else if (txtDomicilio.Text.Trim().Length < 5)
                {
                    MessageBox.Show("Debe ingresar un domicilio válido");
                }
                else
                {
                    try
                    {
                        EmpleadoClass em = new EmpleadoClass();
                        em.Documento1 = txtDocumento.Text.Trim();
                        em.Nombre1 = txtNombres.Text.Trim();
                        em.Apellido1 = txtApellidos.Text.Trim();
                        em.Edad1 = Convert.ToInt32(intEdad.Text.Trim());
                        em.Domicilio1 = txtDomicilio.Text.Trim();
                        em.Fecha_Nacimiento1 = txtFNacimiento.Value.Year + "-" + txtFNacimiento.Value.Month + "-" + txtFNacimiento.Value.Day;

                        if (EmpleadoDB.ActualizarEmpleado(em))
                        {
                            CompletarGrid();
                            LimpiarCampos();
                            MessageBox.Show("Empleado actualizado correctamente");
                            fueConsultado = false;
                        }
                        else
                        {
                            MessageBox.Show("ERROR - No se pudo actualizar");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            if (!fueConsultado)
            {
                MessageBox.Show("Debe hacer la consulta por documento primero");
            }
            else
            {
                if (txtDocumento.Text.Trim() == "")
                {
                    MessageBox.Show("Debe ingresar un documento válido");
                }
                else if (DialogResult.Yes == MessageBox.Show(null, "Realmente desea eliminar el empleado?", "Confirmar", MessageBoxButtons.YesNo))
                
                {
                    try
                    {
                        EmpleadoClass em = new EmpleadoClass();
                        em.Documento1 = txtDocumento.Text.Trim();
                        em.Nombre1 = txtNombres.Text.Trim();
                        em.Apellido1 = txtApellidos.Text.Trim();
                        em.Edad1 = Convert.ToInt32(intEdad.Text.Trim());
                        em.Domicilio1 = txtDomicilio.Text.Trim();
                        em.Fecha_Nacimiento1 = txtFNacimiento.Value.Year + "-" + txtFNacimiento.Value.Month + "-" + txtFNacimiento.Value.Day;

                        if (EmpleadoDB.EliminarEmpleado(txtDocumento.Text.Trim()))
                        {
                            CompletarGrid();
                            LimpiarCampos();
                            MessageBox.Show("Empleado eliminado correctamente");
                            fueConsultado = false;
                        }
                        else
                        {
                            MessageBox.Show("ERROR - No se pudo eliminar");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }
    }
}