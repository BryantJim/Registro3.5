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
            NombresTextBox.Focus();
        }

        private Estudiantes LlenarClase()
        {
            Estudiantes estudiante = new Estudiantes();
            estudiante.EstudianteId = Convert.ToInt32(EstudianteIdTextBox.Text);
            estudiante.Nombre = NombresTextBox.Text;
            estudiante.Telefono = TelefonoTextBox.Text;
            estudiante.Cedula = CedulaTextBox.Text;
            estudiante.Direccion = DireccionTextBox.Text;
            estudiante.FechaNacimiento = Convert.ToDateTime(FechaNacimientoDatePicker.SelectedDate);
            estudiante.Balance = COSTO;

            return estudiante;
        }

        private void LlenarCampo(Estudiantes estudiante)
        {
            EstudianteIdTextBox.Text = Convert.ToString(estudiante.EstudianteId);
            NombresTextBox.Text = estudiante.Nombre;
            TelefonoTextBox.Text = estudiante.Telefono;
            CedulaTextBox.Text = estudiante.Cedula;
            DireccionTextBox.Text = estudiante.Direccion;
            FechaNacimientoDatePicker.SelectedDate = Convert.ToDateTime(estudiante.FechaNacimiento);
        }

        private bool existeEnLaBaseDeDatos()
        {
            Estudiantes estudiante = EstudiantesBLL.Buscar(Convert.ToInt32(EstudianteIdTextBox.Text));
            return (estudiante != null);
        }

        private bool Validar()
        {
            bool paso = true;

            if (string.IsNullOrWhiteSpace(EstudianteIdTextBox.Text))
            {
                MessageBox.Show("No puede dejar el campo de estudiante id vacio");
                EstudianteIdTextBox.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(NombresTextBox.Text))
            {
                MessageBox.Show("No puede dejar el campo de Nombre Vacio");
                NombresTextBox.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(TelefonoTextBox.Text))
            {
                MessageBox.Show("No puede dejar el campo de Telefono vacio");
                TelefonoTextBox.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(CedulaTextBox.Text))
            {
                MessageBox.Show("No puede dejar el campo de cedula vacio");
                CedulaTextBox.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(DireccionTextBox.Text))
            {
                MessageBox.Show("No puede dejar el campo de Direccion vacio");
                DireccionTextBox.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(FechaNacimientoDatePicker.Text))
            {
                MessageBox.Show("No puede dejar el campo de fecha de nacimiento vacio");
                FechaNacimientoDatePicker.Focus();
                paso = false;
            }

            return paso;
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            Estudiantes estudiante;
            Inscripciones inscripcion;
            bool paso = false;

            if (!Validar())
                return;

            estudiante = LlenarClase();

            //determinar si es guardar o modificar
            if (EstudianteIdTextBox.Text == "0")
            {
                paso = EstudiantesBLL.Guardar(estudiante);
            }   
            else
            {
                if (!existeEnLaBaseDeDatos())
                {
                    MessageBox.Show("No se puede Modificar un estudiante que no existe");
                    return;
                }
                paso = EstudiantesBLL.Modificar(estudiante);
                //paso = InscripcionBLL.Modificar(inscripcion);
            }

            //informar resurtado
            if (paso)
            {
                Limpiar();
                MessageBox.Show("Guardado");
            }
            else
                MessageBox.Show("No se pudo Guardar");
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            int id;
            Estudiantes estudiante = new Estudiantes();
            int.TryParse(EstudianteIdTextBox.Text, out id);

            Limpiar();

            estudiante = EstudiantesBLL.Buscar(id);

            if (estudiante != null)
            {
                MessageBox.Show("Estudiante Encontrado");
                LlenarCampo(estudiante);
            }
            else
                MessageBox.Show("Estudiante no Encontrado");
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            int id;
            int.TryParse(EstudianteIdTextBox.Text, out id);

            Limpiar();

            if (EstudiantesBLL.Eliminar(id))
            {
                MessageBox.Show("Estudiante Eliminado", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("No se puede Eliminar un Estudiante que no existe");
        }
    }
}
