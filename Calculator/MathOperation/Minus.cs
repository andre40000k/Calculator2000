using Calculator.Interfaces;

namespace Calculator.MathOperation
{
    internal class Minus : ICalculate
    {
        public double Calculate(double num1, double num2)
        {
            return num1 - num2;
        }
    }
}
