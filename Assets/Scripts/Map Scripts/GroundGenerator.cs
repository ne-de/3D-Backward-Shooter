using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlatformTile))]
public class GroundGenerator : MonoBehaviour
{
    //PUBLIC
    public Camera mainCamera;
    public Transform startPoint; //Point from where ground tiles will start
    public PlatformTile tilePrefab;
    public static GroundGenerator instance;

    public int tilesToSpawn = 15; //How many tiles should be pre-spawned

    //PRIVATE
    private List<PlatformTile> m_spawnedTiles = new List<PlatformTile>();
    private int tilesToWinningLine;

    void Start()
    {
        instance = this;

        Vector3 spawnPosition = startPoint.position;

        int tilesToWinningLineTemp = tilesToWinningLine; //local variable to winning tile

        for (int i = 0; i < tilesToSpawn; i++)
        {
            spawnPosition -= tilePrefab.startPoint.localPosition;
            PlatformTile spawnedTile = Instantiate(tilePrefab, spawnPosition, Quaternion.identity);


            spawnPosition = spawnedTile.endPoint.position;
            spawnedTile.transform.SetParent(transform);
            m_spawnedTiles.Add(spawnedTile);
            tilesToWinningLineTemp++; //tile counter until winning tile

            if (tilesToWinningLineTemp >= tilesToSpawn) //when we get to the the prespawn count, next tile is the winning tile
            {
                spawnedTile.ActivateWinningLine();
            }
        }        
    }
}