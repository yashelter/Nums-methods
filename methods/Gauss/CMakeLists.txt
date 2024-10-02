cmake_minimum_required(VERSION 3.29)
project(GaussMethod)

set(CMAKE_CXX_STANDARD 23)

add_executable(GaussMethod main.cpp
        Gauss.cpp
        Gauss.h)

target_link_libraries(
        GaussMethod
        PUBLIC
        matrix)
