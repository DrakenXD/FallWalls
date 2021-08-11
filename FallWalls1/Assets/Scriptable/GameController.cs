using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    private void Awake()
    {
        instance = this;
    }

    [SerializeField] private TextMeshProUGUI TxtCoins;
    [SerializeField] private TextMeshProUGUI TxtFase;

    // Start is called before the first frame update
    void Start()
    {


        SaveScore.instance.Load(SaveScore.TypeSave.Coin);
        SaveScore.instance.CoinInGame = SaveScore.instance.CoinTotal;
        SaveScore.instance.Load(SaveScore.TypeSave.Level);
   


        UpdateTextCoin();
    }

 
    public void AddCoin(int amount)
    {
        SaveScore.instance.CoinInGame += amount;
        UpdateTextCoin();
    }
    public void UpdateTextCoin()
    {
        TxtCoins.SetText("" + SaveScore.instance.CoinInGame);
    }
}
