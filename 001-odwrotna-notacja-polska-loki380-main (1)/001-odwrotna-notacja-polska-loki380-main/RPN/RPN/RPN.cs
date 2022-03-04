using System;
using System.Collections.Generic;
using System.Text;

namespace RPNCalulator
{
    public class RPN
    {
        private Stack<int> _stack;
        public int evalRPN(String input)
        {
            _stack = new Stack<int>();
            var inputAfterSplit = input.Split(' ');
            foreach (var sign in inputAfterSplit)
            {
                if (IsNumber(sign)){
                    _stack.Push(Int32.Parse(sign));
                }
                else if (IsOperator(sign))
                {
                    var a = _stack.Pop();
                    if (sign == "!"){
                        _stack.Push(silnia(a));
                    }
                    else if(sign == "abs")
                    {
                        _stack.Push(absolute(a));
                    }
                    else{
                        var b = _stack.Pop();
                        if (sign == "+") _stack.Push(a + b);
                        else if (sign == "-") _stack.Push(b - a);
                        else if (sign == "*") _stack.Push(a * b);
                        else if (sign == "/")
                        {
                            if(b == 0)
                            {
                                throw new DivideByZeroException();
                            }
                            else
                            {
                                _stack.Push(b / a);
                            }
                        }
                        else if (sign == "^") _stack.Push((int)Math.Pow(b, a));
                    }
                }
                else throw new InvalidOperationException();
            }

            var result = _stack.Pop();
            if (_stack.IsEmpty)
            {
                return result;
            }
            throw new InvalidOperationException();

        }
        private bool IsNumber(String sign)
        {
            return Int32.TryParse(sign, out _);
        }
        private bool IsOperator(String sign)
        {
            if (sign == "+" || sign == "-" || sign == "*" || sign == "/" || sign == "!" || sign == "^" || sign == "abs") return true;
            else return false;
        }
        private static int silnia(int i)
        {
            if (i < 1)
                return 1;
            else
                return i * silnia(i - 1);
        }
        private int absolute(int n) => Math.Abs(n);
    }
}
