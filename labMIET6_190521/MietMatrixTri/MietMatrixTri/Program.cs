using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.IO;

namespace MietMatrixTri
{
    
    class Program
    {
        //C:\Users\vld85\source\repos\MatrixDll\Debug\MatrixDll.dll
        // C:\Users\vld85\source\repos\MatrixDll\Debug
        [DllImport("C:\\Users\\vld85\\source\\repos\\MatrixDll\\Debug\\MatrixDll.dll", CharSet = CharSet.Auto,
                CallingConvention = CallingConvention.StdCall, EntryPoint = "matrixInit")]
        public static extern double MatrixInitUnmanaged(int dimension, int count);

        
        [return: MarshalAs(UnmanagedType.LPArray, SizeConst = 2)]
        [DllImport("C:\\Users\\vld85\\source\\repos\\MatrixDll\\Debug\\MatrixDll.dll", CharSet = CharSet.Auto,
           CallingConvention = CallingConvention.StdCall, EntryPoint = "matrixSolve")]
        public static extern void MatrixSolveUnmanaged(int dimension, [In, Out] double[] _diag, [In, Out] double[] _f);

        public static double matrixInit(int dimension, int count)
        {

            Matrix matr = new Matrix(dimension);
            double[] f = new double[dimension];
            for (int i = 0; i < dimension; i++)
            {
                f[i] = dimension;
            }
            var watch = Stopwatch.StartNew();
            for (int i = 0; i < count; ++i)
                matr.Solve(f);
            watch.Stop();

            return watch.Elapsed.TotalSeconds;
        }


        static void Main(string[] args)
        {
      
            Console.WriteLine("---------------Задание 1---------------");
            double[] diag = new double[7];
            for (int i = 0; i < 7; i++)
                diag[i] = i;
            double[] f = new double[3];
            f[0] = 2;
            f[1] = 2;
            f[2] = 2;
            Matrix matr = new Matrix(3, diag);
            foreach (double i in matr.Solve(f))
                Console.WriteLine(i);

          
            Console.WriteLine("---------------Задание 2---------------");
            
            MatrixSolveUnmanaged(3, diag, f);

        
            Console.WriteLine("---------------Задание 3---------------");
            TimesList list = new TimesList();

            string curDir = Directory.GetCurrentDirectory();

            Console.WriteLine("Enter file name: ");
            string filename = Console.ReadLine();

            FileInfo usersFile = new FileInfo($"{curDir}\\{filename}");
            if (!usersFile.Exists)
            {
                usersFile.Create();
            }
            else
            {
                list.Load($"{curDir}\\{filename}");
            }

            Console.WriteLine(list.ToString());

           
            Console.WriteLine("---------------Задание 4---------------");
            bool b = true;
            while (b)
            {
                Console.WriteLine("1. New test");
                Console.WriteLine("2. Exit");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Enter matrix dimention: ");
                        int dim = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter number of repetitions: ");
                        int count = Convert.ToInt32(Console.ReadLine());
                        TimeItem item = new TimeItem(dim, count, MatrixInitUnmanaged(dim, count), matrixInit(dim, count));
                        list.Add(item);
                        break;
                    case "2":
                        b = false;
                        Console.WriteLine(list.ToString());
                        list.Save($"{curDir}\\{filename}");
                        break;

                }
            }

            Console.WriteLine("Нажмите enter для выхода");
            string name = Console.ReadLine();
        }
    }
}
