using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab12
{
    internal class RPN
    {
        string value;

        public RPN() { Load(@"..\..\input.txt"); }
        public void Load(string fileName)
        {
            TextReader rd = new StreamReader(fileName);
            value = rd.ReadLine();
            rd.Close();
        }

        public float Eval()
        {
            string[] data = value.Split(' ');
            Lab12.TADL st = new Lab12.Stack();

            for(int i = 0; i < data.Length; i++)
            {
                if (data[i][0] >= '0' && data[i][0] <= '9')
                {

                    st.Push(float.Parse(data[i]));
                }
                else
                {
                    float t1 = st.Pop();
                    float t2 = st.Pop();
                    switch (data[i][0])
                    {
                        case '+':
                            st.Push(t2 + t1);
                            break;
                        case '-':
                            st.Push(t2 - t1);
                            break;
                        case '*':
                            st.Push(t2 * t1);
                            break;
                        case ':':
                            st.Push(t2 / t1);
                            break;
                    }
                }
                Console.WriteLine(st);
            }
            return st.Pop();
        }
    }
}
