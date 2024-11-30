using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MoneyManagerGame : MonoBehaviour
{
    public TMP_Text[] moneysDisplayer;

    public static int moneysAdder;

    private void LateUpdate()
    {
        foreach (var item in moneysDisplayer)
        {
            item.text = moneysAdder.ToString();
        }
    }

    public void OnClickRestart() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        PlayerInfo.playerMoney += moneysAdder;
        Time.timeScale = 1;
    }

    public void OnClickMenu() 
    {
        SceneManager.LoadScene("MenuScene");
        PlayerInfo.playerMoney += moneysAdder;
        Time.timeScale = 1;
    }
}
