using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombComponent : MonoBehaviour, ITriggerebleInterface
{
    public GameObject boomEffect;

    private Animator animatorer;

    private bool triggered;

    private AirPlaneComponent mainComponent;

    public void Trigger()
    {
        if (triggered)
            return;
        triggered = true;
        animatorer = GetComponent<Animator>();
        AirPlaneComponent[] airles = FindObjectsOfType<AirPlaneComponent>();
        foreach (var item in airles)
        {
            if (item.TOLKOYA)
            {
                mainComponent = item;
                break;
            }
        }
        mainComponent.OnTakeDamage();
        animatorer.enabled = false;
        Instantiate(boomEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
