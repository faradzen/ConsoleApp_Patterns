using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_Interpreter
{
    public class FooContext
    {
        public string Expression { get; set; }
        public FooContext(string exp)
        {
            Expression = exp;
        }
    }

    public abstract class AbstractExpression
    {
        public abstract void Evaluate(FooContext objContext);
    }

    public class YearExpression : AbstractExpression
    {
        #region Overrides of AbstractExpression

        public override void Evaluate(FooContext objContext)
        {
            Console.WriteLine("YearExpression.Evaluate start: {0}", objContext.Expression);
            objContext.Expression = objContext.Expression.Replace("YYYY", DateTime.Now.Year.ToString());
            Console.WriteLine("YearExpression.Evaluate end: {0}", objContext.Expression);
        }

        #endregion
    }

    public class MonthExpression : AbstractExpression
    {
        #region Overrides of AbstractExpression

        public override void Evaluate(FooContext objContext)
        {
            Console.WriteLine("MonthExpression.Evaluate start: {0}", objContext.Expression);
            objContext.Expression = objContext.Expression.Replace("MM", DateTime.Now.Month.ToString());
            Console.WriteLine("MonthExpression.Evaluate end: {0}", objContext.Expression);
        }

        #endregion
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ConsoleApp_Interpreter");
            string context = "YYYY.MM";
            Console.WriteLine("context: {0}", context);
            FooContext fooContext = new FooContext(context);
            string[] elements = context.Split('.');
            ArrayList obj = new ArrayList();

            foreach (var element in elements)
            {
                if (element == "YYYY") obj.Add(new YearExpression());
                if (element == "MM") obj.Add(new MonthExpression());
            }

            foreach (AbstractExpression objAbstract in obj)
            {
                objAbstract.Evaluate(fooContext);
            }

            Console.WriteLine("fooContext.Expression: {0}", fooContext.Expression); 

            Console.ReadKey();
        }
    }
}
