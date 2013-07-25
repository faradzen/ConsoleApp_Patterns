using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_Patterns
{
    interface IUnitInvoice
    {
        void Print();
    }

    class UnitMarksman : IUnitInvoice
    {
        public void Print()
        {
            Console.WriteLine("Soldier print()");
        }
    }

    class UnitSwordsman : IUnitInvoice
    {
        public void Print()
        {
            Console.WriteLine("Swordsman print()");
        }
    }

    /// <summary>
    /// simple factory 
    /// </summary>
    class UnitFactory
    {
        public static IUnitInvoice GetUnitInstance(int typeId)
        {
            IUnitInvoice unit;
            if (typeId == 1) unit = new UnitMarksman();
            else if (typeId == 2) unit = new UnitSwordsman();
            else throw new ArgumentException("Incorrect type");
            return unit;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IUnitInvoice unitInst = UnitFactory.GetUnitInstance(1);
            unitInst.Print();
            Console.ReadKey();
        }
    }
}
