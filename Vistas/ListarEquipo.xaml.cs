using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// Lógica de interacción para ListarEquipo.xaml
    /// </summary>
    public partial class ListarEquipo : Window
    {
        public ListarEquipo()
        {
            InitializeComponent();
            dgAllEquipos.ItemsSource = Clases.EquipoCollection.equipos;
            dgAllEquipos.CanUserAddRows = false;
        }

        private void btnActualizaEquipoClick(object sender, RoutedEventArgs e)
        {
            var equipo = (Clases.Equipo)dgAllEquipos.SelectedItem;
            Vistas.ActualizarEquipo actualizar = new ActualizarEquipo(equipo);
            actualizar.ShowDialog();

        }
        private void btnEliminaEquipoClick(object sender, RoutedEventArgs e)
        {
            int indexEquipo = dgAllEquipos.SelectedIndex;
            Clases.EquipoCollection.equipos.RemoveAt(indexEquipo);
            dgAllEquipos.Items.Refresh();
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            dgAllEquipos.Items.Refresh();
        }
    }
}
