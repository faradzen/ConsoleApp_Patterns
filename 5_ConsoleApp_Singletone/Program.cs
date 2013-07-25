using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_ConsoleApp_Singletone
{
    public class Currency
    {
        List<string> oCurrencies = new List<string>();
        public Currency()
        {
            oCurrencies.Add("INR");
            oCurrencies.Add("USD");
            oCurrencies.Add("NEP");
            oCurrencies.Add("GBP");

        }
        public IEnumerable<string> getCurrencies()
        {
            return (IEnumerable<string>)oCurrencies;
        }
    }

    public class Country
    {
        List<string> oCountries = new List<string>();
        public Country()
        {
            oCountries.Add("India");
            oCountries.Add("Nepal");
            oCountries.Add("USA");
            oCountries.Add("UK");

        }
        public IEnumerable<string> getCounties()
        {
            return (IEnumerable<string>)oCountries;
        }
    }

    /// <summary>
    /// Multithreaded Singleton 
    /// see here http://msdn.microsoft.com/en-us/library/ff650316.aspx
    /// 
    /// </summary>
    public sealed class GlobalSingleton
    {
        public Currency Currencies = new Currency();
        public Country Countries = new Country();

        static GlobalSingleton _instance;
        private static object syncRoot = new Object();


        public static GlobalSingleton GetInstance()
        {
            if (_instance == null)
            {
                lock (syncRoot)
                {
                    if (_instance == null)
                        _instance = new GlobalSingleton();
                }
            }
            return _instance;
        }

        private GlobalSingleton()
        {
            Console.WriteLine("Sinlgetone contructor call ();");
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Singletone example.");

            GlobalSingleton oSingle = GlobalSingleton.GetInstance();
            Country o = oSingle.Countries;
            Console.WriteLine(o.getCounties().First());

            o = oSingle.Countries;
            Console.WriteLine(o.getCounties().Last());

            Console.ReadKey();
        }
    }
}
