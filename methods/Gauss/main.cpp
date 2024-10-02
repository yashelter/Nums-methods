#include <iostream>
#include "Gauss.h"


using std::cin, std::cout;
int main()
{
    freopen("/home/yashelter/Documents/GaussMethod/methods/Gauss/input.txt", "r", stdin);
    int n;
    cin >> n;
    matrix m = input_matrix(n);
    double det = 1;

    auto answers = gauss_method(m, det);
    cout << "The determinant of the matrix is " << det << '\n';
    for (int i = 0; i < answers.size(); ++i)
    {
        std::cout << "X" << i << " = " << answers[i] << std::endl;
    }
    return 0;
}
