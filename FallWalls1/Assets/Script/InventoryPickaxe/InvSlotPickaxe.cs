using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InvSlotPickaxe : MonoBehaviour
{
    [SerializeField] private Image iconP;
    [SerializeField] private TextMeshProUGUI txtNameP;
    [SerializeField] private TextMeshProUGUI txtAttack;

    [SerializeField] private Toggle usingP;

    [SerializeField] Pickaxes p;

    public void ADDSlot(Pickaxes _p)
    {
        p = _p;

        iconP.sprite = _p.pickaxe.icon;
        txtNameP.SetText(""+_p.pickaxe.name);
        txtAttack.SetText("ATK: "+_p.pickaxe.damageMin+ "/"+ _p.pickaxe.damageMax);



        if (_p.Use)
        {
            usingP.isOn = true;
        }

    }

    public void UpdateMark(bool mark)
    {
        usingP.isOn = mark;
    }

    public void ButtonUse(bool active)
    {

        FindObjectOfType<InventoryPickaxeSlot>().UsePickaxe(p);
        FindObjectOfType<InventoryController>().Save();
    }
}
