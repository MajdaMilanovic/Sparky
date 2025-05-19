using NUnit.Framework;
using NUnit.Framework.Legacy;
using Sparky;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkyUnitTest


{
    [TestFixture]
    public class CalculatorNUnitTests
    {

        [Test]
        public void AddNumbers_InputTwoInt_GetCorrectAddition()
        {
            //Arrange
            Calculator calc = new();


            //Act
            int result = calc.AddNumber(10, 20);

            //Assert
            ClassicAssert.AreEqual(30, result);
        }

        [Test]
        public void IsOddChecher_InputEvenNumber_ReturnFalse()
        {
            Calculator calc = new();
            bool isOdd = calc.IsOddNumber(10);

            ClassicAssert.That(isOdd, Is.EqualTo(false));   
            //ClassicAssert.IsTrue(isOdd);
        }

        [Test]
        [TestCase(11)]
        [TestCase(13)]
        public void IsOddChecher_InputOddNumber_ReturnTrue(int a)
        {
            Calculator calc = new();
            bool isOdd = calc.IsOddNumber(a);

            ClassicAssert.That(isOdd, Is.EqualTo(true));
            ClassicAssert.IsTrue(isOdd);
        }


        [Test]
        [TestCase(10, ExpectedResult = false)]
        [TestCase(11, ExpectedResult = true)]
        public bool IsOddChecker_InputNumber_ReturnTrueIfOdd(int a)
        {
            Calculator calc = new();
            return calc.IsOddNumber(a);
        }


        [Test]
        [TestCase(5.4, 10.5)]
        [TestCase(5.43, 10.53)]
        [TestCase(5.49, 10.59)]
            
        public void AddNumbersDouble_InputTwoDouble_GetCorrectAddition(double a, double b)
        {
            //Arrange
            Calculator calc = new();


            //Act
            double result = calc.AddNumbersDouble(a, b);

            //Assert
            ClassicAssert.AreEqual(15.9, result, 1);
        }

        [Test]
        public void OddRanger_InputMinAndMaxRange_ReturnsValidOddNumberRange()
        {
            Calculator calc = new();
            List<int> expectedOddRange = [5, 7, 9];

            List<int> result = calc.GetOddRange(5, 10);


            Assert.That(result, Is.EquivalentTo(expectedOddRange));
            ClassicAssert.AreEqual(expectedOddRange, result);
            ClassicAssert.Contains(7, result);
            Assert.That(result, Does.Contain(7));
            Assert.That(result, Is.Not.Empty);
            Assert.That(result.Count, Is.EqualTo(3));
            Assert.That(result, Has.No.Member(6));
            Assert.That(result, Is.Unique);
        }
    }
}
