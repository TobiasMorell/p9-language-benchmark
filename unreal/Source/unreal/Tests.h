// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"

/**
 * 
 */
class UNREAL_API Tests
{
public:
	Tests();
	~Tests();
	static double sestoft(int input);
	static double sestoftMath(int input);
	static double scaleVector2D(int scalar);
	static double scaleVector3D(int scalar);
	static double multiplyVector2D(int i);
	static double multiplyVector3D(int i);
	static double translateVector2D(int i);
	static double translateVector3D(int i);
	static double substractVector2D(int i);
	static double substractVector3D(int i);
	static double lengthVector2D(int i);
	static double lengthVector3D(int i);
	static double dotproduct2D(int i);
	static double dotproduct3D(int i);
	static double prime100Test(int number);
	static double memTest(int i);
};
