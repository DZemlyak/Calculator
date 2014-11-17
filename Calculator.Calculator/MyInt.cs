using System;

namespace Calculator.Calculator
{
    public struct MyInt
    {
        private const int Max_Value = 36;
        private const int Min_Value = -7;
        private int _value;

        public int Value {
            get { return _value; }
            set {
                if (value > Max_Value || value < Min_Value) 
                    throw new OverflowException(
                        string.Format("Аргументы вне допустимого диапазона. Диапазон от {0} до {1}.", Min_Value, Max_Value));
                _value = value;
            }
        }

        public static MyInt operator +(MyInt x, MyInt y) {
            var d = new MyInt {_value = x._value + y._value};
            if (d._value > Max_Value || d._value < Min_Value)
                Overflow(ref d);
            return d;
        }

        public static MyInt operator -(MyInt x, MyInt y) {
            var d = new MyInt { _value = x._value - y._value };
            if (d._value > Max_Value || d._value < Min_Value)
                Overflow(ref d);
            return d;
        }

        public static MyInt operator *(MyInt x, MyInt y) {
            var d = new MyInt { _value = x._value * y._value };
            if (d._value > Max_Value || d._value < Min_Value)
                Overflow(ref d);
            return d;
        }

        public static MyInt operator /(MyInt x, MyInt y) {
            var d = new MyInt { _value = x._value / y._value };
            if (d._value > Max_Value || d._value < Min_Value)
                Overflow(ref d);
            return d;
        }

        private static void Overflow(ref MyInt digit)
        {
            if (digit._value >= Min_Value && digit._value <= Max_Value)
                return;
            if (digit._value > Max_Value) {
                digit._value = Min_Value + digit._value - Max_Value - 1;
                Overflow(ref digit);
            }
            if (digit._value < Min_Value) {
                digit._value = digit._value + (Math.Abs(Min_Value) + Math.Abs(Max_Value)) + 1;
                Overflow(ref digit);
            }
        }
    }
}
