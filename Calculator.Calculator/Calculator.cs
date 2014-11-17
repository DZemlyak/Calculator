using System;
using System.Collections.Generic;

namespace Calculator.Calculator
{
    public class Calculator
    {
        private delegate MyInt Operation(MyInt x, MyInt y);
        private readonly Dictionary<string, Operation> _operations;

        public Calculator()
        {
            _operations = new Dictionary<string, Operation>()
            {
                { "1", (x, y) => x + y },
                { "2", (x, y) => x - y },
                { "3", (x, y) => x * y },
                { "4", (x, y) => x / y }
            };
        }

        public MyInt Calculate(string op, string arg1, string arg2)
        {
            if (!_operations.ContainsKey(op))
                throw new InvalidOperationException(string.Format("Нет такой операции: \"{0}\"", op));
            int temp1, temp2;
            MyInt x = new MyInt(), y = new MyInt();

            if (int.TryParse(arg1, out temp1) && int.TryParse(arg2, out temp2)) {
                x = new MyInt() { Value = temp1 };
                y = new MyInt() { Value = temp2 };
            }
            else
                throw new FormatException();
            return _operations[op](x, y);
        }
    }
}
