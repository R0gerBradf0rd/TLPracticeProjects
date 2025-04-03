using Calculator.Straregies;

double number1 = 0;     // Doubl а не Int, т.к. может быть не челочисленный ответ
double number2 = 0;

Console.Write("Enter the first value: ");
string value1 = Console.ReadLine();
if (!CheckData(value1, out number1)) return;        

Console.Write("Enter the operation: ");
string operation = Console.ReadLine();
if (!CheckOperation(operation)) return;

Console.Write("Enter the second value: ");
string value2 = Console.ReadLine();
if (!CheckData(value2, out number2)) return;
if ((operation == "/") && (number2 == 0)) 
{
    Console.WriteLine("Error! You can't divide by 0!");
    return;
}

ICalculate calculator = CalculatorFactory.Create(number1, operation, number2);
double result = calculator.Calculate();
Console.WriteLine($"{number1} {operation} {number2} = {result}");

bool CheckData(string value, out double number)     // Проверка на кореектность данных
{
    if (double.TryParse(value, out number)) return true;
    else
    {
        Console.WriteLine("Error! Incorrect value!");
        return false; 
    }
}
bool CheckOperation(string operation)       // Проверка выбора нужной операции
{
    switch(operation)
    {
        case "+":
            return true;
        case "-": 
            return true;
        case "*": 
            return true;
        case "/":
            return true;
        default:
            Console.WriteLine($"Operation \"{operation}\" can't be used in this Calculator!(((");
            return false;
    }
}