//
// Created by yashelter on 02.10.2024.
//

#include "Gauss.h"

#include <cmath>
#include <utility>

int find_line_gauss(const matrix &mas, int j, int start)
{
    int answer = start;
    for (int i = start+1; i < mas.size(); i++)
    {
        if (fabs(mas[i][j]) >= fabs(mas[answer][j]))
        {
            answer = i;
        }
    }
    return answer;
}

vector<double> multiplication_line(const vector<double> &mas, double delimeter)
{
    vector<double> answer;
    for (double ma : mas)
    {
        answer.push_back(ma * delimeter);
    }
    return answer;
}


vector<double> addition_line(const vector<double> &a, const vector<double> &b)
{
    vector<double> answer;
    for (int i=0; i < a.size(); i++)
    {
        answer.push_back(a[i] + b[i]);
    }
    return answer;
}
matrix& prepare_matrix(matrix &mas, double &multiplier)
{
    for (int i = 0; i < mas.size(); i++)
    {
        int line = find_line_gauss(mas, i, i);
        if (line != i)
        {
            multiplier *= -1;
            std::swap(mas[i], mas[line]);
        }

    }
    return mas;
}

vector<double> gauss_method(matrix mas, double &determinant)
{
    double k = 1;
    prepare_matrix(mas, k);
    for (int i = 0; i < mas.size()-1; i++)
    {
        k *= mas[i][i];
        auto temp = multiplication_line(mas[i], (1 / mas[i][i]));
        std::swap(mas[i], temp);

        vector<double> line = mas[i];

        for (int j = i+1; j < mas.size(); j++)
        {
            vector<double> answer = addition_line(mas[j], multiplication_line(line, -mas[j][i]));
            std::swap(mas[j], answer);
        }
    }
    double det = 1;
    for (int i = 0; i < mas.size(); i++)
    {
        det *= mas[i][i];
    }
    determinant = k * det;

    vector<double> answers(mas.size(), 0);
    for (int i = mas.size()-1; i >= 0; --i)
    {
        double sum = 0;
        for (int j = i+1; j < mas.size(); j++)
        {
            sum += answers[j] * mas[i][j];
        }
        answers[i] = (mas[i][mas.size()] - sum) / mas[i][i] ;
    }


    return answers;
}