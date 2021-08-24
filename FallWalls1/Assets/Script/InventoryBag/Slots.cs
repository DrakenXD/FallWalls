using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Slots : MonoBehaviour
{
    [SerializeField] private Image slot;
    [SerializeField] private Image icon;
    [SerializeField] private TextMeshProUGUI txtAmount;
    private Item item;
    private int amount;

    public void ADDItemInSlot(InventoryItem inventoryItem)
    {
        item = inventoryItem.item;

        if (inventoryItem.amount < 1)
        {
            slot.enabled = false;
            icon.enabled = false;
            txtAmount.enabled = false;
        }
        else
        {
            slot.enabled = true;
            icon.enabled = true;
            txtAmount.enabled = true;
        }

        icon.sprite = inventoryItem.item.sprite;
        txtAmount.SetText(inventoryItem.amount+"x");
    }

    public void ButtonDescription()
    {
        FindObjectOfType<Description>().UpdateDescription(item);
    }
}
