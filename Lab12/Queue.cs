using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab12
{
    /*internal class Coada
    {
        int[] values;

        public Coada()
        {
            values = new int[0];
        }
        public void Push(int val)
        {
            int[] toR = new int[values.Length + 1];
            for (int i = 0; i < values.Length; i++)
            {
                toR[i + 1] = values[i];
            }
            toR[0] = val;
            values = toR;
        }
        public int Pop()
        {
            int[] temp = new int[values.Length - 1];
            int toR = values[values.Length - 1];
            for (int i = 0; i < values.Length - 1; i++)
            {
                temp[i] = values[i];
            }
            values = temp;
            return toR;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < values.Length; i++)
            {
                sb.Append(values[i]);
                sb.Append(" ");
            }
            return sb.ToString();
        }
    }*/
    internal class Queue : TADL
    {
        public Queue() : base() { }

        /*public override void Push(int val)
        {
            base.Push(val); // you can write additional code here
        }*/
        public override float Pop()
        {
            float[] temp = new float[values.Length - 1];
            float toR = values[values.Length - 1];
            for (int i = 0; i < values.Length - 1; i++)
            {
                temp[i] = values[i];
            }
            values = temp;
            return toR;
        }

    }
}
