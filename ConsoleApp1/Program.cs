// See https://aka.ms/new-console-template for more information
using Methods;
using Types;
using static Types.Helper;

Matrix matrix = new Matrix();
matrix.size = 3;
matrix.matrix = new List<List<double>>
{
    new List<double> { 2, 1, 0 },
    new List<double> { 1, 3, 1 },
    new List<double> { 0, 1, 4 }
};
//matrix.InputMatrix();
/*
2 1 0
1 3 1
0 1 4
 */

List<double> d = new List<double> { 5, 6, 7 }; //InputVector(matrix.size);

double determinant = 0;
try
{
    List<double> result = Sweep_method.sweep_method(matrix, d, ref determinant);
    Console.Write("Результирующий вектор : ");
    Console.WriteLine(string.Join(", ", result));
    Console.WriteLine($"Детерминант: {determinant}");
}catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
