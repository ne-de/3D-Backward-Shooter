using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFollow : MonoBehaviour
{
    //PUBLIC
    public GameObject player;

    //PRIVATE
    private Vector3 offset;

    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    void LateUpdate()
    {
        transform.position = new Vector3(0, 0, player.transform.position.z) + offset;
    }
}
