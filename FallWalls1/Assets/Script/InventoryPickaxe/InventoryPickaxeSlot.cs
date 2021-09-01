using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPickaxeSlot : MonoBehaviour
{
    [SerializeField] private Transform transformParent;
    [SerializeField] private GameObject CreateSlot;

    [SerializeField] private SlotPickaxe[] slots;

    [SerializeField] private PickaxeData pickaxeData;

    [SerializeField] private InventoryPickaxe invPickaxe;
    private int amountSlots;

    // Start is called before the first frame update
    void Start()
    {
       
        UpdateSlots();
    }

    public void UpdateSlots()
    {

        for (int i = 0; i < pickaxeData.pickaxe.Length; i++) 
        {
            GameObject newSelected = Instantiate(CreateSlot, transformParent.position, Quaternion.identity);

            newSelected.transform.SetParent(transformParent);

            newSelected.transform.localScale = new Vector3(1, 1, 1);

            slots = transformParent.GetComponentsInChildren<SlotPickaxe>();

            slots[i].ADDSlot(pickaxeData.pickaxe[i]);
        }


       

    }

  

}
