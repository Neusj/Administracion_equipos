using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Administracion_equipos.Clases
{
    public class Equipo
    {
        public string NombreEquipo { get; set; } = null;
        public string NombreDT { get; set; } = null;
        public string TipoEquipo { get; set; } = null;
        public string CapitanEquipo { get; set; } = null;
        public int CantidadJugadores { get; set; }
        public bool TieneSub21 { get; set; }


        public Equipo(
            string nombreEquipo,
            string nombreDT,
            string tipoEquipo,
            string capitanEquipo,
            int cantidadJugadores,
            bool tieneSub21
        ) {
            NombreEquipo = nombreEquipo;
            NombreDT = nombreDT;
            TipoEquipo = tipoEquipo;
            CapitanEquipo = capitanEquipo;
            CantidadJugadores = cantidadJugadores;
            TieneSub21 = tieneSub21;
        }

        public Equipo(){}
    }
}
