using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class InteractiveObjectsSpawnManager : MonoBehaviour
{
    public Transform[] positonsSpawn;

    public GameObject[] objecter;

    public GameObject star;

    private IEnumerator Start()
    {
        while (true)
        {
            if (Random.Range(0,60) > 55)
            {
                Instantiate(star, positonsSpawn[1].position, Quaternion.identity);
                Instantiate(objecter[Random.Range(0, objecter.Length)], positonsSpawn[0].position, Quaternion.identity);
                Instantiate(objecter[Random.Range(0,objecter.Length)], positonsSpawn[2].position, Quaternion.identity);
            }
            else
            {
                if (Random.Range(0,2) != 0)
                {
                    Instantiate(objecter[1], positonsSpawn[0].position, Quaternion.identity);
                    Instantiate(objecter[0], positonsSpawn[1].position, Quaternion.identity);
                    Instantiate(objecter[1], positonsSpawn[2].position, Quaternion.identity);
                }
                else
                {
                    Instantiate(objecter[0], positonsSpawn[0].position, Quaternion.identity);
                    Instantiate(objecter[1], positonsSpawn[1].position, Quaternion.identity);
                    Instantiate(objecter[0], positonsSpawn[2].position, Quaternion.identity);
                }
            }
            yield return new WaitForSeconds(0.7f);
        }
    }
}

