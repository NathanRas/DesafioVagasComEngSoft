using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DesafioVagasComEngSoft;
using System.Xml.Linq;

namespace DesafioVagasComTestes
{
    [TestClass]
    public class LogicTest
    {
        private Logic logic;

        public LogicTest()
        {
            this.logic = new Logic();
        }

        [TestMethod]
        public void TestCalculoDeN()
        {
            int nivelVaga = 3;
            int nivelPessoa = 2;
            var expected = 75;

            var actual = logic.CalculOfN(nivelVaga, nivelPessoa);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestCalculoDeD()
        {

            int minDistance = 10;
            var expected = 75;
            var actual = logic.CalculOfD(minDistance);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestCalculoDeMinDistance()
        {

            var start = "A";
            var target = "E";
            var expected = 16;
            var actual = logic.MinimumDistance(start, target);

            Assert.AreEqual(expected, actual);
        }

    }
}
