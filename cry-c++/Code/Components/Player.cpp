#include "StdAfx.h"
#include "Player.h"

#include <CryRenderer/IRenderAuxGeom.h>

void CPlayerComponent::Initialize()
{
	// Create the camera component, will automatically update the viewport every frame
	m_pCameraComponent = m_pEntity->GetOrCreateComponent<Cry::DefaultComponents::CCameraComponent>();
	// Get the input component, wraps access to action mapping so we can easily get callbacks when inputs are triggered
	m_pInputComponent = m_pEntity->GetOrCreateComponent<Cry::DefaultComponents::CInputComponent>();

	m_pInputComponent->RegisterAction("player", "benchmark", [this](int activationMode, float value) { HandleInputFlagChange((TInputFlags)EInputFlag::MoveLeft, activationMode);  });
	m_pInputComponent->BindAction("player", "benchmark", eAID_KeyboardMouse, EKeyId::eKI_Space);

	gEnv->pLog->SetFileName("benchmark.log");

	Revive();
}

uint64 CPlayerComponent::GetEventMask() const
{
	return ENTITY_EVENT_BIT(ENTITY_EVENT_START_GAME) | ENTITY_EVENT_BIT(ENTITY_EVENT_UPDATE);
}

void CPlayerComponent::ProcessEvent(const SEntityEvent& event)
{
	switch (event.event)
	{
	case ENTITY_EVENT_START_GAME:
	{
		// Revive the entity when gameplay starts
		Revive();
	}
	break;
	case ENTITY_EVENT_UPDATE:
	{
		SEntityUpdateContext* pCtx = (SEntityUpdateContext*)event.nParam[0];

		// Check input to calculate local space velocity
		if (m_inputFlags & (TInputFlags)EInputFlag::MoveLeft)
		{
			gEnv->pLog->LogToFile("Starting benchmark");
			gEnv->pLog->LogToFile("Message\tMean\tDeviation\tCount");

			Benchmark8("Scale2D", scaleVector2D, 5, 250.0);
			Benchmark8("Scale3D", scaleVector3D, 5, 250.0);
			Benchmark8("Multiply2D", multiplyVector2D, 5, 250.0);
			Benchmark8("Multiply3D", multiplyVector3D, 5, 250.0);
			Benchmark8("Translate2D", translateVector2D, 5, 250.0);
			Benchmark8("Translate3D", translateVector3D, 5, 250.0);
			Benchmark8("Substract2D", substractVector2D, 5, 250.0);
			Benchmark8("Substract3D", substractVector3D, 5, 250.0);
			Benchmark8("Length2D", lengthVector2D, 5, 250.0);
			Benchmark8("Length3D", lengthVector3D, 5, 250.0);
			Benchmark8("DotProduct2D", dotproduct2D, 5, 250.0);
			Benchmark8("DotProduct3D", dotproduct3D, 5, 250.0);
			Benchmark8("Primes100", prime100Test, 5, 250.0);
			Benchmark8("Memory", memTest, 5, 250.0);
			Benchmark8("Sestoft", sestoft, 5, 250.0);

			gEnv->pLog->LogToFile("Benchmark done");
		}
	}
	break;
	}
}

void CPlayerComponent::Revive()
{
	// Set player transformation, but skip this in the Editor
	if (!gEnv->IsEditor())
	{
		Vec3 playerScale = Vec3(1.f);
		Quat playerRotation = IDENTITY;

		// Position the player in the center of the map
		const float heightOffset = 20.f;
		float terrainCenter = gEnv->p3DEngine->GetTerrainSize() / 2.f;
		float height = gEnv->p3DEngine->GetTerrainZ(terrainCenter, terrainCenter);
		Vec3 playerPosition = Vec3(terrainCenter, terrainCenter, height + heightOffset);

		m_pEntity->SetWorldTM(Matrix34::Create(playerScale, playerRotation, playerPosition));
	}

	// Unhide the entity in case hidden by the Editor
	GetEntity()->Hide(false);

	// Reset input now that the player respawned
	m_inputFlags = 0;
	m_mouseDeltaRotation = ZERO;
}

void CPlayerComponent::HandleInputFlagChange(TInputFlags flags, int activationMode, EInputFlagType type)
{
	switch (type)
	{
	case EInputFlagType::Hold:
	{
		if (activationMode == eIS_Released)
		{
			m_inputFlags &= ~flags;
		}
		else
		{
			m_inputFlags |= flags;
		}
	}
	break;
	case EInputFlagType::Toggle:
	{
		if (activationMode == eIS_Released)
		{
			// Toggle the bit(s)
			m_inputFlags ^= flags;
		}
	}
	break;
	}
}