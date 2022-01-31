using UnityEngine;

public class InventoryItemSlot : MonoBehaviour
{
    [SerializeField] private Transform transformParent;
    [SerializeField] private GameObject CreateSlot;

    [SerializeField] private SlotItem[] slots;

    [SerializeField] private InventoryItem invItem;
    private int amountSlots;

    // Start is called before the first frame update
    void Start()
    {
        invItem.Load();


        slots = transformParent.GetComponentsInChildren<SlotItem>();

        AddSlots();
   
    }

    private void AddSlots()
    {

        for (int i = 0;i< invItem.container.Count;i++)
        {
            if (amountSlots < invItem.container.Count)
            {
                GameObject newSelected = Instantiate(CreateSlot, transformParent.position, Quaternion.identity);

                newSelected.transform.SetParent(transformParent);

                newSelected.transform.localScale = new Vector3(1, 1, 1);

                slots = transformParent.GetComponentsInChildren<SlotItem>();

                amountSlots++;
            }
        }


        UpdateSlots();

    }

    public void UpdateSlots()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < invItem.container.Count)
            {


                slots[i].ADDItemInSlot(invItem.container[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }

        }
    }

}
