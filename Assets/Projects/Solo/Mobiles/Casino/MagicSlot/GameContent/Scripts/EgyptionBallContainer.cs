using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EgyptionBallContainer : MonoBehaviour
{
    [HideInInspector] public string egyptionFootbalTempString;

    public static int footballJumpStrenght
    {
        get
        {
            if (PlayerPrefs.HasKey("footballJumpStrenghtSaveKey"))
            {
                return PlayerPrefs.GetInt("footballJumpStrenghtSaveKey");
            }
            return 0;
        }
        set
        {
            PlayerPrefs.SetInt("footballJumpStrenghtSaveKey", value);
        }
    }

    public static int footballSlidingValue
    {
        get
        {
            if (PlayerPrefs.HasKey("footballSlidingValueSaveKEy"))
            {
                return PlayerPrefs.GetInt("footballSlidingValueSaveKEy");
            }
            return 70;
        }
        set
        {
            PlayerPrefs.SetInt("footballSlidingValueSaveKEy", value);
        }
    }

    public void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
