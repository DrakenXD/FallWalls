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

    [SerializeField] private GameObject mark;
    private bool usingP;

    [SerializeField] Pickaxes p;

    public void ADDSlot(Pickaxes _p)
    {
        p = _p;

        iconP.sprite = _p.pickaxe.icon;
        txtNameP.SetText(""+_p.pickaxe.name);
        txtAttack.SetText("ATK: "+_p.pickaxe.damageMin+ "/"+ _p.pickaxe.damageMax);



        if (_p.Use)
        {
            UpdateMark(true);
            usingP = true;
        }

    }

    public void UpdateMark(bool _mark)
    {
        mark.SetActive(_mark);
    }

    public void ButtonUse()
    {
        if (usingP)
        {
            UpdateMark(false);
        }else UpdateMark(true);

        FindObjectOfType<InventoryPickaxeSlot>().UsePickaxe(p);

        FindObjectOfType<InventoryController>().Save();
    }
}
