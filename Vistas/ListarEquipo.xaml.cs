using Administracion_equipos.Clases;
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
        EquipoCollection equipoCollection = new EquipoCollection();

        public ListarEquipo()
        {
            InitializeComponent();
            dgAllEquipos.ItemsSource = equipoCollection.ReadAll();
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
            MessageBoxResult messageResult = MessageBox.Show(
                "¿Está seguro de que desea eliminar este equipo?",
                "Confirmación",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question
            );
            if ( messageResult == MessageBoxResult.Yes)
            {
                Equipo equipo = (Equipo)dgAllEquipos.SelectedItem;
                bool deleteResult = equipo.Delete(equipo.EquipoId);
                if (deleteResult)
                {
                    dgAllEquipos.ItemsSource = equipoCollection.ReadAll();
                    MessageBox.Show("El equipo se eliminó correctamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Error al eliminar el equipo.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                }
            }
        }

    }
}
