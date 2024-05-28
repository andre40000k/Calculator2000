using Calculator.Interfaces;

namespace Calculator.MathOperation
{
    internal class Degree : ICalculate
    {
        public double Calculate(double num1, double num2)
        {
            if (num2 == 0)
                throw new DivideByZeroException();
            return num1 / num2;
        }
    }
}