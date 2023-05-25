using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab12
{
    abstract class TADL
    {
        protected float[] values;

        protected TADL()
        {
            values = new float[0];
        }
        public virtual void Push(float val)
        {
            float[] toR = new float[values.Length + 1];
            for (int i = 0; i < values.Length; i++)
            {
                toR[i + 1] = values[i];
            }
            toR[0] = val;
            values = toR;
        }

        public abstract float Pop();

        public virtual string View()
        {
            return values.ToString();
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
    }
}
