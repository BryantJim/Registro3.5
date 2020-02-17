using Microsoft.VisualStudio.TestTools.UnitTesting;
using Registro3._5.Entidades;
using System;
using System.Collections.Generic;

namespace Registro3._5.BLL.Tests
{
    [TestClass()]
    public class EstudiantesBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            bool paso;
            Estudiantes estudiante = new Estudiantes();
            estudiante.EstudianteId = 0;
            estudiante.Nombre = " Anthony Brian ";
            estudiante.Telefono = " 8294587954 ";
            estudiante.Cedula = " 4021285644 ";
            estudiante.Direccion = " Duarte ";
            estudiante.FechaNacimiento = DateTime.Now;
            paso = EstudiantesBLL.Guardar(estudiante);

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            bool paso;
            Estudiantes estudiante = new Estudiantes();
            estudiante.EstudianteId = 1;
            estudiante.Nombre = " Nefelty";
            estudiante.Telefono = " 8296351988";
            estudiante.Cedula = " 058064999 ";
            estudiante.Direccion = " VVilla Riva ";
            estudiante.FechaNacimiento = DateTime.Now;
            paso = EstudiantesBLL.Modificar(estudiante);

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso;
            paso = EstudiantesBLL.Eliminar(1);

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            Estudiantes personas = new Estudiantes();
            personas = EstudiantesBLL.Buscar(1);

            Assert.AreEqual(personas, personas);
        }

        [TestMethod()]
        public void GetListTest()
        {
            var listado = new List<Estudiantes>();
            listado = EstudiantesBLL.GetList(p => true);
            Assert.AreEqual(listado, listado);
        }
    }
}