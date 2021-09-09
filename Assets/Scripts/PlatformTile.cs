using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformTile : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;

    //private MeshRenderer m_oldTex;
    //private MeshRenderer m_newTex;

    //private void Start()
    //{
    //    m_oldTex = GetComponentInChildren<MeshRenderer>();
    //    m_newTex = GetComponentInChildren<MeshRenderer>();
    //}

    private void Update()
    {
        
    }

    public void DeactivateWinningLine()
    {
        this.transform.localScale *= 3;
    }

    public void ActivateWinningLine()
    {
        this.transform.localScale *= 8;
    }
}