using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _913_ConsoleApp_Strategy
{
    abstract class Strategy
    {
        public abstract int Calculate(int a, int b);
    }

    class AddStrategy : Strategy
    {
        public override int Calculate(int a, int b)
        {
            return a + b;
        }
    }

    class SubstractStrategy : Strategy
    {
        public override int Calculate(int a, int b)
        {
            return a - b;
        }
    }

    class MathWrap
    {
        public int a { get; set; }
        public int b { get; set; }
        private Strategy _strategy;
        public void SetStrategy(Strategy obj)
        {
            _strategy = obj;
        }
        public int Calculate()
        {
            return _strategy.Calculate(a, b);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("STRATEGY");
            Console.WriteLine("STRATEGY");
            var q = new MathWrap();
            q.a = 10;
            q.b = 3;
            q.SetStrategy(new SubstractStrategy());
            Console.WriteLine("subs res: {0}", q.Calculate());
            q.SetStrategy(new AddStrategy());
            Console.WriteLine("add res: {0}", q.Calculate());
            Console.ReadKey();
        }
    }
}
