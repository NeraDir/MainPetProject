using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdditionalSlotController : MonoBehaviour
{
    [SerializeField]
    private MagicGameController controller;

    public void SetCustom(int lineIndex,int indexOfItem) 
    {
        foreach (var item in controller.lines[lineIndex].wordLine)
        {
            item.wordContainer.SetParagon(indexOfItem);
        }
    }

    public void SetCustomRandom(int lineIndex,int indexOfSlot, int indexOfItem)
    {
        controller.lines[lineIndex].wordLine[indexOfSlot].wordContainer.SetParagon(indexOfItem);
    }
}
