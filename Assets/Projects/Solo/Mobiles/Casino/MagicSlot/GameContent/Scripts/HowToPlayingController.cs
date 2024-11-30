using TMPro;
using UnityEngine;

public class HowToPlayingController : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _displayMagicMenTXT;

    [SerializeField]
    private GameObject _magicMenImage;

    private void Start() 
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }

    public void SetTutorTXT(string inputTXT) 
    {
        _displayMagicMenTXT.text = inputTXT;
        _magicMenImage.SetActive(true);
    }

    public void DisActivateTXT() 
    {
        _displayMagicMenTXT.text = "";
        _magicMenImage.SetActive(false);
    }
}
