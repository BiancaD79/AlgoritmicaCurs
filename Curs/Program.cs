using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curs
{
    internal class Program
    {
        /// <summary>
        /// sa de o sima s si un .. de valori (bancnote) v
        /// se cere o serie ca si o combinatie liniare de elemente v
        /// ex 2917
        /// v[] = {1000 500 100 50 20 10 5 1}
        /// 2917 - 5*500 + 2*50 + 17*1 (30)
        /// 
        /// numarul minim de bancnote care se poate
        /// 2917 - 2*1000 + 1*500 + 4*100 + 1*10 + 1*5 + 2*1
        /// </summary>
        static void P1()
        {
            int s = int.Parse(Console.ReadLine());
            int[] v = new int[] { 1000, 500, 100,50, 10, 1 };
            int[] r = new int[v.Length];
            for (int i = 0; i < v.Length; i++)
            {
                r[i] = s / v[i];
                s %= v[i];
            }
            PrintArray(r);
        }
        /// <summary>
        /// se dau n spectacole(prin timpul initial si timpul final) - ora la care incepe si ora la care se termina
        /// ex:
        /// 3 5
        /// 1 4 
        /// 2 5
        /// 1 6
        /// 0 3
        /// 4 5
        /// 6 7
        /// 5 8
        /// 4 7
        /// 2 5
        /// 1 3
        /// 0 4
        /// avand la dispozitie o singura scena, se cere sa se programeze un numar maxim de spectacole
        /// sa nu existe mai mult decat 1 spectacol pe scena in acelas timp
        /// </summary>
        static void P2()
        {
            Spectacol[] S;
            List<string> list = new List<string>();
            string buffer;
            TextReader reader = new StreamReader(@"..\..\input.txt");
            while((buffer = reader.ReadLine())!=null)
            {
                list.Add(buffer);
            }
            
            S = new Spectacol[list.Count];
            
            for (int i = 0; i < list.Count ; i++)
            {
                string[] line = buffer.Split(' ');
                S[i] = new Spectacol(int.Parse(line[0]), int.Parse(line[1]));
            }

            for (int i = 0; i < S.Length; i++)
            {
                for (int j = i+1; j < S.Length; j++)
                {
                    if (S[i].endTime > S[j].endTime)
                    {
                       Spectacol aux = S[i];
                        S[i] = S[j];
                        S[j] = aux;
                    }
                }
            }
            S[0].View();
            int tf = S[0].endTime;
            for (int i = 1; i < S.Length; i++)
            {
                if (S[i].startTime >= tf)
                {
                    S[i].View();
                    tf = S[i].endTime;
                }
            }
        }
        /// <summary>
        /// se da un numar in scrierea romana
        /// se cere valoarea acestuia
        /// ex.
        /// MMCMLXXIV
        /// 
        /// </summary>
        static void P3()
        {
            string T = Console.ReadLine();
            int toReturn = 0;
            for (int i = 0; i < T.Length - 1; i++)
            {
                if (RtoV(T[i]) >= RtoV(T[i + 1]))
                    toReturn += RtoV(T[i]);
                else
                    toReturn -= RtoV(T[i]);
            }
            toReturn += RtoV(T[T.Length - 1]);
            Console.WriteLine(toReturn);
        }
        /// <summary>
        /// Convert from roman numbers to value(arab)
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        static int RtoV(char c)
        {
            switch(c)
            {
                case 'M': return 1000;
                case 'D': return 500;
                case 'C': return 100;
                case 'L': return 50;
                case 'X': return 10;
                case 'V': return 5;
                case 'I': return 1;
            }
            return 0;
        }
        static void PrintArray(int[] v) 
        {
            for (int i = 0; i < v.Length; i++)
            {
                Console.Write(v[i] + " ");
            }
            Console.WriteLine();
        }
        /*
         * ------------- Exercitiul 4 --------------- 
        * Ana are 5 mere si 25 pere
        * arbore de aparitie - arborele lui Huffman
        * Transformare in binar  cu arbore binar, 
        * poza cu arbore in fileexplorer
        * -------------------------------------------
        */

        /*
         * ------------- Exercitiul 5 --------------- 
         * Se da un nr in scrierea araba. Sa se transforme in scrierea romana.
         * 
         * -------------------------------------------
         */

        /// <summary>
        /// Se da un nr in scrierea araba. Sa se transforme in scrierea romana.
        /// </summary>
        static void P4()
        {
            int n = int.Parse(Console.ReadLine());
            if (n > 9999)
                Console.WriteLine("Nu am implementat pentru numar asa mare :))");
            else
            {
                T(n / 1000 % 10, "M", "V*", "X*");
                T(n / 100 % 10, "M", "D", "M");
                T(n / 10 % 10, "X", "L", "X");
                T(n % 10, "I", "V", "X");
            }
            /*int[] v = new int[] { 1000, 500, 100,50, 10, 1 };
            int[] r = new int[v.Length];
            for (int i = 0; i < v.Length; i++)
            {
                r[i] = n / v[i];
                n %= v[i];
            }
            PrintArray(r);*/

        }
        /// <summary>
        /// transformare in functie de caractere care reprezinta valorile mici, mediu si mare
        /// ex: 6 -> VI
        /// T(6,I,V,X) - > VI
        /// fiecare unitate: unitatilor, zecilor, sutelor, miilor presupunem ca are semnul propriu
        /// daca avem numarul 1250
        ///  1   2   5  7
        ///  1000 :T(1,M,V*,X*)
        ///  200  :T(2,C,D,M)
        ///  50   :T(5,X,L,X)
        ///  7    :T(7,I,V,X)
        /// </summary>
        /// <param name="x"></param>
        /// <param name="sl"></param>
        /// <param name="sm"></param>
        /// <param name="sh"></param>
        static void T(int x, string sl, string sm, string sh) // string low, string medium, string high - not sure if the s means string
        {
            switch(x)
            {
                case 1: Console.Write(sl); break;
                case 2: Console.Write(sl + sl); break;
                case 3: Console.Write(sl + sl + sl); break;
                case 4: Console.Write(sl + sm); break;
                case 5: Console.Write(sm); break;
                case 6: Console.Write(sm + sl); break;
                case 7: Console.Write(sm + sl + sl); break;
                case 8: Console.Write(sm + sl + sl + sl); break;
                case 9: Console.Write(sl + sh); break;
            }
        }

        /* -----------------------------------------
         *                  GREEDY
         * _________________________________________
         * Daca da corect pentru tot setul de date
         * nu exista un algoritm mai eficient.
         */
        static void Main(string[] args)
        {
            Console.WriteLine("Alege o problema {1,2,3,4}");
            string read = Console.ReadLine();
            switch (read)
            {
                case "1": P1(); break;
                case "2": P2(); break;
                case "3": P3(); break;
                case "4": P4(); break;
            }
            Console.ReadKey();
        }
    }
}
