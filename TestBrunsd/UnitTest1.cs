using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProyectoFinal;

namespace TestBrunsd
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Comprobar

            //Arrange

            var help = new Helper();
            string sv = @"(localdb)\BrunsdDB1";
            string dt = "BrunsdDB1";

            //Act

            help.getConnectionDB(sv,dt);

            //Assert
            StringAssert.Contains(sv, dt);
        }
    }
}
