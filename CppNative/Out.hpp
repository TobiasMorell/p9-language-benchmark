//
// Created by tgm on 24/10/18.
//

#ifndef NATIVE_OUT_H
#define NATIVE_OUT_H

#include <boost/format.hpp>
#include <iostream>
#include <fstream>
#include <stdio.h>

//#define WINDOWS

#ifdef WINDOWS
#include <direct.h>
#define GetCurrentDir _getcwd
#else
#include <unistd.h>
#define GetCurrentDir getcwd
#endif
#include<iostream>

std::string GetCurrentWorkingDir( void ) {
    char buff[FILENAME_MAX];
    GetCurrentDir( buff, FILENAME_MAX );
    std::string current_working_dir(buff);
    return current_working_dir;
}

std::ofstream bench_file;

static void open_file(std::string *filename)  {
    std::string full_path = GetCurrentWorkingDir() + "/../../results/" + *filename;
    std::cout << full_path + "\n";
    bench_file.open(full_path);
}

static void print_header() {
    bench_file << "Test,Message,Mean,Deviation,Count\n";
}

static void printResults (std::string msg, double mean, double standardDeviation, int count){
    std::cout << msg + " is done\n";
    bench_file << boost::format("%s,%lf,%lf,%d\n") %msg %mean %standardDeviation %count;
}

static void close_file() {
    bench_file.flush();
    bench_file.close();
}

#endif //NATIVE_OUT_H
