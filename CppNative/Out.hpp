//
// Created by tgm on 24/10/18.
//

#ifndef NATIVE_OUT_H
#define NATIVE_OUT_H

#include <boost/format.hpp>
#include <iostream>

static void printResults (std::string msg, double mean, double standardDeviation, int count){
    std::cout << boost::format("%-20s \t\t %-15.3lf ns\t\t %-10.3lf ns\t\t %-10d\n") %msg %mean %standardDeviation %count;
}

#endif //NATIVE_OUT_H
