// Fill out your copyright notice in the Description page of Project Settings.

#include "Tests.h"
#include <vector>

Tests::Tests()
{
}

Tests::~Tests()
{
}

#include <cmath>
#include <array>

static FVector2D get2DVector(double initial) {
	FVector2D vec = FVector2D(initial, initial);
	return vec;
}

static FVector get3DVector(double initial) {
	FVector vec = FVector(initial, initial, initial);
	return vec;
}

double Tests::sestoft(int input) {
	double x = 1.1 * (double)(input & 0xFF);
	return x * x * x * x * x * x * x * x * x * x * x * x * x * x * x * x * x * x * x * x;
}

double Tests::sestoftMath(int input) {
	double x = 1.1 * (double)(input & 0xFF);
	return pow(x, 20);
}

double Tests::scaleVector2D(int scalar) {
	auto v = get2DVector(1);
	v * scalar;
	return v.Size();
}

double Tests::scaleVector3D(int scalar) {
	auto v = get3DVector(1);
	v * scalar;
	return v.Size();
}

double Tests::multiplyVector2D(int i) {
	auto v1 = get2DVector(1);
	auto v2 = get2DVector(i);

	auto v_mult = v1 * v2;

	return v_mult.Size();
}

double Tests::multiplyVector3D(int i) {
	auto v1 = get3DVector(1);
	auto v2 = get3DVector(i);

	auto v_mult = v1 * v2;

	return v_mult.Size();
}

double Tests::translateVector2D(int i) {
	auto v1 = get2DVector(1);
	v1[0] += i;
	return v1.Size();
}

double Tests::translateVector3D(int i) {
	auto v1 = get3DVector(1);
	v1[0] += i;
	return v1.Size();
}

double Tests::substractVector2D(int i) {
	auto v1 = get2DVector(i);
	auto v2 = get2DVector(1);
	auto v_sub = v1 - v2;
	return v_sub.Size();
}

double Tests::substractVector3D(int i) {
	auto v1 = get3DVector(i);
	auto v2 = get3DVector(1);
	auto v_sub = v1 - v2;
	return v_sub.Size();
}

double Tests::lengthVector2D(int i) {
	auto v1 = get2DVector(i);
	return v1.Size();
}

double Tests::lengthVector3D(int i) {
	auto v1 = get3DVector(i);
	return v1.Size();
}

double Tests::dotproduct2D(int i) {
	auto v1 = get2DVector(1);
	auto v2 = get2DVector(i);

	return FVector2D::DotProduct(v1, v2);
}

double Tests::dotproduct3D(int i) {
	auto v1 = get3DVector(1);
	auto v2 = get3DVector(i);
	return FVector::DotProduct(v1, v2);
}

double Tests::prime100Test(int number) {
	const int realNumber = 100;
	bool A[realNumber + 1];


	for (int i = 2; i < realNumber; i++)
	{
		A[i] = true;
	}

	for (int i = 2; i < sqrt(realNumber); i++)
	{
		if (A[i])
		{
			auto iPow = (int)pow(i, 2);
			auto num = 0;

			for (int j = 0; j < realNumber; j = iPow + num * i)
			{
				A[i] = false;
				num++;
			}
		}
	}

	auto primes = std::vector<int>();
	for (int i = 0; i < (sizeof(A) / sizeof(*A)); i++)
	{
		if (A[i])
			primes.push_back(i);
	}

	return primes.size() & number;
}

double Tests::memTest(int i) {
	std::array<double, 100000> arry;
	return arry.size() + i;
}
