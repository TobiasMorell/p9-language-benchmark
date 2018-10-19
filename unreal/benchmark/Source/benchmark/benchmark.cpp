// Fill out your copyright notice in the Description page of Project Settings.

#include "Benchmark.h"
#include "Vector2D.h"

double vector2_scale(int input) {
	FVector2D vector = FVector2D(input, input);
	auto v = vector * input;
	return v.X;
}

double vector2_multiply(int input) {
	auto vector = FVector2D(input, input);
	auto v = vector * vector;
	return v.X;
}

double vector2_translate(int input) {
	auto vector = FVector2D(input, input);
	auto v = vector + vector;
	return v.X;
}

double vector2_subtract(int input) {
	auto vector = FVector2D(input, input);
	auto v = vector - vector;
	return v.X;
}

double vector2_length(int input) {
	auto vector = FVector2D(input, input);
	FVector2D dir;
	float len;

	vector.ToDirectionAndLength(dir, len);
	return len;
}

double vector2_dot(int input) {
	auto vector = FVector2D(input, input);
	auto v = vector.DotProduct(vector, vector);
	return v;
}

double vector3_scale(int input) {
	auto vector = FVector(input, input, input);
	auto v = vector * input;
	return v.X;
}

double vector3_multiply(int input) {
	auto vector = FVector(input, input, input);
	auto v = vector * vector;
	return v.X;
}

double vector3_translate(int input) {
	auto vector = FVector(input, input, input);
	auto v = vector + vector;
	return v.X;
}

double vector3_subtract(int input) {
	auto vector = FVector(input, input, input);
	auto v = vector - vector;
	return v.X;
}

double vector3_length(int input) {
	auto vector = FVector(input, input, input);
	FVector dir;
	float len;

	vector.ToDirectionAndLength(dir, len);
	return len;
}

double vector3_dot(int input) {
	auto vector = FVector(input, input, input);
	auto v = vector.DotProduct(vector, vector);
	return v;
}

Benchmark::Benchmark()
{
}

Benchmark::~Benchmark()
{
}
