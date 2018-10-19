//
// Created by tgm on 17/10/18.
//

#ifndef NATIVE_TIMER_H
#define NATIVE_TIMER_H

#include <chrono>


class Timer {
private:
    long start;
public:
    Timer();
    double check();
    void play();
};

long nanoTime(){
    std::chrono::time_point<std::chrono::system_clock> now =
            std::chrono::system_clock::now();

    return std::chrono::duration_cast<std::chrono::nanoseconds>(now.time_since_epoch()).count();
}

Timer::Timer(){
    this->start = nanoTime();
    this->play();
}

double Timer::check() {
    return (nanoTime() - this->start);
}

void Timer::play(){
    this->start = nanoTime();
}

#endif //NATIVE_TIMER_H
