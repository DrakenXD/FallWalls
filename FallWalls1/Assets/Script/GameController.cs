using TMPro;
using UnityEngine;



public class GameController : MonoBehaviour
{
    public static GameController instance;
    private void Awake()
    {
        instance = this;
    }

    public TypeGamePlay typeGamePlay;


    [SerializeField] private GameObject _ShowScreenDeath;

    [Header("In Game")]
    [SerializeField] private TextMeshProUGUI TxtTotalCoins;
    [SerializeField] private TextMeshProUGUI TxtTotalNivelMining;
    [SerializeField] private TextMeshProUGUI TxtTotalExpMining;
    [SerializeField] private TextMeshProUGUI TxtTotalNivelBattle;


    [Header("In ScreenDeah")]
    private int coins;
    private int exp;
    [SerializeField] private TextMeshProUGUI TxtShowCoins;
    [SerializeField] private TextMeshProUGUI TxtShowExpMining;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;

        SaveScore.instance.Load(SaveScore.TypeSave.Coin);

        if (typeGamePlay == TypeGamePlay.Battle)
        {
            SaveScore.instance.Load(SaveScore.TypeSave.LevelBattle);
        }
        else if (typeGamePlay == TypeGamePlay.Mining)
        {
            if (SaveScore.instance.VerifyFirstGameInMining()) SaveScore.instance.ExpMiningMark = 20;
            else
            {
                SaveScore.instance.Load(SaveScore.TypeSave.ExpMiningMark);
            }


            SaveScore.instance.Load(SaveScore.TypeSave.LevelMining);
            SaveScore.instance.Load(SaveScore.TypeSave.ExpMining);



            //UI
            TxtTotalNivelMining.SetText("" + SaveScore.instance.NivelMining);
            TxtTotalExpMining.SetText("" + SaveScore.instance.ExpMining + " / " + SaveScore.instance.ExpMiningMark);

            //SaveScore.instance.Resetar();
        }




        UpdateTextCoin();
    }


    public void AddCoin(int amount)
    {
        coins += amount;

        SaveScore.instance.CoinInGame += amount;
        UpdateTextCoin();
    }

    public void AddExpMining(int amount)
    {
        exp += amount;

        SaveScore.instance.ExpMining += amount;

        SaveScore.instance.LevelUp(SaveScore.TypeSave.ExpMining);

        TxtTotalNivelMining.SetText("" + SaveScore.instance.NivelMining);
        TxtTotalExpMining.SetText("" + SaveScore.instance.ExpMining + " / " + SaveScore.instance.ExpMiningMark);
    }

    public void UpdateTextCoin()
    {
        TxtTotalCoins.SetText("" + SaveScore.instance.CoinInGame);
    }



    public void ShowScreenDeath()
    {
        _ShowScreenDeath.SetActive(true);

        TxtShowCoins.SetText("+" + coins + "$");
        TxtShowExpMining.SetText("+" + exp + "exp");

        Time.timeScale = 0;
    }
    public enum TypeGamePlay
    {
        Battle,
        Mining
    }
}
