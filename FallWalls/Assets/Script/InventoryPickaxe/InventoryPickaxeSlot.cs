using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPickaxeSlot : MonoBehaviour
{
    [SerializeField] private Transform transformParent;
    [SerializeField] private GameObject CreateSlot;

    [SerializeField] private InvSlotPickaxe[] slots;

    [SerializeField] private InventoryPickaxe invPickaxe;
    [SerializeField] int amountSlots;
    public void UpdateSlots()
    {

        //adiciona um slot

        for (int i = 0;i< invPickaxe.container.Count;i++)
        {
            if (amountSlots < invPickaxe.container.Count)
            {
                GameObject newSelected = Instantiate(CreateSlot, transformParent.position, Quaternion.identity);

                newSelected.transform.SetParent(transformParent);

                newSelected.transform.localScale = new Vector3(1, 1, 1);

                slots = transformParent.GetComponentsInChildren<InvSlotPickaxe>();

                amountSlots++;
            }
        }

        //atualiza os slots

        for (int i = 0; i < slots.Length; i++)
        {
            if (i < invPickaxe.container.Count)
            {
                slots[i].ADDSlot(invPickaxe.container[i]);
            }
           

        }
    }
    
   

  
    public void UsePickaxe(Pickaxes _p)
    {
        
        for (int i = 0; i < invPickaxe.container.Count; i++)
        {
            if (invPickaxe.container[i].Use)
            {
                invPickaxe.container[i].Use = false;
                slots[i].UpdateMark(false);
            }

            if (invPickaxe.container[i] == _p)
            {
               

                invPickaxe.container[i].Use = true;
                slots[i].UpdateMark(true);

            

                
            }

         
        }
     
    }


}
