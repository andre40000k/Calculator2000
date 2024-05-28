using Calculator.Interfaces;

namespace Calculator.MathOperation
{
    internal class Multiply : ICalculate
    {
        public double Calculate(double num1, double num2)
        {
            return num1 * num2;
        }
    }
}
