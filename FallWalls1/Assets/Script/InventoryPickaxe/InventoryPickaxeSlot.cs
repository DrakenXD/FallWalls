using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPickaxeSlot : MonoBehaviour
{
    [SerializeField] private Transform transformParent;
    [SerializeField] private GameObject CreateSlot;

    [SerializeField] private InvSlotPickaxe[] slots;

    [SerializeField] private InventoryPickaxe invPickaxe;
    private int amountSlots;

    // Start is called before the first frame update
    void Start()
    {
       
        UpdateSlots();
    }

    private void UpdateSlots()
    {
        for (int i = 0; i < invPickaxe.container.Count; i++) 
        {
            GameObject newSelected = Instantiate(CreateSlot, transformParent.position, Quaternion.identity);

            newSelected.transform.SetParent(transformParent);

            newSelected.transform.localScale = new Vector3(1, 1, 1);

            slots = transformParent.GetComponentsInChildren<InvSlotPickaxe>();

            slots[i].ADDSlot(invPickaxe.container[i]);
        }
    }

  
    public void UsePickaxe(Pickaxes _p)
    {
        
        for (int i = 0; i < invPickaxe.container.Count; i++)
        {
            if (invPickaxe.container[i] == _p)
            {
                

                invPickaxe.container[i].Use = true;
                slots[i].UpdateMark(true);

            

                
            }

         
        }
     
    }


    public void removeUsePickaxe()
    {
        for (int i = 0; i < invPickaxe.container.Count; i++)
        {
            invPickaxe.container[i].Use = false;
            slots[i].UpdateMark(false);
        }
    }
}
