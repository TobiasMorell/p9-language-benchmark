#include <iostream>
#include <iomanip>
#include "Benchmark8/Benchmark8.hpp"
#include "Tests/Tests.h"
#include <boost/format.hpp>
#include "Out.hpp"

#ifndef NDEBUG
std::string compile_mode = "debug";
#else
std::string compile_mode = "release";
#endif

int main() {
    std::string filename = "WSL C++ (" + compile_mode + ").csv";
    open_file(&filename);
    print_header();

    Benchmark8("Scale2D", scaleVector2D, 5, 250);
    Benchmark8("Scale3D", scaleVector3D, 5, 250);
    Benchmark8("Multiply2D", multiplyVector2D, 5, 250);
    Benchmark8("Multiply3D", multiplyVector3D, 5, 250);
    Benchmark8("Translate2D", translateVector2D, 5, 250);
    Benchmark8("Translate3D", translateVector3D, 5, 250);
    Benchmark8("Substract2D", substractVector2D, 5, 250);
    Benchmark8("Substract3D", substractVector3D, 5, 250);
    Benchmark8("Length2D", lengthVector2D, 5, 250);
    Benchmark8("Length3D", lengthVector3D, 5, 250);
    Benchmark8("DotProduct2D", dotproduct2D, 5, 250);
    Benchmark8("DotProduct3D", dotproduct3D, 5, 250);
    Benchmark8("Primes100", prime100Test, 5, 250);
    Benchmark8("Memory", memTest, 5, 250);
    Benchmark8("Sestoft", sestoft, 5, 250);

    close_file();

    return 0;
}
