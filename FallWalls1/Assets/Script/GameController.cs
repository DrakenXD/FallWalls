using TMPro;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;



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

    [SerializeField] private List<InvItem> item = new List<InvItem>();
    [SerializeField] private SlotItem[] slots;
    [SerializeField] GameObject CreateSlot;
    [SerializeField] private Transform transformParent;
    [SerializeField] private int amountSlots;

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




        TxtTotalCoins.SetText("" + SaveScore.instance.CoinInGame);
    }


    public void AddCoin(int amount)
    {
        coins += amount;

        SaveScore.instance.CoinInGame += amount;

        TxtTotalCoins.SetText("" + SaveScore.instance.CoinInGame);
    }

    public void AddExpMining(int amount)
    {
        exp += amount;

        SaveScore.instance.ExpMining += amount;

        SaveScore.instance.LevelUp(SaveScore.TypeSave.ExpMining);

        TxtTotalNivelMining.SetText("" + SaveScore.instance.NivelMining);
        TxtTotalExpMining.SetText("" + SaveScore.instance.ExpMining + " / " + SaveScore.instance.ExpMiningMark);
    }

 
    public void AddItem(Item _i, int amount)
    {
        bool have = false;
        for (int i = 0; i < item.Count; i++)
        {
            if (item[i].item == _i)
            {
                item[i].amount += amount;
                have = true;
            }


        }
        if (!have)
        {
            item.Add(new InvItem(_i.name, _i.id, _i, amount));
        }
       
    }

    public void ShowScreenDeath()
    {
        _ShowScreenDeath.SetActive(true);

        TxtShowCoins.SetText("+" + coins + "$");
        TxtShowExpMining.SetText("+" + exp + "exp");

       
        for (int i = 0; i < item.Count; i++)
        {
            GameObject newSelected = Instantiate(CreateSlot, transformParent.position, Quaternion.identity);

            newSelected.transform.SetParent(transformParent);

            newSelected.transform.localScale = new Vector3(1, 1, 1);

            slots = transformParent.GetComponentsInChildren<SlotItem>();

          

            slots[i].ADDItemInSlot(item[i]);

        }
        

        Time.timeScale = 0;
    }




    public enum TypeGamePlay
    {
        Battle,
        Mining
    }
}
