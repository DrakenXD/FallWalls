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
    [SerializeField] private TextMeshProUGUI TxtLevels;

    // Start is called before the first frame update
    void Start()
    {
        SaveScore.instance.Load(SaveScore.TypeSave.Coin);
        SaveScore.instance.CoinInGame = SaveScore.instance.CoinTotal;
    }

 
    public void AddCoin(int amount)
    {
        SaveScore.instance.CoinInGame += amount;
        TxtCoins.SetText("" + SaveScore.instance.CoinInGame); 
    }
}
