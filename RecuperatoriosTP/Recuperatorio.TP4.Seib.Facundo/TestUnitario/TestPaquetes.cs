using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
using System;

namespace TestUnitario
{
    [TestClass]
    public class TestPaquetes
    {
        [TestMethod]
        public void TestPaqueteRepetido()
        {
            try
            {
                Correo correo = new Correo();

                Paquete paquete = new Paquete("Calle Falsa 123", "555-666-0800");

                correo += paquete;
                correo += paquete;

                Assert.Fail("Paquete ya agregado. Tracking ID's concuerdan");
            }
            catch (Exception error)
            {
                Assert.IsInstanceOfType(error, typeof(TrackingIdRepetidoException));
            }
        }
    }
}
