using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo
{

    public static int playerMoney 
    {
        get 
        {
            if (PlayerPrefs.HasKey("PlayerInfoMoneySaveKey"))
            {
                return PlayerPrefs.GetInt("PlayerInfoMoneySaveKey");
            }
            return 0;
        }
        set
        {
            PlayerPrefs.SetInt("PlayerInfoMoneySaveKey", value);
        }
    }

    public static string playerName;

    public static int playerPlaneIndex
    {
        get
        {
            if (PlayerPrefs.HasKey("playerPlaneIndexSaveKey"))
            {
                return PlayerPrefs.GetInt("playerPlaneIndexSaveKey");
            }
            return 0;
        }
        set
        {
            PlayerPrefs.SetInt("playerPlaneIndexSaveKey", value);
        }
    }

    public static string[] playerSecondNamePieces;

    public static int playerInfoCountOfEnter
    {
        get
        {
            if (PlayerPrefs.HasKey("playerInfoCountOfEnterSavekey"))
            {
                return PlayerPrefs.GetInt("playerInfoCountOfEnterSavekey");
            }
            return 0;
        }
        set
        {
            PlayerPrefs.SetInt("playerInfoCountOfEnterSavekey", value);
        }
    }
     
    public static int playerCanvasSizePositionerFromTop
    {
        get
        {
            if (PlayerPrefs.HasKey("playerCanvasSizePositionerFromTopSaveKey"))
            {
                return PlayerPrefs.GetInt("playerCanvasSizePositionerFromTopSaveKey");
            }
            return 70;
        }
        set
        {
            PlayerPrefs.SetInt("playerCanvasSizePositionerFromTopSaveKey", value);
        }
    }
}
