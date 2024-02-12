using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProvidePlayer : MonoBehaviour
{
    [SerializeField] private GameObject player;
    public GameObject getPlayer() { return player; }
}
