using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirPlaneMovement : MonoBehaviour
{
    private Transform airPlanetransform;

    public float speed;

    public Transform moveToForwardTransform;

    private Coroutine movingCoroutine;

    public GameObject clouderEffect;

    public Transform spawnPositionOfEffect;

    public float spawnTime;

    private void Start()
    {
        airPlanetransform = transform;
        StartCoroutine(SpawnEffect());
    }

    public void DontMove() 
    {
        StopCoroutine(movingCoroutine);
    }

    private IEnumerator SpawnEffect() 
    {
        while (true)
        {
            Instantiate(clouderEffect, spawnPositionOfEffect.position, Quaternion.Euler(180,0,0));
            yield return new WaitForSeconds(spawnTime);
        }
    }

    private IEnumerator MoveToForwardCoroutine() 
    {
        while (true)
        {
            airPlanetransform.position = Vector3.MoveTowards(airPlanetransform.position,new Vector3(airPlanetransform.position.x, airPlanetransform.position.y, moveToForwardTransform.position.z),speed * Time.deltaTime);
            yield return null;
        }
    }

    public void Move() 
    {
        movingCoroutine = StartCoroutine(MoveToForwardCoroutine());
    }
}
