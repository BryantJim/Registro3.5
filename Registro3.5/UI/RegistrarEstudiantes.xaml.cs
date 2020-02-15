using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Registro3._5.BLL;
using Registro3._5.DAL;
using Registro3._5.Entidades;

namespace Registro3._5.UI
{
    /// <summary>
    /// Interaction logic for RegistrarEstudiantes.xaml
    /// </summary>
    public partial class RegistrarEstudiantes : Window
    {
        const decimal COSTO = 500;

        public RegistrarEstudiantes()
        {
            InitializeComponent();
            EstudianteIdTextBox.Text = "0";
            FechaNacimientoDatePicker.SelectedDate = DateTime.Now;
        }

        private void Limpiar()
        {
            EstudianteIdTextBox.Text = "0";
            NombresTextBox.Text = string.Empty;
            TelefonoTextBox.Text = string.Empty;
            CedulaTextBox.Text = string.Empty;
            DireccionTextBox.Text = string.Empty;
            FechaNacimientoDatePicker.SelectedDate = DateTime.Now;
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }
    }
}
