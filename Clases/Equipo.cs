using Administracion_equipos.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Administracion_equipos.Clases
{
    public class Equipo: IPersistente
    {
        public int EquipoId { get; set; } = 0;

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

        public bool Create()
        {
            try
            {
                CommonBC.ModeloEquipo.spEquipoSave(
                    this.NombreEquipo,
                    this.CantidadJugadores,
                    Security.AES_Helper.Encrypt(this.NombreDT, AES_Helper.ENCRYP_KEY),
                    Security.AES_Helper.Encrypt(this.TipoEquipo, AES_Helper.ENCRYP_KEY),
                    Security.AES_Helper.Encrypt(this.CapitanEquipo, AES_Helper.ENCRYP_KEY),
                    this.TieneSub21
                );

                CommonBC.ModeloEquipo.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("nO SE GUARDOOOOOO", ex);
                return false;
            }
        }

        public bool Read(int id)
        {   
            //Por ahora no se implemante, no estaba en el requerimieto la vista de detalle de equipo
            throw new NotImplementedException();
        }

        public bool Update()
        {
            try
            {
                CommonBC.ModeloEquipo.spEquipoUpdateById(
                    this.EquipoId,
                    this.NombreEquipo,
                    this.CantidadJugadores,
                    this.NombreDT,
                    this.TipoEquipo,
                    this.CapitanEquipo,
                    this.TieneSub21
                );

                CommonBC.ModeloEquipo.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                CommonBC.ModeloEquipo.spEquipoDeleteById(id);
                CommonBC.ModeloEquipo.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {   
                
                return false;
            }
        }
    }
}
