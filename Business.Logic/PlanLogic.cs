using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class PlanLogic : BusinessLogic
    {
        private PlanAdapter _PlanData;

        public PlanAdapter PlanData
        {
            get { return _PlanData; }
            set { _PlanData = value; }
        }

        private EspecialidadAdapter _EspecialidadData;
        public EspecialidadAdapter EspecialidadData 
        { 
            get { return _EspecialidadData; }
            set { _EspecialidadData = value; } 
        }

        public PlanLogic()
        {
            PlanData = new PlanAdapter();
            EspecialidadData = new EspecialidadAdapter();
        }

        public List<Plan> GetAll()
        {
            List<Plan> lista = PlanData.GetAll();
            return lista;
        }

        public Plan GetOne(int ID)
        {
            return PlanData.GetOne(ID);
        }

        public void Delete(int ID)
        {
            //Borra plan
             PlanData.Delete(ID);

            //Borra materias que dependen del plan
            MateriaAdapter MatData = new MateriaAdapter();
            MatData.DeleteByPlan(ID);
        }

        public void Save(Plan plan)
        {
            List<Especialidad> especialidades = EspecialidadData.GetAll();
            bool espExiste = false;

            foreach (Especialidad especialidad in especialidades)
            {
                if (especialidad.ID == plan.IDEspecialidad)
                {
                    espExiste = true;
                    break;
                }
            }

            if (espExiste)
            {
                PlanData.Save(plan);
            }
            else
            {
                Exception ex = new Exception("Error al guardar plan: no existe la especialidad ingresada.");
                throw ex;
            }
        }

    }
}
