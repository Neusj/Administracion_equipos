using Administracion_equipos.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Administracion_equipos.Vistas
{
    /// <summary>
    /// Lógica de interacción para ActualizarEquipo.xaml
    /// </summary>
    public partial class ActualizarEquipo : Window
    {
        Clases.Equipo _Equipo = new Clases.Equipo();
        public ActualizarEquipo(Clases.Equipo equipo)
        {
            InitializeComponent();
            _Equipo = equipo;
            CargaDatosForm();
        }

        private void CargaDatosForm()
        {
            txtNombreEquipo.Text = this._Equipo.NombreEquipo;
            txtNombreDT.Text = this._Equipo.NombreDT;
            txtTipoEquipo.Text = this._Equipo.TipoEquipo;
            txtNombreCapitan.Text = this._Equipo.CapitanEquipo;
            txtCantidadJugadores.Text = Convert.ToString(this._Equipo.CantidadJugadores);
            chTieneSub21.IsChecked = this._Equipo.TieneSub21;
        }

        public void Actualizar_equipo(object sender, RoutedEventArgs e)
        {
            Clases.Equipo equipo_temp = new Clases.Equipo();

            equipo_temp.EquipoId = this._Equipo.EquipoId;
            equipo_temp.NombreEquipo = txtNombreEquipo.Text;
            equipo_temp.NombreDT = txtNombreDT.Text;
            equipo_temp.TipoEquipo = txtTipoEquipo.Text;
            equipo_temp.CapitanEquipo = txtNombreCapitan.Text;
            equipo_temp.CantidadJugadores = Convert.ToInt32(txtCantidadJugadores.Text);
            equipo_temp.TieneSub21 = chTieneSub21.IsChecked.Value ? true : false;


            bool updateResult = equipo_temp.Update();
          
            if (updateResult)
            {
                MessageBox.Show("El equipo se actualizó correctamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else
            {
                MessageBox.Show("Error al actualizar el equipo.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            this.Close();
        }

        private static Regex _regex = new Regex("[^0-9]+");
        public void CheckTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = _regex.IsMatch(e.Text);
        }
    }
}
