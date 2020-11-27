using NUnit.Framework;

namespace TekTutor
{
    public class RPNCalculatorTest
    {
        private RPNCalculator rpnCalculator;


        [SetUp]
        public void init()
        {
            rpnCalculator = new  ();

        }

        [TearDown]
        public void cleanUp()
        {
            rpnCalculator = null;
        }

        [Test]
        public void TestSimpleAddition()
        {

            double actualResult = rpnCalculator.compute("10 15 +");
            double expectedResult = 25.0;
            Assert.AreEqual(expectedResult, actualResult);

            actualResult = rpnCalculator.compute("100 15 +");
            expectedResult = 115.0;
            Assert.AreEqual(expectedResult, actualResult);

        }

        [Test]
        public void TestSimpleSubtraction()
        {

            double actualResult = rpnCalculator.compute("100 15 -");
            double expectedResult = 85.0;
            Assert.AreEqual(expectedResult, actualResult);

            actualResult = rpnCalculator.compute("100 10 -");
            expectedResult = 90.0;
            Assert.AreEqual(expectedResult, actualResult);

        }

        [Test]
        public void TestSimpleMultiplication()
        {

            double actualResult = rpnCalculator.compute("100 15 *");
            double expectedResult = 1500.0;
            Assert.AreEqual(expectedResult, actualResult);

            actualResult = rpnCalculator.compute("100 10 *");
            expectedResult = 1000.0;
            Assert.AreEqual(expectedResult, actualResult);

        }

        [Test]
        public void TestSimpleDivision()
        {

            double actualResult = rpnCalculator.compute("100 10 /");
            double expectedResult = 10.0;
            Assert.AreEqual(expectedResult, actualResult);

            actualResult = rpnCalculator.compute("1000 10 /");
            expectedResult = 100.0;
            Assert.AreEqual(expectedResult, actualResult);

        }

        [Test]
        public void TestComplexRPNExpression()
        {

            double actualResult = rpnCalculator.compute("10 5 * 100 20 / -");
            double expectedResult = 45.0;
            Assert.AreEqual(expectedResult, actualResult);

        }

    }
}