using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGenerator : MonoBehaviour {
    private class World
    {
        public int Height = 4;
        public int Width = 4;

        public bool HasPitInPosition(int x, int y)
        {
            if (x == 2 && y == 2) return true;
            return false;
        }

        public bool HasWumpusInPosition(int x, int y)
        {
            if (x == 3 && y == 1)
                return true;
            return false;

        }

        public bool HasGoldInPosition(int x, int y)
        {
            if (x == 3 && y == 2) return true;
            return false;
        }
    }

    private World world;
    public GameObject PlatformPrefab;
    public GameObject WorldGameObject;

    public float YPosition = 5.35f;

    private Dictionary<string, GameObject> WumpusPrefabs;
    private Agent _agent;

    [Serializable]
    public struct WumpusObject
    {
        public string Name;
        public GameObject Prefab;
    }
    public WumpusObject[] ObjectPrefabs;

    private void Awake()
    {
        WumpusPrefabs = new Dictionary<string, GameObject>();
        foreach (var pfb in ObjectPrefabs)
        {
            WumpusPrefabs.Add(pfb.Name, pfb.Prefab);
        }
    }

    // Use this for initialization
    void Start () {
        world = new World();
        CreateWorldPlatform();
        _agent = Instantiate(WumpusPrefabs["Agent"], new Vector3(0, YPosition, 0), Quaternion.identity).GetComponent<Agent>();
	}

    void MoveAgent(Vector3 newAgentPos, float moveDuration = 1f)
    {
        _agent.SetLerpPos(newAgentPos, moveDuration);
    }

    void CreateWorldPlatform()
    {
        for (int i = 0; i < world.Height; i++)
        {
            for (int j = 0; j < world.Width; j++)
            {
                var platform = Instantiate(PlatformPrefab, new Vector3(i, 0, j), Quaternion.identity, WorldGameObject.transform);
                platform.name = $"({i},{j})";

                if (world.HasGoldInPosition(i, j))
                    Instantiate(WumpusPrefabs["Treasure"], new Vector3(i, YPosition, j), Quaternion.identity);
                else if (world.HasPitInPosition(i, j))
                    Instantiate(WumpusPrefabs["Pit"], new Vector3(i, YPosition, j), Quaternion.identity);
                else if (world.HasWumpusInPosition(i, j))
                    Instantiate(WumpusPrefabs["Wumpus"], new Vector3(i, YPosition, j), Quaternion.identity);
            }
        }
    }
}
