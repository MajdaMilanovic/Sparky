﻿using Sparky;
using SparkyXUnitTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SparkyXUnitTest


{
  
    public class CalculatorXUnitTests
    {

        [Fact]
        public void AddNumbers_InputTwoInt_GetCorrectAddition()
        {
            //Arrange
            Calculator calc = new();

            //Act
            int result = calc.AddNumber(10, 20);

            //Assert
            Assert.Equal(30, result);
        }

        [Fact]
        public void IsOddChecher_InputEvenNumber_ReturnFalse()
        {
            Calculator calc = new();
            bool isOdd = calc.IsOddNumber(10);
            Assert.False(isOdd);
        }

        [Theory]
        [InlineData(11)]
        [InlineData(13)]
        public void IsOddChecher_InputOddNumber_ReturnTrue(int a)
        {
            Calculator calc = new();
            bool isOdd = calc.IsOddNumber(a);
            Assert.True(isOdd);
        }


        [Theory]
        [InlineData(10, false)]
        [InlineData(11, true)]
        public void IsOddChecker_InputNumber_ReturnTrueIfOdd(int a, bool expectedResult)
        {
            Calculator calc = new();
            var result = calc.IsOddNumber(a);
            Assert.Equal(expectedResult, result);   
        }


        [Theory]
        [InlineData(5.4, 10.5)]
        //[InlineData(5.43, 10.53)]
        //[InlineData(5.49, 10.59)]

        public void AddNumbersDouble_InputTwoDouble_GetCorrectAddition(double a, double b)
        {
            //Arrange
            Calculator calc = new();


            //Act
            double result = calc.AddNumbersDouble(a, b);

            //Assert
            Assert.Equal(15.9, result, 2);
        }

        [Fact]
        public void OddRanger_InputMinAndMaxRange_ReturnsValidOddNumberRange()
        {
            Calculator calc = new();
            List<int> expectedOddRange = [5, 7, 9];

            List<int> result = calc.GetOddRange(5, 10);


            Assert.Equal(expectedOddRange, result);
            Assert.Contains(7, result);
            Assert.NotEmpty(result);
            Assert.Equal(3, result.Count);
            Assert.DoesNotContain(6, result);
            Assert.Equal(result.OrderBy(u => u), result);
            //Assert.That(result, Is.Unique);
        }
    }
}
