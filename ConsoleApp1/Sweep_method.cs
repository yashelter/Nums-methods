using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Types;

namespace Methods
{
    static class Sweep_method
    {
        public static List<double> sweep_method(Matrix matrix, List<double> d, ref double determinant)
        {
            try
            {
                IsTridiagonal(matrix);
            }
            catch (Exception)
            {
                throw;
            }
            int n = matrix.size;
            if (Math.Abs(matrix.matrix[0][0]) < Math.Abs(matrix.matrix[0][1]))
            {
                throw new Exception($"Невыполенено условие: |B[i]| >= |ci| i = {0}");
            }

            for (int i = 1; i < n - 1; i++)
            {
                double ai = matrix.matrix[i][i - 1];  // Элемент ниже главной диагонали
                double bi = matrix.matrix[i][i];      // Элемент на главной диагонали
                double ci = matrix.matrix[i][i + 1];  // Элемент выше главной диагонали

                if (Math.Abs(bi) < Math.Abs(ai) + Math.Abs(ci)) // /Bi/ >= /ai /+ /ci/ 
                {
                    throw new Exception($"Невыполенено условие: |B[i]| >= |ai| + |ci|,  i = {i}");
                }
            }
            if (Math.Abs(matrix.matrix[n - 1][n - 1]) < Math.Abs(matrix.matrix[n - 1][n - 2]))
            {
                throw new Exception($"Невыполенено условие: |B[i]| >=|ai|,  i = {n}");
            }
            List<double> p = new List<double>(new double[n]);
            List<double> q = new List<double>(new double[n]);

            List<double> x = new List<double>(new double[n]);

            double b0 = matrix.matrix[0][0];
            double c0 = matrix.matrix[0][1];
            p[0] = -c0 / b0;
            q[0] = d[0] / b0;

            for (int i = 1; i < n - 1; i++)
            {
                double ai = matrix.matrix[i][i - 1];  // Элемент ниже главной диагонали
                double bi = matrix.matrix[i][i];      // Элемент на главной диагонали
                double ci = matrix.matrix[i][i + 1];  // Элемент выше главной диагонали

                double denom = bi + ai * p[i - 1];
                p[i] = -ci / denom;
                q[i] = (d[i] - ai * q[i - 1]) / denom;
            }


            int last = n - 1;
            double alast = matrix.matrix[last][last - 1];
            double blast = matrix.matrix[last][last];
            p[last] = 0;
            q[last] = (d[last] - alast * q[last - 1]) / (blast + alast * p[last - 1]);

            for (int i = 0; i < n; i++)
            {
                if (Math.Abs(p[i]) > 1)
                {
                    throw new Exception($"|p[{i}]| должно быть <= p[i]");
                }
            }
            // Обратный ход (вычисление x)
            x[last] = q[last];
            for (int i = last - 1; i >= 0; i--)
            {
                x[i] = p[i] * x[i + 1] + q[i];
            }

            double det = matrix.matrix[0][0];
            for (int i = 1; i < n; ++i)
            {
                double ai = matrix.matrix[i][i - 1];
                double bi = matrix.matrix[i][i];
                det *= (bi + ai * p[i - 1]);
            }
            determinant = det;
            return x;
        }
        public static bool IsTridiagonal(Matrix m)
        {
            int n = m.size;
            if (n < 2)
            {
                throw new Exception($"Размерность > 1");
            }
            for (int i = 0; i < n; i++)
            {
                if (m.matrix[i][i] == 0)
                {
                    throw new Exception($"Ошибка: элемент [{i}, {i}] главной диагонали не должен быть равен 0");
                }
                for (int j = 0; j < n; j++)
                {
                    if (Math.Abs(i - j) > 1 && m.matrix[i][j] != 0)
                    {
                        throw new Exception($"Ошибка: элемент [{i}, {j}] должен быть равен 0 для трёхдиагональной матрицы.");
                    }
                }
            }

            return true;
        }
    }
}
