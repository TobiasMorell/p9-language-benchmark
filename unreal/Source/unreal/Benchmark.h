// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "GameFramework/PlayerController.h"
#include "Benchmark.generated.h"

UCLASS()
class UNREAL_API ABenchmark : public APlayerController
{
	GENERATED_BODY()
	
public:	
	// Sets default values for this actor's properties
	ABenchmark();
	// Called every frame
	virtual void Tick(float DeltaTime) override;

protected:
	// Called when the game starts or when spawned
	virtual void BeginPlay() override;
};
