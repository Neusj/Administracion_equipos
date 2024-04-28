using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Administracion_equipos.Clases
{
    public class EquipoReportes
    {
        public int getCantidadFemeninos()
        {
            var cantidadFemeninos = CommonBC.ModeloEquipo.spObtenerCantidadEquiposFemeninos().FirstOrDefault();
            if (cantidadFemeninos != null)
            {
                return cantidadFemeninos.Value;
            }
            else
            {
                return 0;
            }
        }

        public int getCantidadMasculinos()
        {
            var cantidadFemeninos = CommonBC.ModeloEquipo.spObtenerCantidadEquiposMasculinos().FirstOrDefault();
            if (cantidadFemeninos != null)
            {
                return cantidadFemeninos.Value;
            }
            else
            {
                return 0;
            }
        }
    }
}
