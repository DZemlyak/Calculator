using System;

namespace Calculator.Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var calculator = new Calculator();
            string op, arg1, arg2;
            Console.WriteLine("***** Calculator *****");
            do {
                Console.Write("\nВыберите операцию:\n" +
                              "1.Сложение\n" +
                              "2.Вычитание\n" +
                              "3.Умножение\n" +
                              "4.Деление\n" +
                              "5.Выход\n\n");
                Console.Write("Операция: ");
                op = Console.ReadLine();
                op = op.Trim();
                if (string.IsNullOrEmpty(op) || op == "5") continue;
                
                Console.Write("Первый аргумент: ");
                arg1 = Console.ReadLine();
                if (arg1 != null) arg1 = arg1.Trim();
                Console.Write("Второй аргумент: ");
                arg2 = Console.ReadLine();
                if (arg2 != null) arg2 = arg2.Trim();

                try {
                    Console.WriteLine("Результат: {0}\n",calculator.Calculate(op, arg1, arg2).Value);
                }
                catch (Exception ex) {
                    Console.WriteLine(ex.Message);
                }
            } while (op != "5");
        }
    }
}
