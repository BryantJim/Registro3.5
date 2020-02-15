using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Registro3._5.Entidades
{
    public class Inscripciones
    {
        [Key]
        public int InscripcionId { get; set; }
        public DateTime Fecha { get; set; }
        public int EstudianteId { get; set; }
        public String Comentario { get; set; }
        public decimal Balance { get; set; }
        public decimal Monto { get; set; }

        public Inscripciones()
        {
            InscripcionId = 0;
            Fecha = DateTime.Now;
            EstudianteId = 0;
            Comentario = string.Empty;
            Balance = 0;
            Monto = 0;
        }
    }
}
