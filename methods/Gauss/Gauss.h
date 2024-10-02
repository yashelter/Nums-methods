//
// Created by yashelter on 02.10.2024.
//

#ifndef GAUSS_H
#define GAUSS_H

#include <vector>
#include <matrix.h>
using std::vector;



int find_line_gauss(const matrix &mas, int j, int start);

matrix& prepare_matrix(matrix &mas, double &multiplier);

vector<double> gauss_method(matrix mas, double &det);

vector<double> addition_line(const vector<double> &a, const vector<double> &b);
vector<double> multiplication_line(const vector<double> &mas, double delimeter);

#endif //GAUSS_H
