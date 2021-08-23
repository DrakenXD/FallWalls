using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Description : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI txtDescription;
    public void UpdateDescription(Item item)
    {
        if (!txtDescription.enabled) txtDescription.enabled = true;
        txtDescription.SetText(item.description);
    }
}
