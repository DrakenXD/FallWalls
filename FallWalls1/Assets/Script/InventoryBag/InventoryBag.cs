using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryBag : MonoBehaviour
{
    public List<InventoryItem> item = new List<InventoryItem>();
   

    public int space;

    public Item n1;
    public Item n2;

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
            item.Add(new InventoryItem(_item.id, _item, amount));

            indexStack = indexItem;

            firstItem = true;
        }


        if (!item.Contains(item[indexItem]))
        {
            item.Add(new InventoryItem(_item.id, _item, amount));
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
                item.Add(new InventoryItem(_item.id, _item, amount));
            }
        }

        FindObjectOfType<InventorySlot>().UpdateSlots();
    }

    public void RemoveItem(Item _item, int amount)
    {
        for (int i = 0; i < item.Count; i++) 
        {
            if (item[i].item==_item)
            {
                if (item[i].amount > 0)
                {
                    item[i].amount -= amount;
                }
                else
                {
                    item.Remove(item[i]);
                }
            }
        }

        FindObjectOfType<InventorySlot>().UpdateSlots();
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            ADDitem(n1, 1);
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            RemoveItem(n1, 1);
        }
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
