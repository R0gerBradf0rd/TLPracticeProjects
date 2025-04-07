namespace Calculator.Straregies
{
    internal class Divide : ICalculate
    {
        private readonly double _num1;
        private readonly double _num2;
        public Divide( double num1, double num2 )
        {
            _num1 = num1;
            _num2 = num2;
        }
        public double Calculate()
        {
            return _num1 / _num2;
        }
    }
}
