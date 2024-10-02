using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Types
{
    class Matrix
    {
        public int size = 0;
        public List<List<double>> matrix = new List<List<double>>();

        public void InputMatrix()
        {
            //Console.WriteLine("Введите размер квадратной матрицы:")

            size = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < size; i++)
            {
                //Console.WriteLine($"Введите элементы строки {i + 1} через пробел:");
                string[] rowElements = Console.ReadLine().Split(' ');

                List<double> row = new List<double>();
                for (int j = 0; j < size; j++)
                {
                    row.Add(double.Parse(rowElements[j]));
                }

                matrix.Add(row);
            }

            //Console.WriteLine("Матрица успешно введена.");
        }

        // Метод для вывода матрицы
        public void PrintMatrix()
        {
            Console.WriteLine("Матрица:");
            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
    class Helper
    {
        public static List<double> InputVector(int n)
        {

            //Console.WriteLine($"Введите элементы строки {i + 1} через пробел:");
            string[] rowElements = Console.ReadLine().Split(' ');

            List<double> row = new List<double>();
            for (int j = 0; j < n; j++)
            {
                row.Add(double.Parse(rowElements[j]));
            }

            return row;
        }
    }
}
