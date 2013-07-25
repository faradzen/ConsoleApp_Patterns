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

    /// <summary> factory for concrete class
    /// </summary>
    class UnitSwordsmanFactory
    {
        public static UnitSwordsman GetInstance()
        {
            return new UnitSwordsman();
        }
    }
    /// <summary> factory for concrete class
    /// </summary>
    class UnitMarksmanFactory
    {
        public static UnitMarksman GetInstance()
        {
            return new UnitMarksman();
        }
    }

    /// <summary>
    /// simple factory where we use another factories for concrete objects
    /// </summary>
    class UnitFactory
    {
        public static IUnitInvoice GetUnitInstance(int typeId)
        {
            IUnitInvoice unit;
            if (typeId == 1) unit = UnitMarksmanFactory.GetInstance();
            else if (typeId == 2) unit = UnitSwordsmanFactory.GetInstance();
            else throw new ArgumentException("Incorrect type");
            return unit;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Abstract factory example");
            IUnitInvoice unitInst = UnitFactory.GetUnitInstance(1);
            unitInst.Print();
            Console.ReadKey();
        }
    }
}
