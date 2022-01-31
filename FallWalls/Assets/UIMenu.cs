using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI txtCoins;

    private void Start() {
        UIUpdate();
    }
    public void UIUpdate(){
        txtCoins.SetText($"{PlayerPrefs.GetInt("SaveCoin")}");
    }
}
