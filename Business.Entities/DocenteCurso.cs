﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class DocenteCurso : BusinessEntity
    {
//        private TiposCargos _Cargo;
        private int _IDCurso;
        private int _IDDocente;

//        public TiposCargos Cargo { get { return _IDCurso; } set { _IDCurso = value; } }
        public int IDCurso { get { return _IDDocente; } set { _IDDocente = value; } }
        public int IDDocente { get { return _IDDocente; } set { _IDDocente = value; } }
    }
}
