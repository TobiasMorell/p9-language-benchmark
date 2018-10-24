cmake_minimum_required(VERSION 3.12)
project(native)

set(CMAKE_CXX_STANDARD 14)

add_executable(native main.cpp Benchmark8/Timer.hpp Benchmark8/Benchmark8.hpp Tests/Tests.h Out.hpp)