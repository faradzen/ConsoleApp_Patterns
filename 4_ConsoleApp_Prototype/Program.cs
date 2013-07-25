using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_ConsoleApp_Prototype
{
    class Address
    {
        public string Zip { get; set; }
        public string Value { get; set; }

        public Address GetClone()
        {
            return (Address)this.MemberwiseClone();
        }
    }

    class Customer
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }

        /// <summary>
        /// copy simple types. SHALLOW COPY
        /// </summary>
        /// <returns></returns>
        public Customer GetShallowClone()
        {
            return (Customer)this.MemberwiseClone();
        }

        public Customer GetClone()
        {
            Customer clone;
            clone = (Customer)this.MemberwiseClone();
            clone.Address = (Address)this.Address.GetClone();
            return clone;
        }

        public void Print()
        {
            Address = Address ?? new Address();
            Console.WriteLine("Customer Name:{0}, Code:{1} by Address: {2}, {3}", Name, Code, Address.Value, Address.Zip);
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Prototype example. SHALLOW COPY. ");

            Customer obj1 = new Customer()
                                {
                                    Address = new Address()
                                                  {
                                                      Value = "Mira 100",
                                                      Zip = "2345678"
                                                  },
                                    Code = "001",
                                    Name = "Danny"
                                };

            Customer obj2;
            obj2 = obj1.GetShallowClone();
            obj2.Name += " Kahovsky";
            obj2.Code += "Q";
            obj1.Address.Value += "Jamayca";

            //here we have same address object in two instances
            obj1.Print();
            obj2.Print();

            Console.WriteLine("====================");
            Console.WriteLine("DEEP COPY");
            Customer obj3;
            obj3 = obj1.GetClone();

            obj3.Address.Value += "FINLAND";

            obj1.Print();
            obj3.Print();

            Console.ReadKey();
        }
    }
}
