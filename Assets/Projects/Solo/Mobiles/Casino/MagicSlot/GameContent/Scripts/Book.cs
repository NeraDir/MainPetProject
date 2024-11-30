using System.Collections;
using UnityEngine;

public class Book : MonoBehaviour
{
    [SerializeField]
    private WordContainer[] words;

    private int countOfPassed;

    [SerializeField]
    private Animator animator;

    public MagicGameController magicGameController;

    [SerializeField]
    private GameObject _winningShower;

    public float TempWinningValue;

    private bool _canShow;

    [SerializeField]
    private MagicMen _magist;

    private int countSpeened;

    [SerializeField]
    private WordTriggerer[] _wordTriggerers;


    [SerializeField]
    private AdditionalSlotController slotController;
    private void Awake()
    {
        countSpeened = 0;
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }

    public void OnEnd()
    {
        countOfPassed++;
        if (countOfPassed >= 15)
        {
            countOfPassed = 0;
            animator.enabled = false;

            for (var i=0;i < magicGameController.lines.Length;i++) 
            {
                magicGameController.lines[i].GetLines();
              
            }

            for (var i = 0; i < magicGameController.lines.Length; i++) 
            {
                if (magicGameController.lines[i].wordContainer.Count >= 3)
                {
                    _canShow= true;
                    magicGameController.lines[i].SetAnimations();
                }
            }
            if (_canShow)
            {
                if (MagicGameController.magicWinValue > 0 )
                {
                    _winningShower.SetActive(true);
                    TempWinningValue = 0;
                    StartCoroutine(WinningShowering());
                }
                
            }
            MagicGameController.CheckBonus();
            Invoke(nameof(CanSpin), 1);
        }

    }

    private IEnumerator WinningShowering() 
    {
        float incremnter = 0;
        float timeincrementer = 0;
        TempWinningValue = 0;
        if (MagicGameController.magicWinValue > 100)
        {
            timeincrementer = 0.001f;
            incremnter = 10;
        }
        else
        {
            timeincrementer = 0.001f;
            incremnter = 1;
        }
        while (TempWinningValue < MagicGameController.magicWinValue) 
        {
            TempWinningValue += incremnter;

            yield return new WaitForSeconds(timeincrementer);
        }
        Debug.Log(TempWinningValue);
        yield return new WaitForSeconds(1);
        MagicGameController.WinningPages.SetActive(false);
        StopAllCoroutines();
    }


    private void CanSpin() 
    {
        MagicGameController.turningpages = false;
        MagicGameController.GetEnd(false);
        _canShow = false;
    }

    public void OnSetWords()
    {
        if (countOfPassed == 14)
        {
            foreach (var item in words)
            {
                item.SetValue();
            }



            if (!MagicGameController._freeSpins)
            {
                

                countSpeened++;
                if (Random.Range(0, 2) != 0 && countSpeened >= 3)
                {
                    _magist.SetOneRandomWild();
                    countSpeened = 0;
                }

                int value = 0;
                for (int i = 0; i < _wordTriggerers.Length; i++)
                {
                    value = Random.Range(0, 100);
                    if (value < 65 && value > 35)
                    {
                        _wordTriggerers[i].wordContainer.SetParagon(4);
                    }
                }
                if (SettingSpecials.used)
                {
                    if (SettingSpecials.changererd != null)
                    {
                        SettingSpecials.changererd();
                    }
                    SettingSpecials.used = false;
                }
            }
            else
            {
                _magist.SetRandomWild();
            }
        }
    }
}
