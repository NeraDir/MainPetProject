using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirPlaneTrigger : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out ITriggerebleInterface triggerObj))
        {
            triggerObj.Trigger();
        }
    }
}
