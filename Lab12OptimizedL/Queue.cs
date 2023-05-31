using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab12OptimizedL
{
    internal class Queue :TADL
    {
        public Queue(int bufSize) : base(bufSize)
        {

        }
        public override int Pop()
        {
            return base.DelBegin();
        }

        public override void Push(int value)
        {
            base.AddEnd(value);
        }
    }
}
