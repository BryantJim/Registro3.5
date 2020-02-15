using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Registro3._5.Entidades
{
    public class Estudiantes
    {
        [Key]
        public int EstudianteId { get; set; }
        public String Nombre { get; set; }
        public String Telefono { get; set; }
        public String Cedula { get; set; }
        public String Direccion { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public decimal Balance { get; set; }

        public Estudiantes()
        {
            EstudianteId = 0;
            Nombre = string.Empty;
            Telefono = string.Empty;
            Cedula = string.Empty;
            Direccion = string.Empty;
            FechaNacimiento = DateTime.Now;
            Balance = 0;
        }
    }
}
