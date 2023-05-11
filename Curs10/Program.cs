using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curs10
{
    internal class Program
    {
        /* -----------------------------------------
         *             RECURSIVITATE
         * -----------------------------------------
        */

        static void Main(string[] args)
        {
            Complex A = new Complex(0.2,-0.4);
            Complex C = A * A;
            C = C * C;
            //C = C * C;
            //C = C * C;
            //C = C * C;
            Console.WriteLine(C.View());
            Console.ReadKey();
        }
    }
}
