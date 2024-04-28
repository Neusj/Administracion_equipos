using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Administracion_equipos.Clases
{
    public class CommonBC
    {
        private static PCEEntities _modeloEquipo;
        public static PCEEntities ModeloEquipo
        {
            get
            {
                if (_modeloEquipo == null)
                {
                    _modeloEquipo = new PCEEntities();
                }
                return _modeloEquipo;
            }
        }

        public CommonBC() { }
    }
}
