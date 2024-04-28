using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Administracion_equipos.Clases
{
    public class EquipoCollection
    {
        public List<Equipo> ReadAll()
        {
            var equipos = CommonBC.ModeloEquipo.ListaEquipos;
            return getEquipos(equipos.ToList());
        }

        private List<Equipo> getEquipos(List<ListaEquipos> equipos)
        {
            List<Equipo> equiposList = new List<Equipo>();
            foreach (ListaEquipos equipo in equipos)
            {
                Equipo e = new Equipo();
                e.EquipoId = equipo.EquipoId;
                e.NombreEquipo = equipo.NombreEquipo;
                e.CapitanEquipo = equipo.CapitanEquipo;
                e.NombreDT = equipo.NombreDT;
                e.TipoEquipo = equipo.TipoEquipo;
                e.CantidadJugadores = equipo.CantidadJugadores;
                e.TieneSub21 = equipo.TieneSub21;

                equiposList.Add(e);
            }

            return equiposList;
        }
    }
}
