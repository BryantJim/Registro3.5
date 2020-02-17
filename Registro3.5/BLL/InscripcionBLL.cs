using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Linq;
using Registro3._5.Entidades;
using Registro3._5.DAL;
using Registro3._5.DAL.Scripts;

namespace Registro3._5.BLL
{
    public class InscripcionBLL
    {
        public static bool DisminuirBalance(Inscripciones inscripcion)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                db.Estudiantes.Find(inscripcion.EstudianteId).Balance -= inscripcion.Monto;
                paso = (db.SaveChanges() > 0);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        public static bool AumentarBalance(Inscripciones inscripcion)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                db.Estudiantes.Find(inscripcion.EstudianteId).Balance += inscripcion.Monto;
                paso = (db.SaveChanges() > 0);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        public static bool Guardar(Inscripciones inscripcion)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                if (db.Inscripcion.Add(inscripcion) != null)
                    paso = (db.SaveChanges() > 0 && AumentarBalance(inscripcion));
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        public static bool Modificar(Inscripciones inscripcion)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                db.Entry(inscripcion).State = EntityState.Modified;
                paso = (db.SaveChanges() > 0 && DisminuirBalance(inscripcion));
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                var Eliminar = db.Inscripcion.Find(id);
                db.Entry(Eliminar).State = EntityState.Deleted;
                paso = (db.SaveChanges() > 0);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        public static Inscripciones Buscar(int id)
        {
            Inscripciones inscripcion = new Inscripciones();
            Contexto db = new Contexto();

            try
            {
                inscripcion = db.Inscripcion.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return inscripcion;
        }

        public static List<Inscripciones> GetList(Expression<Func<Inscripciones, bool>> inscripcion)
        {
            List< Inscripciones> Lista = new List<Inscripciones>();
            Contexto db = new Contexto();

            try
            {
                Lista = db.Inscripcion.Where(inscripcion).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return Lista;
        }
    }
}

