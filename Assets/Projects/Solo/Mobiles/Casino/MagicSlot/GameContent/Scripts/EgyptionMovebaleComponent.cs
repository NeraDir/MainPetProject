using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EgyptionMovebaleComponent : MonoBehaviour
{
    public string tempString;

    public static int egyptionFootballStrenght
    {
        get
        {
            if (PlayerPrefs.HasKey("egyptionFootballStrenghtSavekey"))
            {
                return PlayerPrefs.GetInt("egyptionFootballStrenghtSavekey");
            }
            return 0;
        }
        set
        {
            PlayerPrefs.SetInt("egyptionFootballStrenghtSavekey", value);
        }
    }

    public static int egyptionFootbalDistance
    {
        get
        {
            if (PlayerPrefs.HasKey("egyptionFootbalDistanceSaveKey"))
            {
                return PlayerPrefs.GetInt("egyptionFootbalDistanceSaveKey");
            }
            return 70;
        }
        set
        {
            PlayerPrefs.SetInt("egyptionFootbalDistanceSaveKey", value);
        }
    }

    public void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
