using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Database;
using Business.Entities;

namespace Business.Logic
{
    public class UsuarioLogic : BusinessLogic
    {
        private Data.Database.UsuarioAdapter _UsuarioData;

        public Data.Database.UsuarioAdapter UsuarioData
        {
            get { return _UsuarioData; }
            set { _UsuarioData = value; }
        }

        public UsuarioLogic()
        {
            UsuarioData = new UsuarioAdapter();
        }

        public List<Usuario> GetAll()
        {
            List<Usuario> lista = UsuarioData.GetAll();
            return lista;
        }

        public Business.Entities.Usuario GetOne(int ID)
        {
            return UsuarioData.GetOne(ID);
        }

        public void Delete(int ID)
        {
            UsuarioData.Delete(ID);
        }

        public void Save(Business.Entities.Usuario User)
        {
            UsuarioData.Save(User);
        }
    }
}
