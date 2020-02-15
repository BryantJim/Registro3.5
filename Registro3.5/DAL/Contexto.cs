using System;
using System.Collections.Generic;
using System.Text;
using Registro3._5.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Registro3._5.DAL.Scripts
{
    public class Contexto : DbContext
    {
        public DbSet<Estudiantes> Estudiante { get; set; }
        public DbSet<Inscripciones> Inscripcion { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=BRYANTPC\SQLEXPRESS;Database=InscripcionDb;Trusted_Connection = True;");
        }
    }
}
