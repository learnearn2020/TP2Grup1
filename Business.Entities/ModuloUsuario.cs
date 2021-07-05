using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class ModuloUsuario : BusinessEntity
    {
        private int _idUsuario;
        private int _idModulo;
        private bool _permitirAlta;
        private bool _permitirBaja;
        private bool _permitirModificacion;
        private bool _permitirConsulta;
        public int IdUsuario
        {
            get { return _idUsuario; }
            set { _idUsuario = value; }
        }

        public int IdModulo
        {
            get { return _idModulo; }
            set { _idModulo = value; }
        }

        public bool PermitirAlta
        {
            get { return _permitirAlta; }
            set { _permitirAlta = value; }
        }

        public bool PermitirBaja
        {
            get { return _permitirBaja; }
            set { _permitirBaja = value; }
        }

        public bool PermitirModificacion
        {
            get { return _permitirModificacion; }
            set { _permitirModificacion = value; }     
        }
      

        public bool PermitirConsulta
        {
            get { return _permitirConsulta; }
            set { _permitirConsulta = value; }
        }


    }
   
}
