// Fill out your copyright notice in the Description page of Project Settings.

#include "Benchmark.h"
#include <string>
#include <functional>
#include "Timer.h"
#include "Tests.h"
#include <fstream>
#include <iostream>
#include <FileHelper.h>

// Sets default values
ABenchmark::ABenchmark()
{
 	// Set this actor to call Tick() every frame.  You can turn this off to improve performance if you don't need it.
	PrimaryActorTick.bCanEverTick = true;
}

// Called when the game starts or when spawned
void ABenchmark::BeginPlay()
{
	Super::BeginPlay();
	EnableInput(this);
	
	UE_LOG(LogTemp, Warning, TEXT("BeginPlay"));
}

static void printResults(std::string msg, double mean, double standardDeviation, int count) {
	FString* message = new FString(msg.c_str());
	//UE_LOG(LogTemp, Warning, TEXT("%s\t%lf\t%lf\t%d"), message, mean, standardDeviation, count);
	FFileHelper::SaveStringToFile(FString::Printf("%s\t%lf\t%lf\t%d", message, mean, standardDeviation, count), TEXT("benchmark.log"));
}

static double Benchmark8(std::string msg, std::function<double(int)> &&fun, int iterations, double minTimeMs) {
	int count = 1, totalCount = 0;
	double dummy = 0.0, runningTime = 0.0, deltaTime = 0.0, deltaTimeSquared = 0.0, minTimeNs = minTimeMs * 1000000;
	do {
		count *= 2;
		deltaTime = 0.0;
		deltaTimeSquared = 0.0;
		for (int j = 0; j < iterations; j++) {
			Timer t;
			for (int i = 0; i < count; i++)
				dummy += fun(i);
			runningTime = t.getTime();
			double time = runningTime / count;
			deltaTime += time;
			deltaTimeSquared += time * time;
			totalCount += count;
		}
	} while (runningTime < minTimeNs && count < INT32_MAX / 2);
	double mean = deltaTime / iterations, standardDeviation = sqrt((deltaTimeSquared - mean * mean * iterations) / (iterations - 1));
	printResults(msg, mean, standardDeviation, count);
	return dummy / totalCount;
}

void run_benchmark() {
	UE_LOG(LogTemp, Warning, TEXT("Starting benchmark"));

	Benchmark8("Scale2D", Tests::scaleVector2D, 5, 250);
	Benchmark8("Scale3D", Tests::scaleVector3D, 5, 250);
	Benchmark8("Multiply2D", Tests::multiplyVector2D, 5, 250);
	Benchmark8("Multiply3D", Tests::multiplyVector3D, 5, 250);
	Benchmark8("Translate2D", Tests::translateVector2D, 5, 250);
	Benchmark8("Translate3D", Tests::translateVector3D, 5, 250);
	Benchmark8("Substract2D", Tests::substractVector2D, 5, 250);
	Benchmark8("Substract3D", Tests::substractVector3D, 5, 250);
	Benchmark8("Length2D", Tests::lengthVector2D, 5, 250);
	Benchmark8("Length3D", Tests::lengthVector3D, 5, 250);
	Benchmark8("DotProduct2D", Tests::dotproduct2D, 5, 250);
	Benchmark8("DotProduct3D", Tests::dotproduct3D, 5, 250);
	Benchmark8("Primes100", Tests::prime100Test, 5, 250);
	Benchmark8("Memory", Tests::memTest, 5, 250);
	Benchmark8("Sestoft", Tests::sestoft, 5, 250);

	UE_LOG(LogTemp, Warning, TEXT("Done with benchmark"));
}

bool is_test_run = false;

// Called every frame
void ABenchmark::Tick(float DeltaTime)
{
	Super::Tick(DeltaTime);
	//UE_LOG(LogTemp, Warning, TEXT("Tick"));
	if (!is_test_run) {
		is_test_run = true;
		run_benchmark();
	}
}
