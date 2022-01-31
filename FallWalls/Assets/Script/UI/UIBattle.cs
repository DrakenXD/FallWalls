using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
public class UIBattle : MonoBehaviour
{   
    public static UIBattle instance;
    private void Awake() {
        instance=this;
    }

    [SerializeField] private Image uiBattle;
    [SerializeField] private TextMeshProUGUI txtBattle;

    public int wave;
    public int amountEnemy;
    public int MaxAmountEnemy;
    
    
    public void UIUpdate(){       
        float a = amountEnemy;
        float b = MaxAmountEnemy;
        
        uiBattle.fillAmount = a /b;  
        txtBattle.SetText($"Wave: {wave}");
    }
}
