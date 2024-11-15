using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyImageComponent : MonoBehaviour
{
    private Transform MovePlace;

    private void Start()
    {
        MovePlace = GameObject.Find("movePlace").transform;
        StartCoroutine(Move());
    }

    private IEnumerator Move() 
    {
        while (transform.localPosition != MovePlace.localPosition)
        {
            transform.localPosition = Vector2.MoveTowards(transform.localPosition, MovePlace.localPosition, 700 * Time.deltaTime);
            transform.localScale = Vector3.MoveTowards(transform.localScale, new Vector3(0, 0, 0), 1 * Time.deltaTime);
            yield return null;
        }
        MoneyManagerGame.moneysAdder++;
        Destroy(gameObject);
    }
}
