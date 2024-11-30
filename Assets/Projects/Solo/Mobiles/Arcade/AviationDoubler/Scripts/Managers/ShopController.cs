using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    public int indexAirPlane;

    public int planePrice;

    public TMP_Text displayPrice;

    public Sprite defaultSprite;

    public Sprite buySprite;

    public Image buttonImage;

    private int buyedPlane 
    {
        get 
        {
            if (PlayerPrefs.HasKey("BuyedPlane" + indexAirPlane))
            {
                return PlayerPrefs.GetInt("BuyedPlane" + indexAirPlane);
            }
            return 0;
        }
        set 
        {
            PlayerPrefs.SetInt("BuyedPlane" + indexAirPlane, value);
        }
    }

    private void Start()
    {
        if (buyedPlane != 0)
        {
            buttonImage.sprite = defaultSprite;
            if (PlayerInfo.playerPlaneIndex == indexAirPlane)
            {
                displayPrice.text = "EQUIPED";
            }
            else
            {
                displayPrice.text = "EQUIP";
            }
        }
        else
        {
            buttonImage.sprite = buySprite;
            displayPrice.text = planePrice.ToString();
        }
    }

    public void onClickBuyPlane() 
    {
        if (buyedPlane != 0) 
        {
            Equip();
        }
        else
        {
            if (PlayerInfo.playerMoney >= planePrice)
            {
                PlayerInfo.playerMoney -= planePrice;
                buyedPlane = 1;
                Equip();
            }
            else
            {
                Handheld.Vibrate();
            }
        }
    }

    public void UnEquip() 
    {
        if (buyedPlane != 0)
        {
            buttonImage.sprite = defaultSprite;
            displayPrice.text = "EQUIP";
        } 
    }

    private void Equip() 
    {
        foreach (var item in UiController.shopControllers)
        {
            item.UnEquip();
        }
        buttonImage.sprite = defaultSprite;
        PlayerInfo.playerPlaneIndex = indexAirPlane;
        displayPrice.text = "EQUIPED";
    }
}
