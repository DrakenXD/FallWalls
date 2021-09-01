using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public Pickaxe[] test;
    public InventoryPickaxe InvPickaxes;
    public Item[] test1;
    public InventoryItem invItem;

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


    public void AddItem(Item _i,int amount)
    {
        invItem.AddItem(_i,amount);
    }
    public void AddPickaxe(Pickaxe _p)
    {
        InvPickaxes.AddItem(_p);
        InvPickaxes.Save();
    }

    public void RemoveItem(Item _i, int amount)
    {
        invItem.RemoveItem(_i, amount);
        invItem.Save();
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

    public bool SeachPickaxe(Pickaxe _p)
    {
        if (InvPickaxes.ContainPickaxe(_p))
        {
            return true;
        }

        return false;
    }
   
    public void Save()
    {
        invItem.Save();
        InvPickaxes.Save();
    }
    public void Load()
    {
        invItem.Load();
        InvPickaxes.Load();
    }
}
