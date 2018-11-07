// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include <chrono>

/**
 * 
 */
class UNREAL_API Timer
{
private:
	long start;
public:
	Timer();
	~Timer();
	double getTime();
	void play();
};
