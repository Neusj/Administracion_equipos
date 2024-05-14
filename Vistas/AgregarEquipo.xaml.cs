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
            Loaded += AgregarEquipo_Loaded;
            txtNombreEquipo.TextChanged += ValidarYHabilitarBotonGuardar;
            txtNombreDT.TextChanged += ValidarYHabilitarBotonGuardar;
            txtTipoEquipo.TextChanged += ValidarYHabilitarBotonGuardar;
            txtNombreCapitan.TextChanged += ValidarYHabilitarBotonGuardar;
            txtCantidadJugadores.TextChanged += ValidarYHabilitarBotonGuardar;
        }

        private void ValidarYHabilitarBotonGuardar(object sender, TextChangedEventArgs e)
        {
          
            HabilitarBotonGuardarSiEsValido();
        }
        private void AgregarEquipo_Loaded(object sender, RoutedEventArgs e)
        {
            btnGuardar.IsEnabled = false;
        }

        private void HabilitarBotonGuardarSiEsValido()
        {
            // Habilitar el botón de guardar si todos los campos son válidos
            btnGuardar.IsEnabled = ValidarDatos();
        }

        public void Agregar_equipo(object sender, RoutedEventArgs e)
        {
            if (!ValidarDatos()){ return; }


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
                MessageBox.Show("El equipo se creó correctamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else
            {
                MessageBox.Show("El equipo se creó correctamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }

        }

        private bool ValidarDatos()
        {
            bool isValid = true;
            txtErrores.Text = "";

            // Validación para el campo NombreEquipo
            if (string.IsNullOrEmpty(txtNombreEquipo.Text))
            {
                txtErrores.Text += "El nombre del equipo no puede estar vacío. \n";
                isValid = false;
            }
            else if (txtNombreEquipo.Text.Length < 8 || txtNombreEquipo.Text.Length > 25)
            {
                txtErrores.Text += "El nombre del equipo debe tener entre 8 y 25 caracteres.\n";
                isValid = false;
            }
            else if (!Regex.IsMatch(txtNombreEquipo.Text, @"^[a-zA-Z0-9\s\-_]+$"))
            {
                txtErrores.Text += "El nombre del equipo solo puede contener caracteres alfanuméricos.\n";
                isValid = false;
            }

            // Validación para el campo CantidadJugadores
            if (!int.TryParse(txtCantidadJugadores.Text, out int cantidad))
            {
                txtErrores.Text += "La cantidad de jugadores debe ser un número entero.\n";
                isValid = false;
            }
            else if (cantidad < 16 || cantidad > 25)
            {
                txtErrores.Text += "La cantidad de jugadores debe estar entre 16 y 25.\n";
                isValid = false;
            }

            // Validación para el campo NombreDT
            if (string.IsNullOrEmpty(txtNombreDT.Text))
            {
                txtErrores.Text += "El nombre del director técnico no puede estar vacío.\n";
                isValid = false;
            }
            else if (txtNombreDT.Text.Length < 5 || txtNombreDT.Text.Length > 30)
            {
                txtErrores.Text += "El nombre del director técnico debe tener entre 5 y 30 caracteres.\n";
                isValid = false;
            }

            // Validación para el campo TipoEquipo
            if (txtTipoEquipo.Text != "Masculino" && txtTipoEquipo.Text != "Femenino")
            {
                txtErrores.Text += "El tipo de equipo solo puede ser 'Masculino' o 'Femenino'.\n";
                isValid = false;
            }

            // Validación para el campo CapitanEquipo
            if (string.IsNullOrEmpty(txtNombreCapitan.Text))
            {
                txtErrores.Text += "El nombre del capitán del equipo no puede estar vacío.\n";
                isValid = false;
            }
            else if (txtNombreCapitan.Text.Length < 5 || txtNombreCapitan.Text.Length > 30)
            {
                txtErrores.Text += "El nombre del capitán del equipo debe tener entre 5 y 30 caracteres.\n";
                isValid = false;
            }
            return isValid;
        }


        private static Regex _regex = new Regex("[^0-9]+");
        public void CheckTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = _regex.IsMatch(e.Text);
        }

    }
}
