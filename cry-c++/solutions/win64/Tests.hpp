#include <cmath>
#include <array>
#include "CryMath/Cry_Vector2.h"
#include "CryMath/Cry_Vector3.h"

#ifndef NATIVE_TESTS_H
#define NATIVE_TESTS_H

static double sestoft(int input) {
	double x = 1.1 * (double)(input & 0xFF);
	return x * x * x * x * x * x * x * x * x * x * x * x * x * x * x * x * x * x * x * x;
}

static double sestoftMath(int input) {
	double x = 1.1 * (double)(input & 0xFF);
	return pow(x, 20);
}

static double scaleVector2D(int scalar) {
	Vec2d v{ 1, 1 };
	Vec2d v2 { v.x * scalar, v.y * scalar };
	return v2.GetLength();
}

static double scaleVector3D(int scalar) {
	Vec3d v{ 1, 1, 1 };
	v *= scalar;
	return v.GetLength();
}

static double multiplyVector2D(int i) {
	Vec2d v1{ 1, 1 };
	Vec2d v2{ (double) i, (double) i };

	auto v = v1 * v2;

	return v;
}

static double multiplyVector3D(int i_org) {
	Vec3d v1{ 1, 1, 1 };
	auto i = (double)i_org;
	Vec3d v2{ i, i, i };

	return v1 * v2;
}

static double translateVector2D(int i) {
	Vec2d v1{ 1, 1 };
	Vec2d v3{ v1.x + i, v1.y + i };
	return v3.GetLength();
}

static double translateVector3D(int i) {
	Vec3d v1{ 1, 1, 1 };
	Vec3d v3{ v1.x + i, v1.y + i, v1.z + i};
	return v1.GetLength();
}

static double substractVector2D(int i_org) {
	auto i = (double)i_org;
	Vec2d v1{ i, i };
	Vec2d v2{ 1, 1 };
	v1 -= v2;
	return v1.GetLength();
}

static double substractVector3D(int i_org) {
	auto i = (double)i_org;
	Vec3d v1{ i, i, i };
	Vec3d v2{ 1, 1, 1 };
	v1 -= v2;
	return v1.GetLength();
}

static double lengthVector2D(int i_org) {
	auto i = (double)i_org;
	Vec2d v1{ i, i };
	return v1.GetLength();
}

static double lengthVector3D(int i_org) {
	auto i = (double)i_org;
	Vec3d v1{ i, i, i };
	return v1.GetLength();
}

static double dotproduct2D(int i_org) {
	auto i = (double)i_org;
	Vec2d v1{ 1, 1 };
	Vec2d v2{ i, i };
	return v1.Dot(v2);
}

static double dotproduct3D(int i_org) {
	auto i = (double)i_org;
	Vec3d v1{ 1, 1, 1 };
	Vec3d v2{ i, i, i };
	return v1.Dot(v2);
}

static double prime100Test(int number) {
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

	//Previously primes.size() & number
	double ret = (double) (primes[primes.size() - 1] & number);
	return ret;
}

static double memTest(int i) {
	double d = (double)i;
	//Previously uninitialised
	std::array<double, 100000> arry{0};
	return (double) (arry.size() & i);
}

/**/

#endif //NATIVE_TESTS_H

