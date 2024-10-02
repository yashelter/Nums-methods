cmake_minimum_required(VERSION 3.29)
project(matrix)

set(CMAKE_CXX_STANDARD 23)

add_library(matrix matrix.cpp)
target_include_directories(matrix
        PUBLIC
        ${CMAKE_CURRENT_SOURCE_DIR}
)
set_target_properties(
        matrix PROPERTIES
        LANGUAGES CXX
        LINKER_LANGUAGE CXX
        CXX_STANDARD 23
        CXX_STANDARD_REQUIRED ON
        CXX_EXTENSIONS OFF
        VERSION 1.0)