using UnityEngine.EventSystems;
using UnityEngine;

public class WinningPanel : MonoBehaviour, IPointerClickHandler
{
    public bool isBonusPage;

    public bool isEndingpage;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!MagicGameController._freeSpins)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnDisable()
    {
        if (isBonusPage)
        {
            MagicGameController.BeginBonusMode();
        }
        if (!isEndingpage)
        {
            MagicData.CoinsCount += MagicGameController.magicWinValue;
            MagicGameController.bonusWinValue += MagicGameController.magicWinValue;
        }
    }
}
