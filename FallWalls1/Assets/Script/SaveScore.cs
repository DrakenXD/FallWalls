using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveScore : MonoBehaviour
{
    public static SaveScore instance;
    private void Awake()
    {
        instance = this;
    }

    public int CoinInGame;
    public int levelInGame;
   
    public int CoinTotal;
    public int LevelTotal;

    public void Save(TypeSave save)
    {
        if (save == TypeSave.Coin)
        {
            PlayerPrefs.SetInt("SaveCoin", CoinInGame);
        }
        if(save == TypeSave.Level)
        {
            PlayerPrefs.SetInt("SaveLevel", levelInGame);
        }
    }

    public void Load(TypeSave load)
    {
        if (load == TypeSave.Coin)
        {
            CoinTotal = PlayerPrefs.GetInt("SaveCoin");
        }
        if (load == TypeSave.Level)
        {
            LevelTotal = PlayerPrefs.GetInt("SaveLevel");
        }
    }

    public enum TypeSave
    {
        Coin,
        Level
    }
}
