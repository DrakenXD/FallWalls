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

        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 120;
    }

    public int start = 0;
    public TypeGamePlay typeGamePlay =  TypeGamePlay.None;


    [SerializeField] private GameObject _ShowScreenDeath;

    [Header("Battle")]
    [SerializeField] private TextMeshProUGUI TxtTotalCoins;
    [SerializeField] private TextMeshProUGUI TxtTotalNivelBattle;
    [SerializeField] private TextMeshProUGUI TxtTotalExpBattle;
    
    [Header("Mining")]
    [SerializeField] private TextMeshProUGUI TxtTotalNivelMining;
    [SerializeField] private TextMeshProUGUI TxtTotalExpMining;
    

    

  
    private int coins;
    private int exp;
   
    [Header("In ScreenDeah")]
    [SerializeField] private TextMeshProUGUI TxtShowCoins;
    [SerializeField] private TextMeshProUGUI TxtShowExp;
    [SerializeField] private List<InvItem> item = new List<InvItem>();
    [SerializeField] private SlotItem[] slots;
    [SerializeField] GameObject CreateSlot;
    [SerializeField] private Transform transformParent;
    [SerializeField] private int amountSlots;

    // Start is called before the first frame update
    void Start()
    {
        
        if(1 != PlayerPrefs.GetInt("Start")){
            start++;
            PlayerPrefs.SetInt("Start",start);
        }
        

        

        Time.timeScale = 1;

        
        if (typeGamePlay == TypeGamePlay.Battle)
        {
            if (SaveScore.instance.VerifyFirstGameInBattle()) SaveScore.instance.ExpBattleMark = 20;
            else
            {
                SaveScore.instance.Load(SaveScore.TypeSave.ExpBattleMark);
            }
            
            
            SaveScore.instance.Load(SaveScore.TypeSave.ExpBattle);
            SaveScore.instance.Load(SaveScore.TypeSave.LevelBattle);
            SaveScore.instance.Load(SaveScore.TypeSave.Coin);
            
            
            
            TxtTotalCoins.SetText("" + SaveScore.instance.CoinInGame);
            TxtTotalExpBattle.SetText("" + SaveScore.instance.ExpBattle + " / " + SaveScore.instance.ExpBattleMark);
            TxtTotalNivelBattle.SetText("" + SaveScore.instance.NivelBatlle);


            SaveScore.instance.Save(SaveScore.TypeSave.ExpBattleMark);
            //SaveScore.instance.Resetar();
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

            
            
            
            SaveScore.instance.Save(SaveScore.TypeSave.ExpMiningMark);
        }




        
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
    public void AddExpBattle(int amount)
    {
        exp += amount;

        SaveScore.instance.ExpBattle += amount;

        SaveScore.instance.LevelUp(SaveScore.TypeSave.ExpBattle);

        TxtTotalNivelBattle.SetText("" + SaveScore.instance.NivelBatlle);
        TxtTotalExpBattle.SetText("" + SaveScore.instance.ExpBattle + " / " 
        + SaveScore.instance.ExpBattleMark);
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

        TxtShowExp.SetText(""+exp+"+" );

        if(typeGamePlay == TypeGamePlay.Battle){
            TxtShowCoins.SetText("+" + coins + "$");

        }else if(typeGamePlay == TypeGamePlay.Mining){
            
            

       
            for (int i = 0; i < item.Count; i++)
            {
                GameObject newSelected = Instantiate(CreateSlot, transformParent.position, Quaternion.identity);

                newSelected.transform.SetParent(transformParent);

                newSelected.transform.localScale = new Vector3(1, 1, 1);

                slots = transformParent.GetComponentsInChildren<SlotItem>();

          

                slots[i].ADDItemInSlot(item[i]);

            }
        }
        
       
        

        Time.timeScale = 0;
    }

    
}
public enum TypeGamePlay
{   
    None,
    Battle,
     Mining
}
