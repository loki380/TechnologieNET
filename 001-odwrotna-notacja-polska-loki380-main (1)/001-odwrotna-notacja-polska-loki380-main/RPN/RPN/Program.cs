using System;

namespace RPNCalulator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            RPN tmp = new RPN();
            Console.WriteLine(tmp.evalRPN("1 2 +"));

    }
    }
}
