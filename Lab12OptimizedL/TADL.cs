using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab12OptimizedL
{
    public abstract class TADL
    {
        int[] values;
        int bufferSize;
        int k;

        public abstract void Push(int value);
        public abstract int Pop();
        public TADL( int bufSize)
        {
            k = 0;
            values = new int[1];
            bufferSize = bufSize;
        }

        protected void AddBegin(int x)
        {
            if (k == values.Length)
            {
                int[] temp = new int[values.Length + bufferSize];
                for (int i = 0; i < k; i++)
                {
                    temp[i + 1] = values[i];
                }
                temp[0] = x;
                k++;
                values = temp;
            }
            else
            {
                for (int i = k - 1; i >= 0; i--)
                {
                    values[i + 1] = values[i];
                }
                values[0] = x;
                k++;
            }
        }

        protected void AddEnd(int x)
        {
            if(k <= values.Length - 1)
            {
                values[k] = x;
                k++;
            }
            else
            {
                int[] temp = new int[values.Length + bufferSize];
                for (int i = 0; i < k; i++)
                {
                    temp[i] = values[i];
                }
                temp[k] = x;
                k++;
                values = temp;
            }
        }
        protected int DelEnd()
        {
            int toR = values[k - 1];
            k--;

            if (k == values.Length - bufferSize)
            //if((values.Length - k + 1) < bufferSize)
            {
                int[] temp = new int[values.Length - bufferSize];
                for (int i = 0; i < k ; i++)
                {
                    temp[i] = values[i];
                }
                values = temp;
            }
            else
            {
                values[k] = 0;
            }
            return toR;

        }

        protected int DelBegin()
        {
            int toR = values[0];
            k--;
            if (k == values.Length - bufferSize)
            {
                int[] temp = new int[values.Length - bufferSize];
                for (int i = 0; i < k; i++)
                {
                    temp[i] = values[i + 1];
                }
                values = temp;
            }
            else
            {
                for (int i = 0; i < k; i++)
                {
                    values[i] = values[i + 1];
                }
                values[k] = 0;
            }
            return toR;
        }
        public string View()
        {
            string toR = "";
            for (int i = 0; i < values.Length; i++)
                toR += values[i] + " ";
            return toR;
        }
    }
}
