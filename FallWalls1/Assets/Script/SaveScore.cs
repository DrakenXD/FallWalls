using UnityEngine;

public class SaveScore : MonoBehaviour
{
    public static SaveScore instance;
    private void Awake()
    {
        instance = this;
    }
    public int CoinInGame;
    [Header("Mineração")]
    public int NivelMining; 
    public int ExpMining;
    public int ExpMiningMark;
    public int FirstGameInMining;

    [Header("Batalha")]
    public int NivelBatlle;
    public int ExpBattle;
    public int ExpBattleMark;
    public int FirstGameInBattle;





    public void Save(TypeSave save)
    {
        if (save == TypeSave.FirstGameInMining)
        {
            PlayerPrefs.SetInt("SaveFirstGame", FirstGameInMining);
        }


        if (save == TypeSave.Coin)
        {
            PlayerPrefs.SetInt("SaveCoin", CoinInGame);
        }
        if (save == TypeSave.LevelBattle)
        {
            PlayerPrefs.SetInt("SaveNivelBattle", NivelBatlle);
        }
        if (save == TypeSave.LevelMining)
        {
            PlayerPrefs.SetInt("SaveNivelMining", NivelMining);
        }

        if (save == TypeSave.ExpMining)
        {
            PlayerPrefs.SetInt("SaveExpMining", ExpMining);
        }
        if (save == TypeSave.ExpMiningMark)
        {
            PlayerPrefs.SetInt("SaveExpMiningMark", ExpMiningMark);
        }


    }

    public void Load(TypeSave load)
    {
        if (load == TypeSave.FirstGameInMining)
        {
            FirstGameInMining = PlayerPrefs.GetInt("SaveFirstGame");
        }


        if (load == TypeSave.Coin)
        {
            CoinInGame = PlayerPrefs.GetInt("SaveCoin");
        }
        if (load == TypeSave.LevelBattle)
        {
            NivelBatlle = PlayerPrefs.GetInt("SaveNivelBattle");
        }
        if (load == TypeSave.LevelMining)
        {
            NivelMining = PlayerPrefs.GetInt("SaveNivelMining");
        }

        if (load == TypeSave.ExpMining)
        {
            ExpMining = PlayerPrefs.GetInt("SaveExpMining");
        }
        if (load == TypeSave.ExpMiningMark)
        {
            ExpMiningMark = PlayerPrefs.GetInt("SaveExpMiningMark");
        }
    }

    public void LevelUp(TypeSave _exp)
    {
        if (TypeSave.ExpMining == _exp)
        {
            if (ExpMining >= ExpMiningMark)
            {
                NivelMining++;

                ExpMiningMark *= 2;

                ExpMining = 0;

            }
        }
    }

    public void Resetar()
    {
        PlayerPrefs.SetInt("SaveFirstGame", 0);

        PlayerPrefs.SetInt("SaveCoin", 0);

        PlayerPrefs.SetInt("SaveNivelBattle", 0);

        PlayerPrefs.SetInt("SaveNivelMining", 0);

        PlayerPrefs.SetInt("SaveExpMining", 0);

        PlayerPrefs.SetInt("SaveExpMiningMark", 0);
    }

    public bool VerifyFirstGameInMining()
    {
        Load(TypeSave.FirstGameInMining);


        if (FirstGameInMining > 0)
        {
            return false;
        }
        else
        {
            FirstGameInMining = 1;

            Save(TypeSave.FirstGameInMining);

            return true;

        }
    }







    public enum TypeSave
    {
        FirstGameInMining,
        FirstGameInBattle,

        Coin,
        LevelBattle,
        LevelMining,
        ExpBattle,
        ExpMining,
        ExpBattleMark,
        ExpMiningMark,
    }
}
