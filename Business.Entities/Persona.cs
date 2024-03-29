﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Persona : BusinessEntity
    {

        private string _Apellido;
        private string _Direccion;
        private string _Email;
        private DateTime _FechaNacimiento;
        private int _IDPlan;
        private int _Legajo;
        private string _Nombre;
        private string _Telefono;
        private TiposPersonas _TipoPersona;
        private string _NombreUsuario;
        private string _Clave;
        private bool _Habilitado;


        public string Apellido { get { return _Apellido; } set { _Apellido = value; } }
        public string Direccion { get { return _Direccion; } set { _Direccion = value; } }
        public string Email { get { return _Email; } set { _Email = value; } }
        public DateTime FechaNacimiento { get { return _FechaNacimiento; } set { _FechaNacimiento = value; } }
        public int IDPlan { get { return _IDPlan; } set { _IDPlan = value; } }
        public int Legajo { get { return _Legajo; } set { _Legajo = value; } }
        public string Nombre { get { return _Nombre; } set { _Nombre = value; } }
        public string Telefono { get { return _Telefono; } set { _Telefono = value; } }

        public string NombreUsuario { get { return _NombreUsuario; } set { _NombreUsuario = value; } }
        public string Clave { get { return _Clave; } set { _Clave = value; } }
        public bool Habilitado { get { return _Habilitado; } set { _Habilitado = value; } }

       public TiposPersonas TipoPersona { get { return _TipoPersona; } set { _TipoPersona = value; } }

        public enum TiposPersonas
        {
            Docente,
            Alumno
        }
    }
}
