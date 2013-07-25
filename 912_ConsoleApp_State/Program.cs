using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _912_ConsoleApp_State
{
    class Pen
    {
        enum Color
        {
            Red, Blue
        }

        private Color _usedColor;

        public void UseNext()
        {
            _usedColor = (_usedColor == Color.Blue) ? Color.Red : Color.Blue;
        }

        public void ShowNextColor()
        {
            switch (_usedColor)
            {
                case Color.Blue:
                    Console.WriteLine("Red");
                    break;
                case Color.Red:
                    Console.WriteLine("Blue");
                    break;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //simple///
        }
    }
}
