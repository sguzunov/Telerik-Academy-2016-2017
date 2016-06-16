namespace MatrixImplementation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Test
    {
        static void Main()
        {
            var m1 = new Matrix<int>(2, 2);
            m1[0, 0] = 1;
            m1[0, 1] = 1;
            m1[1, 0] = 1;
            m1[1, 1] = 1;

            var m2 = new Matrix<int>(2, 2);
            m2[0, 0] = 2;
            m2[0, 1] = 2;
            m2[1, 0] = 2;
            m2[1, 1] = 2;

            // All matrix values should be equal to 3.
            //Console.WriteLine("Test addition.");

            //var additionMatrix = m1 + m2;
            //for (int i = 0; i < additionMatrix.Rows; i++)
            //{
            //    for (int j = 0; j < additionMatrix.Columns; j++)
            //    {
            //        Console.Write(additionMatrix[i, j] + " ");
            //    }

            //    Console.WriteLine();
            //}

            // All matrix values should be equal to -1.
            //Console.WriteLine("Test substraction.");

            //var sustractionMatrix = m1 - m2;
            //for (int i = 0; i < sustractionMatrix.Rows; i++)
            //{
            //    for (int j = 0; j < sustractionMatrix.Columns; j++)
            //    {
            //        Console.Write(sustractionMatrix[i, j] + " ");
            //    }

            //    Console.WriteLine();
            //}

            //var m3 = new Matrix<int>(3, 2);
            //m3[0, 0] = 1;
            //m3[0, 1] = 2;
            //m3[1, 0] = 3;
            //m3[1, 1] = 4;
            //m3[2, 0] = 5;
            //m3[2, 1] = 6;

            //var m4 = new Matrix<int>(2, 4);
            //m4[0, 0] = 1;
            //m4[0, 1] = 2;
            //m4[0, 2] = 3;
            //m4[0, 3] = 4;
            //m4[1, 0] = 5;
            //m4[1, 1] = 6;
            //m4[1, 2] = 7;
            //m4[1, 3] = 8;

            ///*
            //    Result should be: 
            //    11 14 17 20
            //    23 30 37 44
            //    35 46 57 68 
            //*/
            //Console.WriteLine("Test multiplication.");

            //var multipliedMatrix = m3 * m4;
            //for (int i = 0; i < multipliedMatrix.Rows; i++)
            //{
            //    for (int j = 0; j < multipliedMatrix.Columns; j++)
            //    {
            //        Console.Write(multipliedMatrix[i, j] + " ");
            //    }

            //    Console.WriteLine();
            //}
        }
    }
}
