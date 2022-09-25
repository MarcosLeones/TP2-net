using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Database;
using Business.Entities;

namespace Business.Logic
{
    public class PersonaLogic : BusinessLogic
    {
        private PersonaAdapter _PersonaData;

        public PersonaAdapter PersonaData
        {
            get { return _PersonaData; }
            set { _PersonaData = value; }
        }

        public PersonaLogic()
        {
            PersonaData = new PersonaAdapter();
        }

        public List<Persona> GetAll()
        {
            List<Persona> lista = PersonaData.GetAll();
            return lista;
        }

        public Persona GetOne(int ID)
        {
            return PersonaData.GetOne(ID);
        }

        public void Delete(int ID)
        {
            PersonaData.Delete(ID);
        }

        public void Save(Persona per)
        {
            PersonaData.Save(per);
        }

        public List<Persona> GetAllAlumnos()
        {
            return PersonaData.GetAllAlumnos();
        }

        public List<Persona> GetAllDocentes()
        {
            return PersonaData.GetAllDocentes();
        }
    }
}
