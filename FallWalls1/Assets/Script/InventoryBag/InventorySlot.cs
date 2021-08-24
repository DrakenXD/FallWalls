using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlot : MonoBehaviour
{
    [SerializeField] private Transform transformParent;
    [SerializeField] private GameObject CreateSlot;

    [SerializeField] private Slots[] slots;

    InventoryBag inventoryBag;
    private int amountSlots;

    // Start is called before the first frame update
    void Start()
    {
        inventoryBag = InventoryBag.instance;

        slots = transformParent.GetComponentsInChildren<Slots>();

        UpdateSlots();
    }

    public void UpdateSlots()
    {
        /*
        if (amountSlots < inventoryBag.item.Count)
        {

            
            GameObject newSelected = Instantiate(CreateSlot, transformParent.position, Quaternion.identity);

            newSelected.transform.SetParent(transformParent);
           
            newSelected.transform.localScale = new Vector3(1, 1, 1);

            slots = transformParent.GetComponentsInChildren<Slots>();

            amountSlots++;
          
        }*/
     

        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventoryBag.item.Count)
            {
                

                slots[i].ADDItemInSlot(inventoryBag.item[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }

        }

    }

}
