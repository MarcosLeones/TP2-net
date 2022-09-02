using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class LoginLogic
    {
        private PersonaAdapter dataPersona;
        public LoginLogic()
        {
            dataPersona = new PersonaAdapter();
        }

        public Persona validarIngreso(string usuario, string clave)
        {
            Persona persona = dataPersona.GetByNombreUsuario(usuario);

            if (persona != null)
            {
                if (persona.Clave == clave && persona.Habilitado)
                {
                    return persona;
                }
            }

            persona = null;
            return persona;
        }
    }
}
