//
// Created by yashelter on 02.10.2024.
//

#include "matrix.h"
#include <iostream>

matrix input_matrix(int n)
{
    matrix m(n, std::vector<double>(n+1));
    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < n+1; j++)
        {
            std::cin >> m[i][j];
        }
    }
    return m;
}