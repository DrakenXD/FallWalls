using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SlotItem : MonoBehaviour
{
    [SerializeField] private Image slot;
    [SerializeField] private Image icon;
    [SerializeField] private TextMeshProUGUI txtAmount;
    [SerializeField] private Item item;
    private int amount;

    public void ADDItemInSlot(InvItem inventoryItem)
    {
        item = inventoryItem.item;

        slot.enabled = true;
        icon.enabled = true;
        txtAmount.enabled = true;

        icon.sprite = inventoryItem.item.sprite;
        txtAmount.SetText(inventoryItem.amount + "x");
    }

    public void ButtonDescription()
    {
        FindObjectOfType<Description>().UpdateDescription(item);
    }

    public void ClearSlot()
    {
        slot.enabled = false;
        icon.enabled = false;
        txtAmount.enabled = false;

        item = null;
    }

}
