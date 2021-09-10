using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ShopPickaxeSlot : MonoBehaviour
{
    [SerializeField] private Transform transformParent;
    [SerializeField] private GameObject CreateSlot;

    [SerializeField] private SlotPickaxe[] slots;

    [SerializeField] private PickaxeData pickaxeData;

    [SerializeField] private InventoryPickaxe invPickaxe;
    private int amountSlots;

    [SerializeField] private TextMeshProUGUI txtamountcoins;
    private int amountcoins;

    // Start is called before the first frame update
    void Start()
    {
        amountcoins = PlayerPrefs.GetInt("SaveCoin");
        UpdateTxtCoins();

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

    public void UpdateTxtCoins()
    {
        txtamountcoins.SetText(""+amountcoins);
    }
    public void RemoveCoins(int amount)
    {
        PlayerPrefs.SetInt("SaveCoin", amount);
        UpdateTxtCoins();
    }
}
