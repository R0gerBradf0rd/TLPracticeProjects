using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Straregies
{
    public static class CalculatorFactory
    {
        public static ICalculate Create(double number1, string operation, double number2)
        {
            return operation switch
            {
                "+" => new Add(number1, number2),
                "-" => new Substract(number1, number2),
                "*" => new Multilpy(number1, number2),
                "/" => new Divide(number1, number2),
            };
        }
    }
}
