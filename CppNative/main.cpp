#include <iostream>
#include <iomanip>
#include "Benchmark8/Benchmark8.hpp"
#include "Tests/Tests.h"
#include <boost/format.hpp>

int main() {
    std::cout << boost::format("%-20s \t\t %-15.3lf  \t\t %-10.3lf  \t\t %-10d\n") %"Message" %"Mean" %"Deviation" %"Count";
    std::cout << "\n";

    Benchmark8("Sestoft", sestoft, 5, 250);
    Benchmark8("Multiply", multiplyVector3D, 5, 250);
    Benchmark8("Dot Product", dotproduct2D, 5, 250);
    Benchmark8("Primes", prime100Test, 5, 250);
    Benchmark8("Memory", memTest, 5, 250);
    return 0;
}