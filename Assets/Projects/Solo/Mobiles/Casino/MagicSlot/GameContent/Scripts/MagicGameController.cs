using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using TMPro;
using UnityEngine.SceneManagement;

public class MagicGameController : MonoBehaviour
{
    public static int MagicBet;

    public static bool turningpages;

    public static float magicWinValue;

    [SerializeField]
    private Animator animator;

    public MagicLine[] lines;

    [SerializeField]
    private Book _book;

    public LineRenderer lineRenderer;

    [SerializeField]
    private TMP_Text _betValue;

    [SerializeField]
    private TMP_Text _bonusPrice;

    public static int MagicBonusprice;

    [SerializeField]
    private TMP_Text _winningValueShowe;

    [SerializeField]
    private GameObject _winningPage;

    public static GameObject WinningPages;

    [SerializeField]
    private WordTriggerer[] _wordTriggers;

    public List<WordTriggerer> _wordTriggerer = new List<WordTriggerer>();

    [SerializeField]
    private GameObject _bonusWin;

    [SerializeField]
    private GameObject _freeSpinsButton;

    [SerializeField]
    private GameObject _freeSpinsCounter;

    [SerializeField]
    private TMP_Text _showFreeSpins;

    [SerializeField]
    private GameObject _tutoringObject;

    public static bool GetEnd(bool value) 
    {
        return value;
    }

    public static float bonusWinValue;

    [SerializeField]
    private GameObject _bonusEndpage;

    [SerializeField]
    private TMP_Text _BonusWinvalueDisplayer;

    public delegate void OnBonus();
    public static event OnBonus onBonus;

    public delegate void BeginBonus();
    public static event BeginBonus onBeginBonus;
    private int _freeSpinsCount = 10;

    public static bool _freeSpins = false;

    public static void CheckBonus() 
    {
        if (onBonus != null)
        {
            onBonus();
        }
    }

    public static void BeginBonusMode() 
    {
        if (onBeginBonus != null)
        {
            onBeginBonus();
        }
    }

    private void Start()
    {
        if (!PlayerPrefs.HasKey("GAMINGSPINNINGTUTORING"))
        {
            _tutoringObject.SetActive(true);
            PlayerPrefs.SetInt("GAMINGSPINNINGTUTORING", 1);
        }

        WinningPages = _winningPage;
        _freeSpinsButton.SetActive(true);
        _freeSpinsCounter.SetActive(false);
        onBonus += MagicGameController_onBonus;
        onBeginBonus += MagicGameController_onBeginBonus;
        MagicBet = 10;
    }

    private void MagicGameController_onBeginBonus()
    {
        StartCoroutine(FreeSpinsMode());
    }

    private IEnumerator FreeSpinsMode() 
    {
        _freeSpinsButton.SetActive(false);
        _freeSpinsCounter.SetActive(true);
        bonusWinValue = 0;
        _freeSpinsCount = 10;
        _freeSpins = true;
        while (_freeSpinsCount > -1)
        {
            ClickSpin();
            while (turningpages)
                yield return null;
            if (magicWinValue > 0)
            {
                while (!_winningPage.activeInHierarchy)
                    yield return null;
            }
            _freeSpinsCount--;
        }
        _bonusEndpage.SetActive(true);
        _freeSpins = false;
        _freeSpinsButton.SetActive(true);
        _freeSpinsCounter.SetActive(false);
        StopAllCoroutines();
    }

    public void BuyFreeSpins() 
    {
        if (MagicBonusprice > MagicData.CoinsCount)
            return;
        MagicData.CoinsCount -= MagicBonusprice;
        _bonusWin.SetActive(true);
    }

    private void ClickSpin() 
    {
        if (turningpages)
            return;
        if (!_freeSpins)
            MagicData.CoinsCount -= MagicBet;

        _wordTriggerer.Clear();
        _winningPage.SetActive(false);
        magicWinValue = 0;
        foreach (var item in lines)
        {
            foreach (var line in item.wordContainer)
            {
                line.wordContainer.GetComponent<Animator>().SetBool("WordState", false);
            }
        }
        animator.enabled = true;
        turningpages = true;
        foreach (var item in lines)
        {
            item.Reset();
        }
    }

