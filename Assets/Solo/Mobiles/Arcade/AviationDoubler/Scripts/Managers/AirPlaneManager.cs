using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirPlaneManager : MonoBehaviour
{
    public GameObject[] airPlaneModels;

    private void Start()
    {
        airPlaneModels[PlayerInfo.playerPlaneIndex].SetActive(true);
    }
}
