using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApp67;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            // target, ez a példány, amit tesztelek
            AlmaPiac target = new AlmaPiac();
            // fixált bemenetek
            double almaEgységÁr = 200.0;
            // expected
            double expected = almaEgységÁr;
            // actual
            target.SetAlmaEgységÁr(almaEgységÁr);
            double actual = target.AlmaÁr(1.0);
            // ennek a kettőnek ugyannak kell lennie
            Assert.AreEqual(expected, actual, 0.0001);
        }
        [TestMethod]
        public void AlmaPiacTest2()
        {
            AlmaPiac target = new AlmaPiac();
            double almaEgységÁr = 200.0;
            double expected = 0.0;
            target.SetAlmaEgységÁr(almaEgységÁr);
            double actual = target.AlmaÁr(0.0);
            Assert.AreEqual(expected, actual, 0.0001);
        }
        [TestMethod]
        public void AlmaPiacTest3()
        {
            AlmaPiac target = new AlmaPiac();
            double almaEgységÁr = 500.0;
            double vásároltMennyiség = 1.0;
            double expected = almaEgységÁr * vásároltMennyiség;
            target.SetAlmaEgységÁr(almaEgységÁr);
            double actual = target.AlmaÁr(vásároltMennyiség);
            Assert.AreEqual(expected, actual, 0.0001);
        }
        [TestMethod]
        [ExpectedException(typeof(IllegálisParam))]
        public void AlmaPiacTest4()
        {
            AlmaPiac target = new AlmaPiac();
            double almaEgységÁr = 500.0;
            double vásároltMennyiség = -1.0;
            target.SetAlmaEgységÁr(almaEgységÁr);
            double actual = target.AlmaÁr(vásároltMennyiség);
        }
        [TestMethod]
        [ExpectedException(typeof(IllegálisParam))]
        public void AlmaPiacTest5()
        {
            AlmaPiac target = new AlmaPiac();
            double almaEgységÁr = -500.0;
            target.SetAlmaEgységÁr(almaEgységÁr);
        }
        [TestMethod]
        public void AlmaPiacTest6()
        {
            AlmaPiac target = new AlmaPiac();
            double súlyHatár = 5.0;
            double kedvezmény = 0.1;
            target.AddKedvezmény(
                new Legalább1SúlyKedvezmény(súlyHatár, kedvezmény));
            double almaEgységÁr = 500.0;
            double vásároltMennyiség = 10.0;
            double expected = 
                almaEgységÁr * vásároltMennyiség * (1.0-kedvezmény);
            target.SetAlmaEgységÁr(almaEgységÁr);
            double actual = target.AlmaÁr(vásároltMennyiség);
            Assert.AreEqual(expected, actual, 0.0001);
        }
        [TestMethod]
        public void AlmaPiacTest7()
        {
            AlmaPiac target = new AlmaPiac();
            double súlyHatár1 = 3.0;
            double kedvezmény1 = 0.1;
            double súlyHatár2 = 10.0;
            double kedvezmény2 = 0.15;
            target.AddKedvezmény(
                new Legalább2SúlyKedvezmény(súlyHatár1, kedvezmény1,
                                            súlyHatár2, kedvezmény2));
            double almaEgységÁr = 500.0;
            double vásároltMennyiség = 10.0;
            double expected =
                almaEgységÁr * vásároltMennyiség * (1.0 - kedvezmény2);
            target.SetAlmaEgységÁr(almaEgységÁr);
            double actual = target.AlmaÁr(vásároltMennyiség);
            Assert.AreEqual(expected, actual, 0.0001);
        }
    }
}
