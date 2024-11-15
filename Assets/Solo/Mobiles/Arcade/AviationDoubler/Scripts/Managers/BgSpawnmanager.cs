using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgSpawnmanager : MonoBehaviour
{
    public Transform spawnPosition;

    public GameObject bgObject;

    private IEnumerator Start()
    {
        while (true)
        {
            Instantiate(bgObject, new Vector3(spawnPosition.position.x-9.2f, spawnPosition.position.y - 20, spawnPosition.position.z), Quaternion.Euler(-90,0,0));
            Instantiate(bgObject, new Vector3(spawnPosition.position.x - 9.2f, spawnPosition.position.y - 20, spawnPosition.position.z + 95), Quaternion.Euler(-90, 0, 0));
            yield return new WaitForSeconds(6);
        }
    }
}
