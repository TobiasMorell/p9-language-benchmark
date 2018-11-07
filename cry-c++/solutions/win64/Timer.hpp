#ifndef TIMER_INCLUDE_H
#define TIMER_INCLUDE_H

#include <chrono>

class Timer {
private:
	long start;
	long nanoTime() {
		std::chrono::time_point<std::chrono::system_clock> now =
			std::chrono::system_clock::now();

		return (long)std::chrono::duration_cast<std::chrono::nanoseconds>(now.time_since_epoch()).count();
	}
public:
	Timer() {
		this->start = nanoTime();
		this->play();
	}
	double check() {
		return (nanoTime() - this->start);
	}
	void play() {
		this->start = nanoTime();
	}
};
#endif