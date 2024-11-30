using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class ShowerContainer : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private Image _settingImage;

    private Sprite _mySprite;

    [SerializeField]
    private GameObject _showerPage;

    private void Awake()
    {
        _mySprite = GetComponent<Image>().sprite;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        _settingImage.sprite = _mySprite;
        _showerPage.SetActive(true);
    }

    public void onClickCloseShowerPage() 
    {
        _showerPage.SetActive(false);
    }
}
