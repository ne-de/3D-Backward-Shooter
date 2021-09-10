using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalTileBehavior : MonoBehaviour
{
    //EVENTS
    public delegate void OnWinningLineCrossedDelegate();
    public static event OnWinningLineCrossedDelegate OnWinningLineCrossed;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            OnWinningLineCrossed();
        }
    }
}
