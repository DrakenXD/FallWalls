using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InvSlotSword : MonoBehaviour
{
    [SerializeField] private Image iconS;
    [SerializeField] private TextMeshProUGUI txtNameS;
    [SerializeField] private TextMeshProUGUI txtAttack;

    [SerializeField] private GameObject mark;
    private bool usingP;

    [SerializeField] Swords s;

    public void ADDSlot(Swords _s)
    {
        s = _s;

        iconS.sprite = _s.sword.icon;
        txtNameS.SetText(""+_s.sword.name);
        txtAttack.SetText("ATK: "+_s.sword.damageMin+ "/"+ _s.sword.damageMax);



        if (_s.Use)
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

        FindObjectOfType<InventorySwordSlot>().UseSword(s);

        FindObjectOfType<InventoryController>().Save();
    }

}
