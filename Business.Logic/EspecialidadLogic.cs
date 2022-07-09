using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Database;
using Business.Entities;

namespace Business.Logic
{
    public class EspecialidadLogic : BusinessLogic
    {
        private EspecialidadAdapter _EspecialidadData;

        public EspecialidadAdapter EspecialidadData { get { return _EspecialidadData; } set { _EspecialidadData = value; } }

        public EspecialidadLogic()
        {
            EspecialidadData = new EspecialidadAdapter();
        }

        public List<Especialidad> GetAll()
        {
            List<Especialidad> lista = EspecialidadData.GetAll();
            return lista;
        }

        public Especialidad GetOne(int ID)
        {
            return EspecialidadData.GetOne(ID);
        }

        public void Delete(int ID)
        {
            EspecialidadData.Delete(ID);
        }

        public void Save(Especialidad esp)
        {
            EspecialidadData.Save(esp);
        }
    }
}
