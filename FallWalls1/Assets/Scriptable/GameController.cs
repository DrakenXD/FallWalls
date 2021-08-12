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
   

    [SerializeField] private TextMeshProUGUI TxtCoins;
    [SerializeField] private TextMeshProUGUI TxtNivelMining;
    [SerializeField] private TextMeshProUGUI TxtExpMining;

    [SerializeField] private TextMeshProUGUI TxtNivelBattle;

    // Start is called before the first frame update
    void Start()
    {


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
            TxtNivelMining.SetText("" + SaveScore.instance.NivelMining);
            TxtExpMining.SetText("" + SaveScore.instance.ExpMining+" / "+SaveScore.instance.ExpMiningMark);

            //SaveScore.instance.Resetar();
        }

        


        UpdateTextCoin();
    }

 
    public void AddCoin(int amount)
    {
        SaveScore.instance.CoinInGame += amount;
        UpdateTextCoin();
    }

    public void AddExpMining(int amount)
    {
        SaveScore.instance.ExpMining += amount;

        SaveScore.instance.LevelUp(SaveScore.TypeSave.ExpMining);

        TxtNivelMining.SetText("" + SaveScore.instance.NivelMining);
        TxtExpMining.SetText("" + SaveScore.instance.ExpMining + " / " + SaveScore.instance.ExpMiningMark);
    }

    public void UpdateTextCoin()
    {
        TxtCoins.SetText("" + SaveScore.instance.CoinInGame);
    }


    public enum TypeGamePlay
    {
        Battle,
        Mining
    }
}
