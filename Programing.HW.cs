using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace ConsoleApplication1
{
    class Program
    {
        static double tab(double[] arr2)
        {
            int len = arr2.Length; double q1 = 0;
            if (len % 2 == 0) { q1 = (arr2[(len / 2) - 1] + arr2[(len) / 2]) / 2; }
            else { q1 = arr2[(len / 2)]; }
            return q1;
        }
        static void Main(string[] args)
        {
            string sp = "---------------------------------------------------------------------------";
            string sm = "___________________________________________________________________________";
            Console.WriteLine(sp + "\n" + "Enter The Numbers And Press Space And So , Then Press Enter" + "\n" + sp);
            
            //Example :1 2 5 8 7 9 6 3 2

            string input = Console.ReadLine();

            string[] arr = input.Split(' ');
            double[] arr2 = new double[arr.Length];
            double[] arr3;
            double[] arr4;
            for (int i = 0; i < arr.Length; i++)
                arr2[i] = int.Parse(arr[i]);

            Array.Sort(arr2);
            Console.WriteLine(sm);
            Console.WriteLine("Sotred Array : " + "\n");

            for (int i = 0; i < arr.Length; i++)
                Console.Write(arr2[i] + " ");
            Console.WriteLine();

            Console.WriteLine(sm);
            Console.Write("Maximum : " + arr2[arr2.Length - 1].ToString() + " , " + "Minimum : " + arr2[0].ToString() + "\n");
            int len = arr.Length, l; l = len;
            double q1 = 0, q2 = 0, q3 = 0;
            //=================================================================================
            if (arr2.Length == 1) { q1 = arr2[0]; q2 = arr2[0]; q3 = arr2[0]; }
            else
            {
                q1 = tab(arr2);
                if (len % 2 == 0)
                {
                    len = len / 2;
                    arr3 = new double[len]; arr4 = new double[len];
                    for (int i = 0; i < len; i++) { arr3[i] = arr2[i]; }
                    for (int j = 0, i = len; j < len; i++, j++) { arr4[j] = arr2[i]; }
                }
                else
                {
                    len = (len / 2);
                    arr3 = new double[len]; arr4 = new double[len];
                    for (int i = 0; i < len; i++) { arr3[i] = arr2[i]; }
                    for (int j = 0, i = len + 1; j < len; j++, i++) { arr4[j] = arr2[i]; }
                }
                q2 = tab(arr3);
                q3 = tab(arr4);
            }
            Console.WriteLine("Q2 : " + q1 + "\n" + "Q1 : " + q2 + "\n" + "Q3 : " + q3);
            Console.WriteLine();
            //=================================================================================
            double iqr = q3 - q2, w1 =q1- (1.5 * iqr) , w2 = q3 + (1.5 * iqr);
            int rr = 0;
            Console.Write("Outlier :  ");
            for (int i = 0; i < arr2.Length; i++)
                if (arr2[i] > w2 || arr2[i] < w1)
                { Console.Write(arr2[i] + " , "); rr++; }

            if (rr == 0) Console.Write("There is no Outlier");
            //=================================================================================
            Console.WriteLine();
            Console.Write(sp);
            Console.ReadKey();
        }
    }
}