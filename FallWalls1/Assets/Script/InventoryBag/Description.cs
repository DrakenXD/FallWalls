using TMPro;
using UnityEngine;

public class Description : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI txtDescription;
    public void UpdateDescription(Item item)
    {
        if (!txtDescription.enabled) txtDescription.enabled = true;
        txtDescription.SetText(item.description);
    }
}
