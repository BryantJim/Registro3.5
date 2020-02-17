using Microsoft.VisualStudio.TestTools.UnitTesting;
using Registro3._5.BLL;
using Registro3._5.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Registro3._5.BLL.Tests
{
    [TestClass()]
    public class InscripcionBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            bool paso;
            Inscripciones inscripcion = new Inscripciones();

            inscripcion.InscripcionId = 0;
            inscripcion.EstudianteId = 1;
            inscripcion.Fecha = DateTime.Now;
            inscripcion.Comentario = "Usted lo hizo bien";
            inscripcion.Monto = 400;
            inscripcion.Balance = 1000 -inscripcion.Monto;

            paso = InscripcionBLL.Guardar(inscripcion);

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            bool paso;

            Inscripciones inscricion = new Inscripciones();
            inscricion.InscripcionId = 1;
            inscricion.EstudianteId = 1;
            inscricion.Fecha = DateTime.Now;
            inscricion.Comentario = "Se Hizo Correcto El Test";
            inscricion.Monto = 300;
            inscricion.Balance = 1000;

            paso = InscripcionBLL.Modificar(inscricion);

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso;
            paso = InscripcionBLL.Eliminar(1);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            Inscripciones inscripciones;
            inscripciones = InscripcionBLL.Buscar(1);
            Assert.AreEqual(inscripciones, inscripciones);
        }

        [TestMethod()]
        public void GetListTest()
        {
            var Listado = new List<Inscripciones>();
            Listado = InscripcionBLL.GetList(p => true);
            Assert.AreEqual(Listado, Listado);
        }
    }
}