using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirPlaneComponent : MonoBehaviour
{
    public List<StarComponent> airPlaneStars = new List<StarComponent>();

    public GameObject gameOverPanel;

    public int defaultPartCount;
    public float motionsSpeed = 5;
    public float steerRotateSpeed = 180;
    public int distanceBetwenPart = 10;

    private List<Vector3> headPositionsData = new List<Vector3>();

    public GameObject starPref;

    public bool TOLKOYA;

    private void Start()
    {
        if(TOLKOYA)
            SpawnFirstStar();
        StartCoroutine(PositionsDataCleaner());
    }

    public void SpawnFirstStar()
    {
        for (int i = 0; i < defaultPartCount; i++)
        {
            GameObject part = Instantiate(starPref);
            part.GetComponent<StarComponent>().triggered = true;
            airPlaneStars.Add(part.GetComponent<StarComponent>());
        }
    }

    private IEnumerator PositionsDataCleaner()
    {
        while (true)
        {
            if (headPositionsData.Count > airPlaneStars.Count + 3000)
            {
                for (int i = 0; i < 50; i++)
                {
                    headPositionsData.RemoveAt(headPositionsData.Count - 1);
                }
            }
            yield return null;
        }
    }

    public void OnTakeDamage() 
    {
        StarComponent starTemp = airPlaneStars[airPlaneStars.Count - 1];
        airPlaneStars.Remove(airPlaneStars[airPlaneStars.Count - 1]);
        Destroy(starTemp.gameObject);
        if (airPlaneStars.Count <= 0)
        {
            gameOverPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void AddNewStar(GameObject star) 
    {
        if (airPlaneStars.Count > 0)
        {
            Transform futurePartSpawnPoint = airPlaneStars[airPlaneStars.Count - 1].transform;
            GameObject part = Instantiate(star, futurePartSpawnPoint.position, futurePartSpawnPoint.rotation);
            airPlaneStars.Add(part.GetComponent<StarComponent>());
        }
        else
        {
            airPlaneStars.Add(star.GetComponent<StarComponent>());
        }
    }

    private void LateUpdate()
    {
        headPositionsData.Insert(0, transform.position);
        int idx = 0;
        if (airPlaneStars.Count > 0)
        {
            foreach (var part in airPlaneStars)
            {
                Vector3 point = headPositionsData[Mathf.Clamp(idx * distanceBetwenPart, 0, headPositionsData.Count - 1)];
                Vector3 moveDirection = point - part.transform.position;
                part.transform.position += moveDirection * motionsSpeed * Time.deltaTime;
                part.transform.LookAt(point);
                idx++;
            }
        }
        
    }
}
