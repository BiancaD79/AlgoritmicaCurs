using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab12
{
    internal class Stack : TADL
    {
        public Stack() : base() { }
        public override float Pop()
        {
            float[] temp = new float[values.Length - 1];
            float toR = values[0];
            for (int i = 1; i < values.Length; i++)
            {
                temp[i - 1] = values[i];
            }
            values = temp;
            return toR;
        }
    }
}
