using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySwordSlot : MonoBehaviour
{
    [SerializeField] private Transform transformParent;
    [SerializeField] private GameObject CreateSlot;

    [SerializeField] private InvSlotSword[] slots;

    [SerializeField] private InventorySword invSword;
    [SerializeField]private int amountSlots;
    public void UpdateSlots()
    {

        for (int i = 0;i< invSword.container.Count;i++)
        {
            if (amountSlots < invSword.container.Count)
            {
                GameObject newSelected = Instantiate(CreateSlot, transformParent.position, Quaternion.identity);

                newSelected.transform.SetParent(transformParent);

                newSelected.transform.localScale = new Vector3(1, 1, 1);

                slots = transformParent.GetComponentsInChildren<InvSlotSword>();

                amountSlots++;
            }
        }

        for (int i = 0; i < slots.Length; i++)
        {
            if (i < invSword.container.Count)
            {
                slots[i].ADDSlot(invSword.container[i]);
            }
           

        }

           
    }

    

  
    public void UseSword(Swords _s)
    {
        
        for (int i = 0; i < invSword.container.Count; i++)
        {
            if (invSword.container[i].Use)
            {
                invSword.container[i].Use = false;
                slots[i].UpdateMark(false);
            }
            
            if (invSword.container[i] == _s)
            {
               

                invSword.container[i].Use = true;
                slots[i].UpdateMark(true);

            

                
            }
            
         
        }
     
    }


}
