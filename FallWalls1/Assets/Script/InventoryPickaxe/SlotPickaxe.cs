using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SlotPickaxe : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private TextMeshProUGUI txtName;
    [SerializeField] private TextMeshProUGUI txtDmg;


    public void ADDSlot(Pickaxe _p)
    {
        icon.sprite = _p.icon;
        txtName.SetText("" + _p.name);
        txtDmg.SetText("ATK:" + _p.damageMin);

    }
}
