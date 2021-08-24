using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryBag : MonoBehaviour
{
    public static InventoryBag instance;
    private void Awake()
    {
        instance = this;
    }


    public List<InventoryItem> item = new List<InventoryItem>();
    public int id;

    public int space;

    public Item[] test;


    public void ADDitem(Item _item , int amount)
    {

        int indexItem= 0;
        int indexStack = -1;
        bool firstItem = false;
        
        if (item.Count > 0)
        {
            for (int i = 0; i < item.Count; i++)
            {
                if (item[i].item == _item)
                {
                    indexItem = i;
                    
                }
            }
        }
        else
        {
            item.Add(new InventoryItem(id, _item, amount));

            indexStack = indexItem;

            firstItem = true;

            id++;
        }


        if (!item.Contains(item[indexItem]))
        {
            item.Add(new InventoryItem(id, _item, amount));

            id++;
        }
        else
        {
            for (int i = 0; i < item.Count; i++)
            {
                if (item[i].item == _item)
                {
                    if (item[i].amount < _item.MaxStack && !firstItem)
                    {
                        item[i].amount++;

                        indexStack = i;


                        break;
                    }
                    
                }
            }

            if (indexStack == -1)
            {
                item.Add(new InventoryItem(id, _item, amount));

                id++;
            }
        }

        FindObjectOfType<InventorySlot>().UpdateSlots();
    }

    public void RemoveItem(Item _item, int amount)
    {
        for (int i = 0; i < item.Count; i++) 
        {
            if (item[i].item == _item) 
            {
                if (item[i].amount >= amount)
                {
                    item[i].amount -= amount;
                }

                if (item[i].amount == 0)
                {
                    item.Remove(item[i]);
                }

            }
        }


        FindObjectOfType<InventorySlot>().UpdateSlots();
    }


   


}

[System.Serializable]
public class InventoryItem
{
    public int ID;

    public Item item;
    public int amount;
    public InventoryItem(int id, Item _item, int _amount)
    {
        this.ID = id;
        this.item = _item;
        this.amount = _amount;
    }

}