    private void MagicGameController_onBonus()
    {
        for (int i = 0; i < _wordTriggers.Length; i++)
        {
            if (_wordTriggers[i].wordContainer.GetWordIndex() == 4)
            {
                _wordTriggerer.Add(_wordTriggers[i]);
            }
        }
        if (_wordTriggerer.Count >= 3)
        {
            _winningPage.SetActive(false);
            _bonusWin.SetActive(true);
            _winningPage.SetActive(false);
        }
    }

    private void OnDestroy()
    {
        onBonus -= MagicGameController_onBonus;
        onBeginBonus -= MagicGameController_onBeginBonus;
    }

    private int GetBonusPrice() 
    {
        MagicBonusprice = MagicBet * 66;
        return MagicBonusprice;
    }

    private void LateUpdate()
    {
        _bonusPrice.text = GetBonusPrice().ToString();
        _betValue.text = MagicBet.ToString();
        _winningValueShowe.text = _book.TempWinningValue.ToString();
        _showFreeSpins.text = _freeSpinsCount.ToString();
        _BonusWinvalueDisplayer.text = bonusWinValue.ToString("0");
    }

    public void SettingBetValue(int value) 
    {
        if (turningpages)
            return;
        if (MagicBet + value < 10)
            return;
        if (MagicBet + value > 1000)
            return;
        if (_freeSpins)
            return;
        MagicBet += value;
    }

    public void OnClickTurnPage() 
    {
        if (MagicData.CoinsCount < MagicBet)
        {
            return;
        }
        if (_freeSpins)
            return;
        ClickSpin();

    }

    public void onClickOpenMenu() 
    {
        SceneManager.LoadScene("Scenemenu");
    }

    [Serializable]
    public class MagicLine 
    {
        public string LineName;

        public List<WordTriggerer> wordLine = new List<WordTriggerer>();

        public List<WordTriggerer> wordContainer = new List<WordTriggerer>();

        public List<Vector3> wordPisitions = new List<Vector3>();

        public List<WordTriggerer> lienrs = new List<WordTriggerer>();

        public LineRenderer linePrefab;

        public LineRenderer _lineRenderer;

        public MagicGameController magicGameController;
        public Coroutine aniamtionCoroutine;


        public void SetAnimations()
        {
            foreach (var line in wordContainer)
            {
                line.wordContainer.GetComponent<Animator>().SetBool("WordState", true);
            }
        }

        public void GetLines() 
        {
            if (magicGameController == null)
            {
                magicGameController = FindObjectOfType<MagicGameController>();
            }
            if (_lineRenderer == null)
            {
                _lineRenderer = Instantiate(linePrefab);
            }

            for (var i = 0; i < wordLine.Count; i ++)
            {
                if (wordContainer.Count <= 0)
                {
                    wordContainer.Add(wordLine[i]);
                    wordPisitions.Add(wordLine[i].gameObject.transform.position);
                }
                else
                {
                    if ((wordLine[i].wordContainer.GetWordIndex() == (wordContainer[0].wordContainer.GetWordIndex())) || (wordLine[i].wordContainer.GetWordIndex() == 3))
                    {
                        wordContainer.Add(wordLine[i]);
                        wordPisitions.Add(wordLine[i].gameObject.transform.position);
                    }
                    else if (wordLine[i].wordContainer.GetWordIndex() == 4)
                    {
                        lienrs.Add(wordLine[i]);
                    }
                    else
                    {
                        break;
                    }
                }
            }


            if (wordContainer.Count >= 3)
            {

                for (var i = 0; i < wordContainer.Count; i++)
                {
                    if (wordContainer[i].wordContainer != null)
                    {
                        wordContainer[i].mesh.enabled = true;
                        magicWinValue += wordContainer[i].wordContainer.GetPrice();
                    }
                }

                if (_lineRenderer != null)
                {
                    _lineRenderer.positionCount = wordPisitions.Count;
                    _lineRenderer.enabled = true;
                    for (int i = 0; i < wordPisitions.Count; i++)
                    {
                        _lineRenderer.SetPosition(i, wordPisitions[i]);
                    }
                }

            }

        }

        public void Reset() 
        {
            foreach (var item in wordContainer)
            {
                item.mesh.enabled = false;
            }
            foreach (var line in wordContainer)
            {
                line.wordContainer.GetComponent<Animator>().SetBool("WordState", false);
            }
            lienrs.Clear();
            wordContainer.Clear();
            wordPisitions.Clear();
            if (_lineRenderer != null)
            {
                _lineRenderer.enabled = false;
                _lineRenderer.positionCount = 0;
            }
        }
    }
}
