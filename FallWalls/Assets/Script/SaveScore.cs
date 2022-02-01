using UnityEngine;

public class SaveScore : MonoBehaviour
{
    public static SaveScore instance;
    private void Awake()
    {
        instance = this;
    }
    public int CoinInGame;
    
    [Header("Minera��o")]
    public int NivelMining; 
    public int ExpMining;
    public int ExpMiningMark;
    public int FirstGameInMining;

    [Header("Batalha")]
    public int NivelBatlle;
    public int ExpBattle;
    public int ExpBattleMark;
    public int FirstGameInBattle;

   
    private void Start() {       

        //Resetar();
        Load(TypeSave.Coin);
        Load(TypeSave.LevelBattle);
        Load(TypeSave.LevelMining);
        
    }

    public void Save(TypeSave save)
    {
        if (save == TypeSave.FirstGameInMining)
        {
            PlayerPrefs.SetInt("SaveFirstMining", FirstGameInMining);
        }
        if (save == TypeSave.FirstGameInBattle)
        {
            PlayerPrefs.SetInt("SaveFirstBattle", FirstGameInBattle);
        }

        if (save == TypeSave.Coin)
        {
            PlayerPrefs.SetInt("SaveCoin", CoinInGame);
        }

        //level
        if (save == TypeSave.LevelBattle)
        {
            PlayerPrefs.SetInt("SaveNivelBattle", NivelBatlle);
        }
        if (save == TypeSave.LevelMining)
        {
            PlayerPrefs.SetInt("SaveNivelMining", NivelMining);
        }

        //exp
        if (save == TypeSave.ExpMining)
        {
            PlayerPrefs.SetInt("SaveExpMining", ExpMining);
        }
        if (save == TypeSave.ExpBattle)
        {
            PlayerPrefs.SetInt("SaveExpBattle", ExpBattle);
        }
        
        //mark
        if (save == TypeSave.ExpMiningMark)
        {
            PlayerPrefs.SetInt("SaveExpMiningMark", ExpMiningMark);
        }
        if (save == TypeSave.ExpBattleMark)
        {
            PlayerPrefs.SetInt("SaveExpBattleMark", ExpBattleMark);
        }

    }

    public void Load(TypeSave load)
    {
        if (load == TypeSave.FirstGameInMining)
        {
            FirstGameInMining = PlayerPrefs.GetInt("SaveFirstMining");
        }
        if (load == TypeSave.FirstGameInBattle)
        {
            FirstGameInBattle = PlayerPrefs.GetInt("SaveFirstBattle");
        }

        if (load == TypeSave.Coin)
        {
            CoinInGame = PlayerPrefs.GetInt("SaveCoin");
        }
        //level
        if (load == TypeSave.LevelBattle)
        {
            NivelBatlle = PlayerPrefs.GetInt("SaveNivelBattle");
        }
        if (load == TypeSave.LevelMining)
        {
            NivelMining = PlayerPrefs.GetInt("SaveNivelMining");
        }

        //exp
        if (load == TypeSave.ExpMining)
        {
            ExpMining = PlayerPrefs.GetInt("SaveExpMining");
        }
        if (load == TypeSave.ExpBattle)
        {
            ExpBattle = PlayerPrefs.GetInt("SaveExpBattle");
        }

        //mark
        if (load == TypeSave.ExpMiningMark)
        {
            ExpMiningMark = PlayerPrefs.GetInt("SaveExpMiningMark");
        }
        if (load == TypeSave.ExpBattleMark)
        {
            ExpBattleMark = PlayerPrefs.GetInt("SaveExpBattleMark");
        }
    }

    public void LevelUp(TypeSave _exp)
    {
        if (TypeSave.ExpMining == _exp)
        {
            if (ExpMining >= ExpMiningMark)
            {
                NivelMining++;

                ExpMining = ExpMining - ExpMiningMark;

                ExpMiningMark *= 2;
            }
        }
        if (TypeSave.ExpBattle == _exp)
        {
            if (ExpBattle >= ExpBattleMark)
            {
                NivelBatlle++;

                ExpBattle = ExpBattle-ExpMiningMark;

                ExpBattleMark *= 2;

            }
        }
    }

    public void Resetar()
    {
        PlayerPrefs.SetInt("SaveFirstMining", 0);

        PlayerPrefs.SetInt("SaveFirstBattle", 0);
        
        
        PlayerPrefs.SetInt("SaveCoin", 0);
        
        
        PlayerPrefs.SetInt("SaveNivelBattle", 0);

        PlayerPrefs.SetInt("SaveNivelMining", 0);

        
        PlayerPrefs.SetInt("SaveExpMining", 0);

        PlayerPrefs.SetInt("SaveExpBattle", 0);

        
        PlayerPrefs.SetInt("SaveExpMiningMark", 0);

        PlayerPrefs.SetInt("SaveExpBattleMark", 0);

        Debug.Log("**Resetou TUdo**");
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
    public bool VerifyFirstGameInBattle()
    {
        Load(TypeSave.FirstGameInBattle);


        if (FirstGameInBattle > 0)
        {
            return false;
        }
        else
        {
            FirstGameInBattle = 1;

            Save(TypeSave.FirstGameInBattle);

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
