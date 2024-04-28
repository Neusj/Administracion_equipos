using Administracion_equipos.Clases;
using Administracion_equipos.Vistas;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Administracion_equipos
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Agregar_Click(object sender, RoutedEventArgs e)
        {
            AgregarEquipo agregarEquipo = new AgregarEquipo();
            agregarEquipo.ShowDialog();
        }
        private void Listar_Click(object sender, RoutedEventArgs e)
        {
            ListarEquipo listarEquipos = new ListarEquipo();
            listarEquipos.ShowDialog();
        }
        private void AcercaDe_Click(object sender, RoutedEventArgs e)
        {
            vistas.AcercaDe acercaDe = new vistas.AcercaDe();
            acercaDe.ShowDialog();
        }

        private void cantidad_Masculinos(object sender, RoutedEventArgs e)
        {
            EquipoReportes equipoReportes = new EquipoReportes();
            int cantidadMasculinos = equipoReportes.getCantidadMasculinos();

            MessageBox.Show(
                $"La cantidad de equipos masculinos es: {cantidadMasculinos}",
                "Cantidad de Equipos Masculinos",
                MessageBoxButton.OK,
                MessageBoxImage.Information
            );
        }
        private void cantidad_Femeninos(object sender, RoutedEventArgs e)
        {
            EquipoReportes equipoReportes = new EquipoReportes();
            int cantidadFemeninos = equipoReportes.getCantidadFemeninos();

            MessageBox.Show(
                $"La cantidad de equipos femeninos es: {cantidadFemeninos}",
                "Cantidad de Equipos Femeninos",
                MessageBoxButton.OK,
                MessageBoxImage.Information
            );
        }
    }
}
