using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6_ConsoleApp_Command
{
    public interface IExecute
    {
        string Command { get; set; }
        void Execute();
    }

    class ExecExit:IExecute
    {
        public string Command { get; set; }

        public ExecExit()
        {
            Console.WriteLine("Constr ExecExit");
            Command = "Exit";
        }

        public void Execute()
        {
            Console.WriteLine(":Exit Command");
        }
    }

    class ExecOpen : IExecute
    {
        public string Command { get; set; }

        public ExecOpen()
        {
            Console.WriteLine("Constr ExecOpen");
            Command = "Open";
        }

        public void Execute()
        {
            Console.WriteLine(":Open Command");
        }
    }

    class Invoker
    {
        private ArrayList objArrList;

        public Invoker()
        {
            objArrList = new ArrayList();
            objArrList.Add(new ExecOpen());
            objArrList.Add(new ExecExit());
        }

        public IExecute GetCommand(string commandName)
        {
             foreach (object item in objArrList)
            {
                var objE = item as IExecute;
                if (objE.Command == commandName)
                    return objE;
            }
            return null;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("COMMAND PATTERN");

            Invoker objInvoker = new Invoker();
            IExecute iObjExecute = objInvoker.GetCommand("Exit");

            iObjExecute.Execute();
            
            Console.ReadKey();
        }
    }
}
