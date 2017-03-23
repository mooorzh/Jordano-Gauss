using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixOps
{
    class Program
    {
        static void Main(string[] args)
        {
            double[][] A = new double[3][];
            A[0] = new double[4] { 5732, 2134, 2134, 7866 };
            A[1] = new double[4] { 2134, 5732, 2134, 670 };
            A[2] = new double[4] { 2134, 2134, 5732, 11464 };

            SLAE test = new SLAE(A);
            Console.WriteLine("Изначальная матрица:");
            foreach (double[] i in test.PRIM)
            {
                string res = "";
                foreach (double x in i)
                    res += x.ToString() + " ";
                Console.WriteLine(res);
            }
            Console.WriteLine("Преобразованная матрица:");
            test.JordanoGauss();
            foreach (double[] i in test.PRIM)
            {
                string res = "";
                foreach (double x in i)
                    res += x.ToString() + " ";
                Console.WriteLine(res);
            }
            Console.ReadKey();
        }
        
    }
    class SLAE
    {
        public double[][] PRIM;
        public SLAE(double[][] A)
        {
            PRIM = new double[A.Length][];
            for (int i = 0; i < A.Length; i++)
            {
                PRIM[i] = new double[A[i].Length];
                for (int j = 0; j < A[i].Length; j++)
                    PRIM[i][j] = A[i][j];
            }            
        }
        public void JordanoGauss()
        {
            double[][] A = PRIM;
            for (int i = 0; (i < A.Length) && (i < A[0].Length); i++)
            {

                double tmp = A[i][i];
                if (tmp >= 0.00000001)
                {
                    for (int j = i; j < A[0].Length; j++)
                        A[i][j] /= tmp;
                }
                for (int j = 0; j < A.Length; j++)
                {
                    if (j != i)
                    {
                        double tmp2 = A[j][i];
                        for (int k = i; k < A[0].Length; k++)
                            A[j][k] -= A[i][k] * tmp2;
                    }
                }
            }
        }
    }
}
