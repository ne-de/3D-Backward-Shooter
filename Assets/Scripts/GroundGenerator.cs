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
    public static float TilingReferenceSpeed;
    public float tilingSpeed = 10;
    public float tilingSpeedDampened = 5;
    public int tilesToPreSpawn = 15; //How many tiles should be pre-spawned
    public int tilesBeforeGoalLine = 14;

    //PRIVATE
    private List<PlatformTile> m_spawnedTiles = new List<PlatformTile>();
    private int m_tileCount;

    private void Awake()
    {
        TilingReferenceSpeed = tilingSpeed;
    }

    void Start()
    {
        instance = this;

        Vector3 spawnPosition = startPoint.position;

        int tilesBeforeGoalLineTmp = tilesBeforeGoalLine;

        for (int i = 0; i < tilesToPreSpawn; i++)
        {
            spawnPosition -= tilePrefab.startPoint.localPosition;
            PlatformTile spawnedTile = Instantiate(tilePrefab, spawnPosition, Quaternion.identity);

            //if (tilesBeforeGoalLineTmp > 0)
            //{
            //    spawnedTile.DeactivateWinningLine();
            //    tilesBeforeGoalLineTmp--;
            //}
            //else
            //{
            //    spawnedTile.ActivateWinningLine();
            //}

            spawnPosition = spawnedTile.endPoint.position;
            spawnedTile.transform.SetParent(transform);
            m_spawnedTiles.Add(spawnedTile);
        }

        PlatformWall.OnWallContact += TilingSpeedDampener;
        PlatformWall.OnWallClear += TilingSpeedRestorer;
    }

    void Update()
    {
        // Move the object upward in world space x unit/second.
        //Increase speed the higher score we get
        if (!GameManager.GameOver && GameManager.GameStarted)
        {
            transform.Translate(-m_spawnedTiles[0].transform.forward * Time.deltaTime * tilingSpeed, Space.World);
        }

        //if (mainCamera.WorldToViewportPoint(m_spawnedTiles[0].endPoint.position).z < 0)
        //{
        //    //Move the tile to the front if it's behind the Camera
        //    PlatformTile tileTmp = m_spawnedTiles[0];
        //    m_spawnedTiles.RemoveAt(0);
        //    tileTmp.transform.position = m_spawnedTiles[m_spawnedTiles.Count - 1].endPoint.position - tileTmp.startPoint.localPosition;
        //    m_spawnedTiles.Add(tileTmp);
        //    m_tileCount++;
        //}

        //Debug.Log(m_tileCount);
    }

    void TilingSpeedDampener()
    {
        tilingSpeed = tilingSpeedDampened;
    }

    void TilingSpeedRestorer()
    {
        tilingSpeed = TilingReferenceSpeed;
    }

    private void OnDisable()
    {
        PlatformWall.OnWallContact -= TilingSpeedDampener;
        PlatformWall.OnWallClear -= TilingSpeedRestorer;
    }
}