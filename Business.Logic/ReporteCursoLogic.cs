using Business.Entities;
using Data.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Logic
{
    public class ReporteCursoLogic: BusinessLogic
    {
        private ReporteCursoAdapter _ReporteCursonData;

        public ReporteCursoAdapter ReporteCursonData
        {
            get { return _ReporteCursonData; }
            set { _ReporteCursonData = value; }
        }

        public ReporteCursoLogic()
        {
            ReporteCursonData = new ReporteCursoAdapter();
        }

        public List<ReporteCurso> GetReporteCurso(int comisionID, int materiaId) 
        {
            var listaAlumnos = ReporteCursonData.GetAll(comisionID, comisionID);
            return listaAlumnos;
        } 
    }
}
