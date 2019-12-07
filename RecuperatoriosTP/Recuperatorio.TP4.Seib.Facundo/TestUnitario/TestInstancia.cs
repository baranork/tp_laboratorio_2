<<<<<<< HEAD
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace TestUnitario
{
    [TestClass]
    public class TestInstancia
    {
        [TestMethod]
        public void TestCorreoIsNull()
        {
            Correo correo = new Correo();
            Assert.IsNotNull(correo.Paquetes);
        }
    }
}
=======
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace TestUnitario
{
    [TestClass]
    public class TestInstancia
    {
        [TestMethod]
        public void TestCorreoIsNull()
        {
            Correo correo = new Correo();
            Assert.IsNotNull(correo.Paquetes);
        }
    }
}
>>>>>>> ee9bbf0cb6f34fe2b849ef010570f783045a7e22
