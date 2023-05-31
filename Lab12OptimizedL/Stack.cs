using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab12OptimizedL
{
    internal class Stack : TADL
    {
        public Stack(int bufSize): base(bufSize)
        {

        }
        public override int Pop()
        {
            return base.DelEnd();
        }

        public override void Push(int value)
        {
            base.AddEnd(value);
        }
    }
}
