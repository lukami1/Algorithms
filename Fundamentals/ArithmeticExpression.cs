using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fundamentals
{
    public static class ArithmeticExpression
    {
        public static double Calculate(string expression)
        {
            Stack<string> ops = new Stack<string>();
            Stack<double> val= new Stack<double>();
            foreach (char c in expression)
            {
                if (c.Equals("(")) ;
                else if(c.Equals("+")) ops.Push(c.ToString());
                else if(c.Equals("*")) ops.Push(c.ToString());
                else if(c.Equals("-")) ops.Push(c.ToString());
                else if(c.Equals("/")) ops.Push(c.ToString());
                else if(c.Equals("sqrt")) ops.Push(c.ToString());
                else if (c.Equals(")"))
                {
                    var v = val.Pop();
                    var ex = ops.Pop();
                    if(ex.Equals("+")) v = val.Pop() + v;
                    if(ex.Equals("-")) v = val.Pop() - v;
                    if(ex.Equals("*")) v = val.Pop() * v;
                    if(ex.Equals("/")) v = val.Pop() / v;
                    if(ex.Equals("sqrt")) v = Math.Sqrt(v);
                    val.Push(v);
                }
                else
                {
                    val.Push(double.Parse(c.ToString()));
                }
            }
            return val.Pop();
        }
    }
} 