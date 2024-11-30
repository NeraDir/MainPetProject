using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsFolowManager : MonoBehaviour
{
    public Transform target;

    public Vector3 direction;

    public float speed;

    private void LateUpdate()
    {
        transform.position += new Vector3((target.position.x - transform.position.x) * direction.x, 0 , (target.position.z - transform.position.z) * direction.z) * speed * Time.deltaTime;
    }
}
