using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;


namespace Business.Logic
{
    public class MateriaLogic : BusinessLogic
    {

        private MateriaAdapter _MateriaData;

        public MateriaAdapter MateriaData 
        { 
            get { return _MateriaData; }  
            set{ _MateriaData = value; } 
        }

        private PlanAdapter _PlanData;

        public PlanAdapter PlanData
        {
            get { return _PlanData; }
            set { _PlanData = value; }
        }

        public MateriaLogic()
        {
            MateriaData = new MateriaAdapter();
            PlanData = new PlanAdapter();
        }

        public List<Materia> GetAll()
        {
            List<Materia> lista = MateriaData.GetAll();
            return lista;
        }

        public Materia GetOne(int ID)
        {
            return MateriaData.GetOne(ID);
        }

        public void Delete(int ID)
        {
            MateriaData.Delete(ID);
        }

        public void Save(Materia materia)
        {
            List<Plan> planes = PlanData.GetAll();
            bool planExiste = false;

            foreach (Plan plan in planes)
            {
                if (plan.ID == materia.IDPlan)
                {
                    planExiste = true;
                    break;
                }
            }

            if (planExiste)
            {
                MateriaData.Save(materia);
            }
            else
            {
                Exception ex = new Exception("Error al guardar materia: no existe el plan ingresado.");
                throw ex;
            }
        }

    }
}
