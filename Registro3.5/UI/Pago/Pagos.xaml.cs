using Registro3._5.Entidades;
using Registro3._5.BLL;
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

namespace Registro3._5.UI.Pago
{
    /// <summary>
    /// Interaction logic for Pagos.xaml
    /// </summary>
    public partial class Pagos : Window
    {
        public Pagos()
        {
            InitializeComponent();
            InscripcionIdTextBox.Text = "0";
            FechaPagoDatePicker.SelectedDate = DateTime.Now;
            EstudianteIdTextBox.Text = "0";
        }
        private void Limpiar()
        {
            InscripcionIdTextBox.Text = "0";
            FechaPagoDatePicker.SelectedDate = DateTime.Now;
            EstudianteIdTextBox.Text = "0";
            ComentariTextBox.Text = string.Empty;
            BalancesTextBox.Text = string.Empty;
            MontoTextBox.Text = string.Empty;
        }

        private void NuevButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private Inscripciones LlenarClaseI()
        {
            Inscripciones inscripcion = new Inscripciones();
            inscripcion.EstudianteId = Convert.ToInt32(EstudianteIdTextBox.Text);
            inscripcion.Fecha = Convert.ToDateTime(FechaPagoDatePicker.SelectedDate);
            inscripcion.InscripcionId = Convert.ToInt32(InscripcionIdTextBox.Text);
            inscripcion.Comentario = ComentariTextBox.Text;
            inscripcion.Balance = Convert.ToDecimal(BalancesTextBox.Text);
            inscripcion.Monto = Convert.ToDecimal(MontoTextBox.Text);

            return inscripcion;
        }

        private void LlenarCampo(Inscripciones inscripcion)
        {
            InscripcionIdTextBox.Text = Convert.ToString(inscripcion.InscripcionId);
            FechaPagoDatePicker.SelectedDate = Convert.ToDateTime(inscripcion.Fecha);
            EstudianteIdTextBox.Text = Convert.ToString(inscripcion.EstudianteId);
            ComentariTextBox.Text = inscripcion.Comentario;
            BalancesTextBox.Text = Convert.ToString(inscripcion.Balance);
            MontoTextBox.Text = Convert.ToString(inscripcion.Monto);
        }


        private bool existeEnLaBaseDeDatos()
        {
            Inscripciones inscripcion = InscripcionBLL.Buscar(Convert.ToInt32(InscripcionIdTextBox.Text));
            return (inscripcion != null);
        }

        private bool ExisteEnLaBaseDeDatosPersonas()
        {
            Estudiantes estudiante = EstudiantesBLL.Buscar(Convert.ToInt32(EstudianteIdTextBox.Text));
            return (estudiante != null);
        }

        //Para Verificar que existe el PersonaID en la la Inscripcion
        private bool PersonaIdExisteEnInscripcion()
        {
            bool paso = false;
            Inscripciones inscripcion;
            var listado = new List<Inscripciones>();
            listado = InscripcionBLL.GetList(p => true);
            int cantidad = listado.Count;

            for (int i = 1; i <= cantidad; i++)
            {
                inscripcion = InscripcionBLL.Buscar(i);
                if (inscripcion.EstudianteId == Convert.ToInt32(EstudianteIdTextBox.Text))
                {
                    paso = true;
                }
            }
            return paso;
        }

        private bool Validar()
        {
            bool paso = true;

            if (string.IsNullOrWhiteSpace(InscripcionIdTextBox.Text))
            {
                MessageBox.Show("No puede dejar el campo de inscripcion id vacio");
                InscripcionIdTextBox.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(EstudianteIdTextBox.Text))
            {
                MessageBox.Show("No puede dejar el campo de estudiante id Vacio");
                EstudianteIdTextBox.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(ComentariTextBox.Text))
            {
                MessageBox.Show("No puede dejar el campo de Comentario vacio");
                ComentariTextBox.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(MontoTextBox.Text))
            {
                MessageBox.Show("No puede dejar el campo de Monto vacio");
                MontoTextBox.Focus();
                paso = false;
            }
            else if (Convert.ToDecimal(MontoTextBox.Text) < 1)
            {
                MessageBox.Show("No se puede ingresar un monto igual a 0 o negativo");
                MontoTextBox.Focus();
                paso = false;
            }
            else if (Convert.ToDecimal(MontoTextBox.Text) > Convert.ToDecimal(BalancesTextBox.Text))
            {
                MessageBox.Show("No puede ingresar un monto mayor que el balance actual");
                MontoTextBox.Focus();
                paso = false;
            }

            return paso;
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            Inscripciones inscripcion;
            bool paso = false;

            if (!Validar())
                return;

            inscripcion = LlenarClaseI();
            if (InscripcionIdTextBox.Text == "0" && ExisteEnLaBaseDeDatosPersonas() == true)
                paso = InscripcionBLL.Guardar(inscripcion);
            else
            {
                if (!existeEnLaBaseDeDatos())
                {
                    MessageBox.Show("No se puede Modificar un estudiante o inscripcion que no existe");
                    return;
                }
                paso = InscripcionBLL.Modificar(inscripcion);
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

        private void BuscaButton_Click(object sender, RoutedEventArgs e)
        {
            int id;
            Inscripciones inscripcion = new Inscripciones();
            int.TryParse(EstudianteIdTextBox.Text, out id);

            Limpiar();

            inscripcion = InscripcionBLL.Buscar(id);

            if (inscripcion != null)
            {
                MessageBox.Show("Inscripcion Encontrado");
                LlenarCampo(inscripcion);
            }
            else
                MessageBox.Show("Inscripcion no Encontrado");
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            int id;
            int.TryParse(EstudianteIdTextBox.Text, out id);

            Limpiar();

            if (InscripcionBLL.Eliminar(id))
            {
                MessageBox.Show("Inscripcion Eliminada", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("No se puede Eliminar una inscripcion que no existe");
        }
    }
}
