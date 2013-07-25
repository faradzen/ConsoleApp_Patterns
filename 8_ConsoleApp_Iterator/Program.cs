using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_ConsoleApp_Iterator
{
    class FooIterator
    {
        private int _currentIndex;

        public class Item
        {
            public string Code { get; set; }
            public string Name { get; set; }
        }

        private Item[] _dict;

        public FooIterator()
        {
            _currentIndex = 0;
            //load some example values
            _dict = new Item[]
                        {
                            new Item {Code = "A", Name = "Abelson"},
                            new Item {Code = "B", Name = "Smith"},
                             new Item {Code = "A", Name = "Wesson"}
                        };
        }

        public Item Prev()
        {
            _currentIndex--;
            if (_currentIndex < 0)
            {
                Console.WriteLine("overflow lower index");
            }
            Console.WriteLine("get Prev");
            return _dict[_currentIndex];
        }

        public Item Next()
        {
            _currentIndex++;
            if (_currentIndex > _dict.Length)
            {
                Console.WriteLine("overflow upper index");
            }
            Console.WriteLine("get Next");
            return _dict[_currentIndex];
        }

        public Item GetByIndex(int id)
        {
            if (_dict.Length < id)
            {
                Console.WriteLine("overflow upper index");
                return null;
            }
            if (_currentIndex < 0)
            {
                Console.WriteLine("overflow lower index");
                return null;
            }
            return _dict[_currentIndex];
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            //лениво писать пример...все понятно)))
        }
    }
}
