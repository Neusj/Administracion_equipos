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
    /// Lógica de interacción para AgregarEquipo.xaml
    /// </summary>
    public partial class AgregarEquipo : Window
    {
        public AgregarEquipo()
        {
            InitializeComponent();
        }

        public void Agregar_equipo(object sender, RoutedEventArgs e)
        {
            string NombreEquipo = txtNombreEquipo.Text;
            string NombreDT = txtNombreDT.Text;
            string TipoEquipo = txtTipoEquipo.Text;
            string CapitanEquipo = txtNombreCapitan.Text;
            int CantidadJugadores = Convert.ToInt32(txtCantidadJugadores.Text);
            bool TieneSub21 = chTieneSub21.IsChecked.Value ? true : false;

            Clases.Equipo equipo = new Clases.Equipo(NombreEquipo, NombreDT, TipoEquipo, CapitanEquipo,CantidadJugadores, TieneSub21);
            bool createResult = equipo.Create();
            MessageBoxResult newEquipoResult = new MessageBoxResult();

            if (createResult)
            {
                 newEquipoResult = MessageBox.Show("¿Desea crear otro equipo?", "Crear otro equipo", MessageBoxButton.YesNo, MessageBoxImage.Question);
            }
            else
            {
                MessageBox.Show("Error al crear el equipo.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                this.Close();

            }

            if (newEquipoResult == MessageBoxResult.Yes)
            {
                txtNombreEquipo.Text = "";
                txtNombreDT.Text = "";
                txtTipoEquipo.Text = "";
                txtNombreCapitan.Text = "";
                txtCantidadJugadores.Text = "";
                chTieneSub21.IsChecked = false;
            }
            else
            {
                MessageBox.Show("El equipo se creó correctamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }

        }

        private static Regex _regex = new Regex("[^0-9]+");
        public void CheckTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = _regex.IsMatch(e.Text);
        }

    }
}
