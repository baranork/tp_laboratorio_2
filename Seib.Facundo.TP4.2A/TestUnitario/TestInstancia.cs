using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace TestUnitario
{
    [TestClass]
    public class TestInstancia
    {
        [TestMethod]
        public void TestMethod1()
        {
            Correo correo = new Correo();
            Assert.IsNotNull(correo.Paquetes);
        }
    }
}
