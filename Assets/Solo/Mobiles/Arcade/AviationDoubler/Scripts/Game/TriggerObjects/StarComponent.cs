using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarComponent : MonoBehaviour, ITriggerebleInterface
{
    public bool triggered;

    public void Trigger()
    {
        if (triggered)
            return;
        triggered = true;
        FindObjectOfType<AirPlaneComponent>().AddNewStar(this.gameObject);
        Destroy(gameObject);
    }
}
