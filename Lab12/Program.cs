using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*Queue q = new Queue();
            q.Push(5);
            q.Push(6);
            q.Push(7);
            q.Push(8);
            Console.WriteLine(q.ToString());
            q.Pop();
            Console.WriteLine(q.ToString());
            q.Push(9);
            Console.WriteLine(q.ToString());*/
            RPN r = new RPN();
            r.Eval();
            Console.ReadKey();
        }
    }
}
