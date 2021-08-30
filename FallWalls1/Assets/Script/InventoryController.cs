using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public Pickaxe[] test;
    public InventoryPickaxe InvPickaxes;
    public Item[] test1;
    public InventoryItem InvItem;

    private void Update()
    {

   
      
        if (Input.GetKey(KeyCode.Mouse2))
        {
            InvItem.Load();
            InvPickaxes.Load();
        }
    }


    public void AddItem(Item _i,int amount)
    {
        InvItem.AddItem(_i,amount);
    }
    public void AddPickaxe(Pickaxe _p)
    {
        InvPickaxes.AddItem(_p);
    }

    public void Save()
    {
        InvItem.Save();
        InvPickaxes.Save();
    }
    public void Load()
    {
        InvItem.Load();
        InvPickaxes.Load();
    }
}
