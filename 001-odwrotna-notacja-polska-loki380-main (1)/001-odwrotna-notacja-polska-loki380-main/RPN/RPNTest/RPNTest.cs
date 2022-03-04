using NUnit.Framework;
using RPNCalulator;
using System;

namespace RPNTest
{
    public class RPNTests{
		private RPN _sut;
		[SetUp]
		public void Setup()
		{
			_sut = new RPN();
		}
		[Test]
		public void CheckIfTestWorks()
		{
			Assert.Pass();
		}

		[Test]
		public void CheckIfCanCreateSut()
		{
			Assert.That(_sut, Is.Not.Null);
		}

		[Test]
		public void SingleDigitOneInputOneReturn()
		{
			var result = _sut.evalRPN("1");

			Assert.That(result, Is.EqualTo(1));

		}
		[Test]
		public void SingleDigitOtherThenOneInputNumberReturn()
		{
			var result = _sut.evalRPN("2");

			Assert.That(result, Is.EqualTo(2));

		}
		[Test]
		public void TwoDigitsNumberInputNumberReturn()
		{
			var result = _sut.evalRPN("12");

			Assert.That(result, Is.EqualTo(12));

		}
		[Test]
		public void TwoNumbersGivenWithoutOperator_ThrowsExcepton()
		{
			Assert.Throws<InvalidOperationException>(() => _sut.evalRPN("1 2"));

		}
		[Test]
		public void OperatorPlus_AddingTwoNumbers_ReturnCorrectResult()
		{
			var result = _sut.evalRPN("1 2 +");

			Assert.That(result, Is.EqualTo(3));
		}
		[Test]
		public void OperatorTimes_AddingTwoNumbers_ReturnCorrectResult()
		{
			var result = _sut.evalRPN("2 2 *");

			Assert.That(result, Is.EqualTo(4));
		}
		[Test]
		public void OperatorMinus_SubstractingTwoNumbers_ReturnCorrectResult()
		{
			var result = _sut.evalRPN("2 1 -");

			Assert.That(result, Is.EqualTo(1));
		}
		[Test]
		public void OperatorDivide_SubstractingTwoNumbers_ReturnCorrectResult()
		{
			var result = _sut.evalRPN("2 1 /");

			Assert.That(result, Is.EqualTo(2));
		}
		[Test]
		public void ComplexExpression()
		{
			var result = _sut.evalRPN("15 7 1 1 + - / 3 * 2 1 1 + + -");

			Assert.That(result, Is.EqualTo(5));
		}
		[Test]
        public void EmptyInput_ThrowsExcepton()
        {
            Assert.Throws<InvalidOperationException>(() => _sut.evalRPN(""));
        }
		[Test]
		public void SingleDigitFactorial()
		{
			var result = _sut.evalRPN("3 !");

			Assert.That(result, Is.EqualTo(6));
		}
		[Test]
		public void SimplePow()
		{
			var result = _sut.evalRPN("2 3 ^");

			Assert.That(result, Is.EqualTo(8));
		}
		[Test]
		public void SimpleDigitPowZero()
		{
			var result = _sut.evalRPN("2 0 ^");

			Assert.That(result, Is.EqualTo(1));
		}
		[Test]
		public void TwoDigitNumbersFactorial()
		{
			var result = _sut.evalRPN("10 !");

			Assert.That(result, Is.EqualTo(3628800));
		}
		[Test]
		public void NumberAndOperatorWithoutSpace()
		{
			Assert.Throws<InvalidOperationException>(() => _sut.evalRPN("2 3+"));
		}
		[Test]
		public void ZeroAfterFactorial()
		{
			var result = _sut.evalRPN("0 !");

			Assert.That(result, Is.EqualTo(1));
		}
		[Test]
		public void SimpleAbsolute()
		{
			var result = _sut.evalRPN("-5 abs");

			Assert.That(result, Is.EqualTo(5));
		}
		[Test]
		public void DivideByZero()
		{
			Assert.Throws<DivideByZeroException>(() => _sut.evalRPN("0 2 /"));
		}
		[Test]
		public void TooLittleNumbers()
		{
			Assert.Throws<InvalidOperationException>(() => _sut.evalRPN("2 +"));
		}
		[Test]
		public void TooMuchNumbers()
		{
			Assert.Throws<InvalidOperationException>(() => _sut.evalRPN("2 2 2 +"));
		}
		[Test]
		public void InputOnlyOperator()
		{
			Assert.Throws<InvalidOperationException>(() => _sut.evalRPN("+"));
		}
	}
}