using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SlotPickaxe : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private TextMeshProUGUI txtName;
    [SerializeField] private TextMeshProUGUI txtDmg;

    
    [SerializeField] private GameObject[] RecipesGameObject;
    [SerializeField] private Image[] RecipesIcon;
    [SerializeField] private TextMeshProUGUI[] txtRecipesAmount;
    [SerializeField] private TextMeshProUGUI txtCoins;
    public void ADDSlot(Pickaxe _p)
    {
        icon.sprite = _p.icon;
        txtName.SetText("" + _p.name);
        txtDmg.SetText("ATK:" + _p.damageMin);

        for (int i = 0; i < _p.recipe.Length; i++) 
        {
            RecipesGameObject[i].SetActive(true);
            RecipesIcon[i].sprite = _p.recipe[i].item.sprite;
            txtRecipesAmount[i].SetText("" + _p.recipe[i].amount);

        }

        txtCoins.SetText("" + _p.value);

        if (PlayerPrefs.GetInt("SaveCoin") >= _p.value) txtCoins.color = Color.green;
        else txtCoins.color = Color.red;
    }
}
