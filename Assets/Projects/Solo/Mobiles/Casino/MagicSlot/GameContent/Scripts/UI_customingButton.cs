using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class UI_customingButton : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private Animator _closingPageAniamtor;

    [SerializeField]
    private GameObject _openingPage;

    [SerializeField]
    private float _waitingTime;

    private bool _clicked;

    public bool _playnig;

    public bool _exiting;

    public bool Showing;

    public string Txt;

    public HowToPlayingController Controller;

    public void OnPointerClick(PointerEventData eventData)
    {
        onClickOpenpage();
    }

    public void onClickOpenpage() 
    {
        if (_clicked || !GetComponent<Button>().enabled)
            return;
        StartCoroutine(openning());
    }

    private IEnumerator openning() 
    {
        _clicked = true;
        _closingPageAniamtor.SetBool("UI_PageIndexer", true);
        yield return new WaitForSeconds(_waitingTime);
        if (_exiting)
            Application.Quit();
        if (_playnig)
            SceneManager.LoadScene("GamingSpins");
        if (Showing && !PlayerPrefs.HasKey(Txt))
        {
            Controller.SetTutorTXT(Txt);
            PlayerPrefs.SetString(Txt, Txt);
        }

        _closingPageAniamtor.gameObject.SetActive(false);
        _openingPage.SetActive(true);
        _clicked = false;
    }
}
