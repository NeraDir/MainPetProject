using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    private HowToPlayingController hwpController;

    [SerializeField]
    private GameObject hwpObject;

    [SerializeField]
    private GameObject menuing;

    [SerializeField]
    private Button[] buttons;

    [SerializeField]
    private TMP_Text _upgradePrice;

    public static int UpgradePrice
    {
        get
        {
            if (PlayerPrefs.HasKey("WoothingPlayerUpgradePriceKey"))
            {
                return PlayerPrefs.GetInt("WoothingPlayerUpgradePriceKey");
            }
            return 10;
        }
        set
        {
            PlayerPrefs.SetInt("WoothingPlayerUpgradePriceKey", value);
        }
    }

    private void Awake()
    {
        if (!PlayerPrefs.HasKey("magicOpenedHwp"))
        {
            hwpController.SetTutorTXT("Welcome To TheWooSpins! \nFor First Click To ? Button");
            foreach (var item in buttons)
            {
                item.enabled = false;
            }
            PlayerPrefs.SetInt("magicOpenedHwp", 1);
        }
    }

    private void LateUpdate()
    {
        _upgradePrice.text = UpgradePrice.ToString();
    }

    public void onClickUpgrade() 
    {
        if (MagicData.CoinsCount >= UpgradePrice)
        {
            MagicData.MaxValueChangers++;
            MagicData.CoinsCount -= UpgradePrice;
            UpgradePrice *= 2;
        }
    }
}
