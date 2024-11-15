using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UiController : MonoBehaviour
{
    public GameObject WhatCanPaly;

    public static List<ShopController> shopControllers = new List<ShopController>();

    public List<ShopController> planesShopContainers;

    public TMP_Text dispalyPlayerMoney;

    private void Start()
    {
        shopControllers = planesShopContainers;
        if (!PlayerPrefs.HasKey("WhatCanPlay"))
        {
            planesShopContainers[0].onClickBuyPlane();
            WhatCanPaly.SetActive(true);
            PlayerPrefs.SetInt("WhatCanPlay", 1);
        }
    }

    private void LateUpdate()
    {
        dispalyPlayerMoney.text = PlayerInfo.playerMoney.ToString();
    }

    public void oNClickPlay() 
    {
        SceneManager.LoadScene("Gaming");
    }

    public void onClickExit() 
    {
        Application.Quit();
    }
}
