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
    public class EstudiantesBLL
    {

        public static bool Guardar(Estudiantes estudiante)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                if (db.Estudiante.Add(estudiante) != null)
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

        public static bool Modificar(Estudiantes estudiante)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                db.Entry(estudiante).State = EntityState.Modified;
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

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                var Eliminar = db.Estudiante.Find(id);
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

        public static Estudiantes Buscar(int id)
        {
            Estudiantes estudiante = new Estudiantes();
            Contexto db = new Contexto();

            try
            {
                estudiante = db.Estudiante.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return estudiante;
        }

        public static List<Estudiantes> GetList(Expression<Func<Estudiantes, bool>> estudiante)
        {
            List<Estudiantes> Lista = new List<Estudiantes>();
            Contexto db = new Contexto();

            try
            {
                Lista = db.Estudiante.Where(estudiante).ToList();
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
