using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntidadesAbstracta;
using EntidadesInstanciables;
using EntidadesExcepciones;
using System;

namespace TestUnitarios
{
    [TestClass]
    public class TestUnitario
    {
        [TestMethod]
        public void AlumnoRepetido()
        {
            try
            {
                Universidad universidad = new Universidad();

                Alumno alumno1 = new Alumno(1, "Ivan", "Lopez", "33222111", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
                Alumno alumno2 = new Alumno(2, "Juan", "Casas", "33222111", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);

                universidad += alumno1;
                universidad += alumno2;

                Assert.Fail("Alumno Repetido.");
            }
            catch (Exception error)
            {
                Assert.IsInstanceOfType(error, typeof(AlumnoRepetidoException));
            }
        }

        [TestMethod]
        public void NacionalidadInvalida()
        {
            try
            {
                Alumno alumno = new Alumno(1, "Juan", "Casas", "11222333", Persona.ENacionalidad.Extranjero, Universidad.EClases.Laboratorio);
                Assert.Fail("La nacionalidad no condice con el DNI.");
            }
            catch (Exception error)
            {
                Assert.IsInstanceOfType(error, typeof(NacionalidadInvalidaException));
            }
        }

        [TestMethod]
        public void IsNull()
        {
            Universidad universidad = new Universidad();
            Assert.IsNotNull(universidad.Alumnos);
        }
   
        [TestMethod]
        public void DniValido()
        {
            Alumno alumno = new Alumno(1, "Juan", "Casas", "11222333", Persona.ENacionalidad.Extranjero, Universidad.EClases.Laboratorio);
            Assert.AreEqual(alumno.DNI, 11222333);
        }
    }
}
