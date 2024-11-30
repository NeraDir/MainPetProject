using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyComponent : MonoBehaviour, ITriggerebleInterface
{
    public Transform spawnPosition;

    public Sprite moneySprite;

    public Image moneyImage;

    private void Start()
    {
        spawnPosition = GameObject.Find("SpawnPlace").transform;
    }

    public void Trigger()
    {
        Image spawnedMoney = Instantiate(moneyImage, spawnPosition);
        Vector2 positioner = Camera.main.WorldToScreenPoint(transform.position);
        spawnedMoney.transform.position = positioner;
        Destroy(gameObject);
    }
}
