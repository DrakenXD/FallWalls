using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public Pickaxe[] test;
    public InventoryPickaxe InvPickaxes;
    public Item[] test1;
    public InventoryItem InvItem;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            InvItem.RemoveItem(test1[Random.Range(0, test1.Length)], 5);
           
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            InvItem.AddItem(test1[Random.Range(0, test1.Length)], 5);
            InvPickaxes.AddItem(test[Random.Range(0, test.Length)]);
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {

            InvItem.Save();
            InvPickaxes.Save();
        }
        if (Input.GetKeyDown(KeyCode.Mouse2))
        {
            InvItem.Load();
            InvPickaxes.Load();
        }
    }
}
