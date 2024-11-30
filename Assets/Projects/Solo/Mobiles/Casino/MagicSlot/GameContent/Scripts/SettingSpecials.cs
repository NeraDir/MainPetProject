using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.EventSystems;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class SettingSpecials : MonoBehaviour,IPointerClickHandler
{
    public AdditionalSlotController controller;

    public MagicGameController magicGameController;

    public static bool used;

    public int idnexOfItem;

    public delegate void OnUsedChanger();
    public static OnUsedChanger changererd;


    public bool red;
    public bool blue;
    public bool purple;
    public bool randomer;

    public void onClickSetRandom() 
    {
        if (used)
            return;
        if (MagicGameController._freeSpins)
            return;
        if (randomer)
        {
            if (MagicData.RandomChanger <= 0)
                return;
            MagicData.RandomChanger--;
        }
        else if (blue)
        {
            if (MagicData.BlueChanger <= 0)
                return;
            MagicData.BlueChanger--;
        }
        else if (red)
        {
            if (MagicData.RedChanger <= 0)
                return;
            MagicData.RedChanger--;
        }
        else if (purple)
        {
            if (MagicData.PurpleChanger <= 0)
                return;
            MagicData.PurpleChanger--;
        }

        used = true;
        changererd = Used;
    }

    private void Used() 
    {
        controller.SetCustomRandom(Random.Range(0, magicGameController.lines.Length), Random.Range(1, 6), idnexOfItem);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        onClickSetRandom();
    }
}
