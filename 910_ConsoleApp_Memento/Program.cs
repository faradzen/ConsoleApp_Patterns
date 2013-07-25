using System;

namespace _910_ConsoleApp_Memento
{


    class Item
    {
        class Memento
        {
            public string Name { get; private set; }
            public string Code { get; private set; }
            public Memento(string name, string code)
            { Commit(name, code); }
            public void Commit(string name, string code)
            {
                Name = name;
                Code = code;
            }
        }

        public string Name { get; set; }
        public string Code { get; set; }
        private Memento _safe;

        public Item(string name, string code)
        {
            Name = name;
            Code = code;
            _safe = new Memento(name, code);
        }
        public void Commit() { _safe.Commit(Name, Code); }
        public void Revert()
        {
            Name = _safe.Name;
            Code = _safe.Code;
        }
        public void Print() { Console.WriteLine("Name:{0}, Code:{1}", Name, Code); }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("MEMENTO");
            var item = new Item("pen", "p001");
            item.Print();
            item.Name = "pencil";
            item.Print();
            item.Revert();
            item.Print();
            Console.ReadKey();

        }
    }
}
