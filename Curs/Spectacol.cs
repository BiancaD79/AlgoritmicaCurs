using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curs
{
    internal class Spectacol
    {
        public int endTime;
        public int startTime;

        public Spectacol(int start, int end)
        {
            this.startTime = start;
            this.endTime = end;
        }

        public void View()
        {
            Console.WriteLine($"{startTime} - {endTime}");
        }
    }
}
