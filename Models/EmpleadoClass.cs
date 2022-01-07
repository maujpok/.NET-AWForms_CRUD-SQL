using System;
using System.Collections.Generic;
using System.Text;

namespace Practice_20220107.Models
{
    class EmpleadoClass
    {
        private string Documento;
        private string Nombre;
        private string Apellido;
        private int Edad;
        private string Domicilio;
        private string Fecha_Nacimiento;

        public EmpleadoClass()
        {
            this.Documento = "";
            this.Nombre = "";
            this.Apellido = "";
            this.Edad = 0;
            this.Domicilio = "";
            this.Fecha_Nacimiento = "";
        }

        public string Documento1 { get => Documento; set => Documento = value; }
        public string Nombre1 { get => Nombre; set => Nombre = value; }
        public string Apellido1 { get => Apellido; set => Apellido = value; }
        public int Edad1 { get => Edad; set => Edad = value; }
        public string Domicilio1 { get => Domicilio; set => Domicilio = value; }
        public string Fecha_Nacimiento1 { get => Fecha_Nacimiento; set => Fecha_Nacimiento = value; }
    }
}