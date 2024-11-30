using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class CamManager : MonoBehaviour
{
    public Transform target;

    private Transform CamTransform;

    public Vector3 movementOffset;

    public float speed;

    private void Start()
    {
        CamTransform = transform;
    }

    private void LateUpdate()
    {
        if (target != null)
            CamTransform.position = Vector3.Lerp(CamTransform.position, target.position + movementOffset, speed * Time.deltaTime);
    }
}
