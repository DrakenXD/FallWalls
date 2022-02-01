using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [SerializeField] private InventoryPickaxe InvPickaxes;
    [SerializeField] private InventoryItem invItem;

    [SerializeField] private InventorySword invSword;

    

    private void Start()
    {
        Load();
    }
    private void Update()
    {

        if (Input.GetKey(KeyCode.S))
        {
            Save();
        }

        if (Input.GetKey(KeyCode.L))
        {
            Load();
        }

        
    }

    #region ItemSistem

    
    public void AddItem(Item _i,int amount)
    {
        invItem.AddItem(_i,amount);
        invItem.Save();
        invItem.Load();
    }
    public void RemoveItem(Item _i, int amount)
    {
        invItem.RemoveItem(_i, amount);
        invItem.Save();
        invItem.Load();
    }
    public bool SearchItem(Item _i, int amount)
    {
        for (int i = 0; i < invItem.container.Count; i++)
        {
            if (invItem.container[i].item == _i)
            {
                if (invItem.container[i].amount >= amount)
                {
                    return true;
                }
            }

        }
        return false;
    }
    #endregion

   
    #region PickaxeSistem
    public void AddPickaxe(Pickaxe _p)
    {
        InvPickaxes.AddItem(_p);
        InvPickaxes.Save();
        InvPickaxes.Load();
    }
    public bool SeachPickaxe(Pickaxe _p)
    {
        if (InvPickaxes.ContainPickaxe(_p))
        {
            return true;
        }

        return false;
    }
    public Pickaxe GetPickaxeUsed()
    {
        return InvPickaxes.GetPickaxeUsed();
    }
    public bool HavePickaxe(){
        return InvPickaxes.HavePickaxe();
    }

    #endregion


    #region SwordSitem
    public void AddSword(Sword _s)
    {
        invSword.AddItem(_s);
        invSword.Save();
        invSword.Load();
    }
    public bool SeachSword(Sword _s)
    {
        return invSword.ContainSword(_s);       
    }
    public Sword GetSwordUsed()
    {
        return invSword.GetSwordUsed();
    }
    public bool HaveSword(){
        return invSword.HaveSword();
    }
    #endregion







    public void Save()
    {
        if(GameController.instance.typeGamePlay == TypeGamePlay.None){
            invItem.Save();
            InvPickaxes.Save();
            invSword.Save(); 
        }else if(GameController.instance.typeGamePlay == TypeGamePlay.Mining){
            invItem.Save();
            InvPickaxes.Save();
        }else if(GameController.instance.typeGamePlay == TypeGamePlay.Battle){
            invSword.Save();
        }
        
    }
    public void Load()
    {
        if(GameController.instance.typeGamePlay == TypeGamePlay.None){
            invItem.Load();
            InvPickaxes.Load();
            invSword.Load(); 
        }else if(GameController.instance.typeGamePlay == TypeGamePlay.Mining){
            invItem.Load();
            InvPickaxes.Load();
        }else if(GameController.instance.typeGamePlay == TypeGamePlay.Battle){
            invSword.Load();
        }
    }
}
