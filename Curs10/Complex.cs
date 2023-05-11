using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curs10
{
    internal class Complex
    {
        double real, imaginary;

        public Complex(double real, double imaginary)
        {
            this.real = real;
            this.imaginary = imaginary;
        }

        public Complex() { }

        public string View()
        {
            return real + "+ i"+ imaginary;
        }

        public override string ToString()
        {
            if(imaginary > 0)
             return  $"{real} + {imaginary}i";
            else
                if(imaginary == 0) return $"{real}";
            else
                return $"{real} {imaginary}i";
        }

        public static Complex operator + (Complex A, Complex B)
        {
            Complex toR = new Complex();
            toR.real = A.real + B.real;
            toR.imaginary = A.imaginary + B.imaginary;
            return toR;
        }

        //public static Complex operator + (Complex A, Complex B) => return (new Complex(A.real + B.real, A.imaginary + B.imaginary));
        
        public static Complex operator * (Complex A, Complex B)
        {
            Complex toR = new Complex();
            toR.real = A.real * B.real - A.imaginary*B.imaginary;
            toR.imaginary = A.imaginary * B.real + A.real * B.imaginary;
            return toR;
        }

        public static Complex Conjugat(Complex A)
        {
            Complex toR = new Complex();
            toR.real = A.real;
            toR.imaginary = -A.imaginary;
            return toR;
        }
        public static Complex operator / (Complex A, Complex B)
        {
            Complex ConjB = Conjugat(B);
            Complex up = A * ConjB;
            Complex down = B * ConjB;
            Complex toR = new Complex();
            toR.real = up.real / down.real;
            toR.imaginary = up.imaginary / down.real;
            return toR;
        }

        public double Mod()
        {
            return Math.Sqrt(real * real + imaginary * imaginary);
        }
    }
}
