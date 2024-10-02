//
// Created by yashelter on 02.10.2024.
//

#ifndef MATRIX_H
#define MATRIX_H
#include <fstream>
#include <iostream>
#include <vector>


using matrix = std::vector<std::vector<double>>;

matrix input_matrix(int n);

inline std::ostream& operator << (std::ostream &os, const matrix &m)
{
    for (const auto & i : m)
    {
        for (const double j : i)
        {
            std::cout << j << " ";
        }
        std::cout << std::endl;
    }
    return os;
}

#endif //MATRIX_H
