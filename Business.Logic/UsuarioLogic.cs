using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Data.Database;
using Business.Entities;

namespace Business.Logic
{
    public class UsuarioLogic : BusinessLogic
    {
        private UsuarioAdapter _usuarioData;

        public UsuarioAdapter Usuario
        {
            get { return _usuarioData; }
            set { _usuarioData = value; }
        }

        public UsuarioLogic()
        {
            _usuarioData = new UsuarioAdapter();
        }
        public List<Usuario> GetAll()
        {
            return Usuario.GetAll();
        }
        public Usuario GetOne(int id )
        {
            return Usuario.GetOne(id);

        }
        public void Delete(int id)
        {
            Usuario.Delete(id);
        }
        public void Save(Usuario usuario)
        {
            Usuario.Save(usuario);
        }

    }
}
