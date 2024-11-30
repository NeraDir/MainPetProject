using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class BuyContainer : MonoBehaviour,IPointerClickHandler
{
    [SerializeField]
    private TMP_Text _priceShow;

    public float price;

    public bool red;
    public bool blue;
    public bool purple;
    public bool randomer;

    private void LateUpdate()
    {
        _priceShow.text = price.ToString();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (MagicData.CoinsCount >= price)
        {
            if (randomer)
                MagicData.RandomChanger++;
            else if(blue)
                MagicData.BlueChanger++;
            else if(red)
                MagicData.RedChanger++;
            else if(purple)
                MagicData.PurpleChanger++;

            MagicData.CoinsCount -= price;
        }
    }
}
