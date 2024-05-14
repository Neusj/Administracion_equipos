using Administracion_equipos.Security;
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
                e.CapitanEquipo = Security.AES_Helper.Decrypt(equipo.CapitanEquipo, AES_Helper.ENCRYP_KEY);
                e.NombreDT = Security.AES_Helper.Decrypt(equipo.NombreDT, AES_Helper.ENCRYP_KEY);
                e.TipoEquipo = Security.AES_Helper.Decrypt(equipo.TipoEquipo, AES_Helper.ENCRYP_KEY);
                e.CantidadJugadores = equipo.CantidadJugadores;
                e.TieneSub21 = equipo.TieneSub21;

                equiposList.Add(e);
            }

            return equiposList;
        }
    }
}
