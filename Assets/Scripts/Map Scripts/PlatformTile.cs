using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformTile : MonoBehaviour
{    
    public Transform startPoint;
    public Transform endPoint;

    public GameObject tileGraphic;
    public Material winningTileMat;
    public BoxCollider winningLineCollider;

    public void ActivateWinningLine()
    {
        tileGraphic.GetComponent<MeshRenderer>().material = winningTileMat;
        winningLineCollider.enabled = true;  
    }
}