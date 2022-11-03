using Business.Entities;
using Data.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util;

namespace Business.Logic
{
    public class CursoLogic : BusinessLogic
    {
        private CursoAdapter _CursoData;

        public CursoAdapter CursoData
        {
            get { return _CursoData; }
            set { _CursoData = value; }
        }

        public CursoLogic()
        {
            CursoData = new CursoAdapter();
        }

        public List<Curso> GetAll()
        {
            List<Curso> lista = CursoData.GetAll();
            return lista;
        }

        public Curso GetOne(int ID)
        {
            return CursoData.GetOne(ID);
        }

        public void Delete(int ID)
        {
            CursoData.Delete(ID);
        }

        public void Save(Curso curso)
        {
            CursoData.Save(curso);
        }

        public List<ContenedorCurso> GetCursosCompletos()
        {
            return CursoData.GetCursosCompletos();
        }
    }

}


