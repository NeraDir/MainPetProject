using UnityEngine;
using TMPro;

public class MagicData : MonoBehaviour
{
    public static float CoinsCount 
    {
        get 
        {
            if (PlayerPrefs.HasKey("WoothingPlayerCoinsKey"))
            {
                return PlayerPrefs.GetFloat("WoothingPlayerCoinsKey");
            }
            return 5000;
        }
        set 
        {
            PlayerPrefs.SetFloat("WoothingPlayerCoinsKey", value);
        }
    }

    public static int RedChanger
    {
        get
        {
            if (PlayerPrefs.HasKey("WoothingPlayerRedChangerKey"))
            {
                return PlayerPrefs.GetInt("WoothingPlayerRedChangerKey");
            }
            return 0;
        }
        set
        {
            PlayerPrefs.SetInt("WoothingPlayerRedChangerKey", value);
        }
    }

    public static int BlueChanger
    {
        get
        {
            if (PlayerPrefs.HasKey("WoothingPlayerBlueChangerKey"))
            {
                return PlayerPrefs.GetInt("WoothingPlayerBlueChangerKey");
            }
            return 0;
        }
        set
        {
            PlayerPrefs.SetInt("WoothingPlayerBlueChangerKey", value);
        }
    }

    public static int PurpleChanger
    {
        get
        {
            if (PlayerPrefs.HasKey("WoothingPlayerPurpleChangerKey"))
            {
                return PlayerPrefs.GetInt("WoothingPlayerPurpleChangerKey");
            }
            return 0;
        }
        set
        {
            PlayerPrefs.SetInt("WoothingPlayerPurpleChangerKey", value);
        }
    }

    public static int RandomChanger
    {
        get
        {
            if (PlayerPrefs.HasKey("WoothingPlayerRandomChangerKey"))
            {
                return PlayerPrefs.GetInt("WoothingPlayerRandomChangerKey");
            }
            return 0;
        }
        set
        {
            PlayerPrefs.SetInt("WoothingPlayerRandomChangerKey", value);
        }
    }

    public static int MaxValueChangers
    {
        get
        {
            if (PlayerPrefs.HasKey("WoothingPlayerMaxValueChangersKey"))
            {
                return PlayerPrefs.GetInt("WoothingPlayerMaxValueChangersKey");
            }
            return 2;
        }
        set
        {
            PlayerPrefs.SetInt("WoothingPlayerMaxValueChangersKey", value);
        }
    }

    [SerializeField]
    private TMP_Text[] _coinsCountDisplayer;

    [SerializeField]
    private TMP_Text _redChangerDispalyer;
    [SerializeField]
    private TMP_Text _blueChangerDispalyer;
    [SerializeField]
    private TMP_Text _purpleChangerDispalyer;
    [SerializeField]
    private TMP_Text _randomChangerDispalyer;

    private void LateUpdate()
    {
        foreach (var item in _coinsCountDisplayer)
        {
            item.text = CoinsCount.ToString("0");
        }

        _randomChangerDispalyer.text = "X" + RandomChanger.ToString("0");
        _redChangerDispalyer.text = "X" + RedChanger.ToString("0");
        _blueChangerDispalyer.text = "X" + BlueChanger.ToString("0");
        _purpleChangerDispalyer.text = "X" + PurpleChanger.ToString("0");
    }
}
