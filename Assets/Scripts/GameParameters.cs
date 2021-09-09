using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameParameters : MonoBehaviour
{
    //Player variables
    private float _playerMovementSpeed;
    private float _playerStrafeSpeed;
    private float _playerRateOfFire;

    //AI variables
    private int _mobCrowdCount;
    private float _enemyHealth;
    private float _mobSpeed;

    //Tiling & Walls variables
    [SerializeField]
    private float _tilingSpeed = 15;
    //private bool _endLine;
    private float _wallSpeedDamp;

    //============================================//

    private void OnValidate()
    {
        TilingSpeed = _tilingSpeed;
    }

    private void Update()
    {
        Debug.Log(_tilingSpeed);
    }

    //Player Get Set
    public float PlayerMovementSpeed
    {
        get { return _playerMovementSpeed; }
        set { _playerMovementSpeed = value; }
    }

    public float PlayerStrafeSpeed
    {
        get { return _playerStrafeSpeed; }
        set { _playerStrafeSpeed = value; }
    }

    public float PlayerRateOfFire
    {
        get { return _playerRateOfFire; }
        set { _playerRateOfFire = value; }
    }

    //AI Get Set
    public int MobCrowdCount
    {
        get { return _mobCrowdCount; }
        set { _mobCrowdCount = value; }
    }
    public float EnemyHealth
    {
        get { return _enemyHealth; }
        set { _enemyHealth = value; }
    }

    public float MobSpeed
    {
        get { return _mobSpeed; }
        set { _mobSpeed = value; }
    }

    //Tiling & Walls Get Set
    public float TilingSpeed
    {
        get { return _tilingSpeed; }
        set { _tilingSpeed = value; }
    }

    public float WallSpeedDamp
    {
        get { return _wallSpeedDamp; }
        set { _wallSpeedDamp = value; }
    }
}