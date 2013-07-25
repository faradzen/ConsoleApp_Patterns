using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_Builder
{/*
  * http://www.codeproject.com/Articles/28309/Design-pattern-FAQ-Part-1-Training
  * 
  * Builder falls under the type of creational pattern category. 
  * Builder pattern helps us to separate the construction of a complex object from its 
  * representation so that the same construction process can create different representations. 
  * Builder pattern is useful when the construction of the object is very complex. The main 
  * objective is to separate the construction of objects and their representations. If we 
  * are able to separate the construction and representation, we can then get many 
  * representations from the same construction. 
  * 
  * 
  * There are three main parts when you want to implement builder patterns.

• Builder: - Builder is responsible for defining the construction process for individual parts. 
  * Builder has those individual processes to initialize and configure the product.
• Director: - Director takes those individual processes from the builder and defines the sequence to build the product.
• Product: - Product is the final object which is produced from the builder and director coordination.
  * */



    public abstract class ReportBulder
    {
        protected ClsReport ObjReport;

        public abstract void SetReportType();
        public abstract void SetReportHeader();
        public abstract void SetReportFooter();

        public void CreateNewReport()
        {
            Console.WriteLine("Abstract Report Builder.CreateNewReport()");
        }

        public ClsReport GetReport()
        {
            Console.WriteLine("Abstract Report Builder.Getreport()");
            ObjReport = new ClsReport();
            return ObjReport;
        }
    }

    public class ReportPDF : ReportBulder
    {
        #region Overrides of ReportBulder

        public override void SetReportType()
        {
            Console.WriteLine("ReportPDF.SetReportType");
        }

        public override void SetReportHeader()
        {
            Console.WriteLine("ReportPDF.SetReportHeader");
        }

        public override void SetReportFooter()
        {
            Console.WriteLine("ReportPDF.SetReportFooter");
        }

        #endregion
    }

    public class ReportExcel : ReportBulder
    {
        #region Overrides of ReportBulder

        public override void SetReportType()
        {
            Console.WriteLine("ReportExcel.SetReportType");
        }

        public override void SetReportHeader()
        {
            Console.WriteLine("ReportExcel.SetReportHeader");
        }

        public override void SetReportFooter()
        {
            Console.WriteLine("ReportExcel.SetReportFooter");
        }

        #endregion
    }

    /// <summary>
    /// director is like a driver who takes all the individual processes and calls them in sequential manner to generate the final product
    /// </summary>
    public class ClsDirector
    {
        public ClsReport MakeReport(ReportBulder objBuilder)
        {
            objBuilder.CreateNewReport();
            objBuilder.SetReportType();
            objBuilder.SetReportHeader();
            objBuilder.SetReportFooter();
            return objBuilder.GetReport();
        }
    }

    //The third component in the builder is the product which is nothing but the report class in this case.
    public class ClsReport
    {
        public string Value { get; set; }

        private Guid _token;

        public ClsReport()
        {
            _token = Guid.NewGuid();
        }

        public void DisplayReport()
        {
            Console.WriteLine("ClsReport - > DISPLAY REPORT with token: {0}", _token.ToString());
        }
        //etc...
    }


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Builder example");
            //builder using process
            ClsReport objReport;
            ClsDirector objDirector = new ClsDirector();

            ReportPDF objRepPdf = new ReportPDF();
            objReport = objDirector.MakeReport(objRepPdf);
            objReport.DisplayReport();

            ReportExcel objRepExcel = new ReportExcel();
            objReport = objDirector.MakeReport(objRepExcel);
            objReport.DisplayReport();

            Console.ReadKey();
        }
    }
}
