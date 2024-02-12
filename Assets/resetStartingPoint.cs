using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetStartingPoint : MonoBehaviour
{
    [SerializeField] private GameObject startingPoint;
    [SerializeField] private GameObject player;

    public void resetPosition()
    {
        player.transform.position = startingPoint.transform.position;
        player.transform.rotation = startingPoint.transform.rotation;
    }
}
