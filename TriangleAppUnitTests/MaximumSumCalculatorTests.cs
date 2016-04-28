using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TriangleApp;

namespace TriangleAppUnitTests
{
    [TestClass]
    public class MaximumSumCalculatorTests
    {
        [TestMethod]
        public void Calculate_ShouldReturnCorrectMaxSum_WhenEachNextLineIsLongerThanPreviousOnOneElement()
        {
            //Arrange
            var triangle = new List<List<int>>
            {
                new List<int>() {3},
                new List<int>() {7, 4},
                new List<int>() {2, 4, 6},
                new List<int>() {8, 5, 9, 3}
            };
            const int expectedMaxSum = 23;
            var calculator = new MaximumSumCalculator(triangle);

            //Act
            var actualMaxSum = calculator.Calculate();

            //Assert
            Assert.AreEqual(expectedMaxSum, actualMaxSum);
        }

        [TestMethod]
        public void Calculate_ShouldReturnCorrectMaxSum_WhenTriangleContainsNegativeNumbers()
        {
            //Arrange
            var triangle = new List<List<int>>
            {
                new List<int>() {-3},
                new List<int>() {7, 4},
                new List<int>() {-2, -4, -6}
            };
            const int expectedMaxSum = 2;
            var calculator = new MaximumSumCalculator(triangle);

            //Act
            var actualMaxSum = calculator.Calculate();

            //Assert
            Assert.AreEqual(expectedMaxSum, actualMaxSum);
        }

        [TestMethod]
        public void Calculate_ShouldReturnCorrectMaxSum_WhenItIsOnlyOneNumber()
        {
            //Arrange
            var triangle = new List<List<int>> {new List<int>() {3}};
            const int expectedMaxSum = 3;
            var calculator = new MaximumSumCalculator(triangle);

            //Act
            var actualMaxSum = calculator.Calculate();

            //Assert
            Assert.AreEqual(expectedMaxSum, actualMaxSum);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Calculate_ShouldThrowIndexOutOfRangeException_WhenEachNextLineIsNotLongerThanPreviousOnOneElement()
        {
            //Arrange
            var triangle = new List<List<int>>
            {
                new List<int>() {3},
                new List<int>() {7, 4},
                new List<int>() {2, 4, 6},
                new List<int>() {8, 5, 9}
            };
            var calculator = new MaximumSumCalculator(triangle);

            //Act
            var actualMaxSum = calculator.Calculate();
        }
    }
}
