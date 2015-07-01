using DigoFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DigoFrameworkTest
{
    [TestClass]
    public class UtilsTest
    {
        [TestMethod]
        public void getBooStrAlfanumerico()
        {
            Assert.AreEqual(true, Utils.getBooStrAlfanumerico("aaa"));
            Assert.AreEqual(Utils.getBooStrAlfanumerico("111"), true);
            Assert.AreEqual(Utils.getBooStrAlfanumerico("aaa111_"), false);
        }

        [TestMethod]
        public void getStrCampoFixo()
        {
            Assert.AreEqual("a         ", Utils.getStrCampoFixo("a", 10, ' '));
            Assert.AreEqual("0000000001", Utils.getStrCampoFixo("1", 10, '0'));
        }

        [TestMethod]
        public void getStrMd5()
        {
            Assert.AreEqual(Utils.getStrMd5("kjaksldlfjiaos4ljdfa"), "B61D71247E866936F6F0FCDB474B4CFA");
            Assert.AreEqual(Utils.getStrMd5("falkr2dhfkaldqjfafde"), "19834AC436BA3B460C63FA257F0F21C2");
            Assert.AreEqual(Utils.getStrMd5("kjfaiosjldfia3jsadqf"), "47D70F1E10B5CAC767FE4D2E4D2EDD9D");
        }

        [TestMethod]
        public void getStrPrimeiraMaiuscula()
        {
            Assert.AreEqual(Utils.getStrPrimeiraMaiuscula("primeira letra maiúscula"), "Primeira letra maiúscula");
            Assert.AreEqual(Utils.getStrPrimeiraMaiuscula("PRIMEIRA LETRA MAIÚSCULA"), "Primeira letra maiúscula");
        }

        [TestMethod]
        public void getStrTitulo()
        {
            Assert.AreEqual(Utils.getStrTitulo("título"), "Título");
            Assert.AreEqual(Utils.getStrTitulo("TÍTULO"), "Título");
            Assert.AreEqual(Utils.getStrTitulo("TÍTULO composto"), "Título Composto");
        }
    }
}