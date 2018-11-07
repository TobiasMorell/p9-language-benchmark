cmake_minimum_required(VERSION 3.10)
project(CppNative)

set(CMAKE_CXX_STANDARD 14)
#set(CMAKE_CXX_COMPILE_FLAGS "-mingw64 -o CppNative.exe")

include_directories(.)
include_directories(Benchmark8)
include_directories(Tests)
#include_directories(libs/boost_1_68_0)

add_executable(CppNative
        Benchmark8/Benchmark8.hpp
        Benchmark8/Timer.hpp
        Tests/Tests.h
        CMakeLists.txt
        main.cpp
        Out.hpp)
