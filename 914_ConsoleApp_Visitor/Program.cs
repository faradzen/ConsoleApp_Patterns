using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace _914_ConsoleApp_Visitor
{
    //visitor struct

    public interface IVisitor
    {
        void Visit<T>(T obj);
        void PrintData();
    }

    public abstract class VisitorResult
    {
        protected string Data;
        public void PrintData()
        {
            Console.WriteLine("DATA: {0}", Data);
        }
    }

    public class VisitorString : VisitorResult, IVisitor
    {
        public void Visit<T>(T obj)
        {
            Data = obj.ToString();
        }
    }

    public class VisitorXml : VisitorResult, IVisitor
    {
        public void Visit<T>(T obj)
        {
            var serializer = new XmlSerializer(typeof(T));
            using (var stream = new MemoryStream())
            {
                var xmlTextWriter = new XmlTextWriter(stream, Encoding.UTF8);
                serializer.Serialize(xmlTextWriter, obj);
                string text = Encoding.UTF8.GetString(stream.ToArray());
                Data = text;
            }
        }
    }

    public interface ICustomerElements
    {
        void Accept(IVisitor visitor);
    }

    //example classes

    public class Customer : ICustomerElements
    {
        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
            visitor.PrintData();
            foreach (Address addr in Address)
            {
                addr.Accept(visitor);
            }
        }

        public string Name { get; set; }

        [XmlElement(Type = typeof(Address))]
        public ArrayList Address { get; set; }

        public override string ToString()
        {
            return String.Format("Customer name:{0}", Name);
        }
    }

    public class Address : ICustomerElements
    {
        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
            visitor.PrintData();
        }

        public string Value { get; set; }
        public string Zip { get; set; }

        public override string ToString()
        {
            return String.Format("Address:{0}, Zip:{1}", Value ?? String.Empty, Zip ?? String.Empty);
        }
    }

    //main

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("VISITOR");
            VisitorString vStr = new VisitorString();
            VisitorXml vXml = new VisitorXml();
            Customer customer = new Customer
                                   {
                                       Name = "James",
                                       Address =
                                           new ArrayList(new[]
                                                             {
                                                                 new Address {Value = "MIRA 100", Zip = "45678"},
                                                                 new Address {Value = "ELGERA 19", Zip = "012733"}
                                                             })
                                   };
            customer.Accept(vStr);
            customer.Accept(vXml);

            Console.ReadKey();
        }
    }
}
