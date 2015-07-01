using DigoFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DigoFrameworkTest
{
    [TestClass]
    public class UtilsTest
    {
        [TestMethod]
        public void getBooStrAlfanumericoTest()
        {
            Assert.IsTrue(Utils.getBooStrAlfanumerico("aaa"));
            Assert.IsTrue(Utils.getBooStrAlfanumerico("111"));
            Assert.IsFalse(Utils.getBooStrAlfanumerico("aaa111_"));
        }

        [TestMethod]
        public void getStrCampoFixoTest()
        {
            Assert.AreEqual("a         ", Utils.getStrCampoFixo("a", 10, ' '));
            Assert.AreEqual("0000000001", Utils.getStrCampoFixo("1", 10, '0'));
        }

        [TestMethod]
        public void getStrMd5Test()
        {
            Assert.AreEqual("B61D71247E866936F6F0FCDB474B4CFA", Utils.getStrMd5("kjaksldlfjiaos4ljdfa"));
            Assert.AreEqual("19834AC436BA3B460C63FA257F0F21C2", Utils.getStrMd5("falkr2dhfkaldqjfafde"));
            Assert.AreEqual("47D70F1E10B5CAC767FE4D2E4D2EDD9D", Utils.getStrMd5("kjfaiosjldfia3jsadqf"));
        }

        [TestMethod]
        public void getStrPrimeiraMaiusculaTest()
        {
            Assert.AreEqual("Primeira letra maiúscula", Utils.getStrPrimeiraMaiuscula("primeira letra maiúscula"));
            Assert.AreEqual("Primeira letra maiúscula", Utils.getStrPrimeiraMaiuscula("PRIMEIRA LETRA MAIÚSCULA"));
        }

        [TestMethod]
        public void getStrTituloTest()
        {
            Assert.AreEqual("Título", Utils.getStrTitulo("título"));
            Assert.AreEqual("Título", Utils.getStrTitulo("TÍTULO"));
            Assert.AreEqual("Título Composto", Utils.getStrTitulo("TÍTULO composto"));
        }
    }
}