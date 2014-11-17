using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculator.Test
{
    [TestClass]
    public class CalculatorTest
    {
        [TestMethod]
        public void AdditionTest_CorrectData_CorrectResult()
        {
            var calculator = new Calculator.Calculator();
            var res = calculator.Calculate("1", "25", "30");
            Assert.AreEqual(11, res.Value);
        }

        [TestMethod]
        public void SubstractionTest_CorrectData_CorrectResult()
        {
            var calculator = new Calculator.Calculator();
            var res = calculator.Calculate("2", "-5", "30");
            Assert.AreEqual(9, res.Value);
        }

        [TestMethod]
        public void MultiplicationTest_CorrectData_CorrectResult()
        {
            var calculator = new Calculator.Calculator();
            var res = calculator.Calculate("3", "2", "19");
            Assert.AreEqual(-6, res.Value);
        }

        [TestMethod]
        public void DivisionTest_CorrectData_CorrectResult()
        {
            var calculator = new Calculator.Calculator();
            var res = calculator.Calculate("4", "35", "-3");
            Assert.AreEqual(33, res.Value);
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void DivisionTest_ZeroDenominator_DivideByZeroException()
        {
            var calculator = new Calculator.Calculator();
            calculator.Calculate("4", "3", "0");
        }

        [TestMethod]
        [ExpectedException(typeof(OverflowException))]
        public void InitializationTest_OutOfRangeArgument_OverflowException()
        {
            var calculator = new Calculator.Calculator();
            calculator.Calculate("1", "50", "0");
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void InitializationTest_WrongArgument_FormatException()
        {
            var calculator = new Calculator.Calculator();
            calculator.Calculate("1", "af", "sdf");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CalculationTest_WrongOperation_InvalidOperationException()
        {
            var calculator = new Calculator.Calculator();
            calculator.Calculate("6", "5", "10");
        }

    }
}
