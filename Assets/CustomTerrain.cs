using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(Terrain))]
public class CustomTerrain : MonoBehaviour
{
    public Vector3 initial = new Vector3(1000, 600, 1000);

    public DiamondSquare terrainMap;

    Terrain terrain;
    TerrainData tData;

    void Start()
    {
        terrain = GetComponent<Terrain>();
        tData = terrain.terrainData;

        transform.position = new Vector3(-1 * initial.x / 2, 0, -1*initial.y / 2);

        Generate();
        Debug.Log("testing");
    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Generate();
        }
    }

    void Generate()
    {
        terrainMap = new DiamondSquare(129);

        tData.heightmapResolution = terrainMap.size;

        tData.SetHeights(0, 0, terrainMap.heights);

        tData.size = new Vector3(initial.x, initial.y, initial.z);
    }

}
