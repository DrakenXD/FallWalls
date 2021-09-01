using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SlotPickaxe : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private TextMeshProUGUI txtName;
    [SerializeField] private TextMeshProUGUI txtDmg;
    [SerializeField] private TextMeshProUGUI txtCoins;

    [SerializeField] private GameObject screenPurcharsed;
    [SerializeField] private GameObject buttonPurcharsed;

    [SerializeField] private GameObject[] RecipesGameObject;
    [SerializeField] private Image[] RecipesIcon;
    [SerializeField] private TextMeshProUGUI[] txtRecipesAmount;

    private Pickaxe p;
    [SerializeField] private int p_recipes;
    private bool haverecipe;
    public void ADDSlot(Pickaxe _p)
    {
        p = _p;

        icon.sprite = _p.icon;
        txtName.SetText("" + _p.name);
        txtDmg.SetText("ATK:" + _p.damageMin);

        for (int i = 0; i < _p.recipe.Length; i++) 
        {
            RecipesGameObject[i].SetActive(true);
            RecipesIcon[i].sprite = _p.recipe[i].item.sprite;
            txtRecipesAmount[i].SetText("" + _p.recipe[i].amount);
        }

        p_recipes = _p.recipe.Length;

        txtCoins.SetText("" + _p.value);

        if (FindObjectOfType<InventoryController>().SeachPickaxe(_p))
        {
            screenPurcharsed.SetActive(true);
            buttonPurcharsed.SetActive(false);
        }


        if (PlayerPrefs.GetInt("SaveCoin") >= _p.value) txtCoins.color = Color.green;
        else txtCoins.color = Color.red;


    }

    public void purcharsed()
    {
        bool haveAll = false;

        for (int i = 0; i < p.recipe.Length; i++) 
        {
            if (FindObjectOfType<InventoryController>().SearchItem(p.recipe[i].item,p.recipe[i].amount))
            {
                
                if (p.recipe.Length == p_recipes && haverecipe == true)
                {
                    screenPurcharsed.SetActive(true);
                    buttonPurcharsed.SetActive(false);

                    FindObjectOfType<InventoryController>().AddPickaxe(p);

                    haveAll = true;

                    Debug.Log("Comprou");
                }

                haverecipe = true;
            }
            else
            {
                haverecipe = false;
                Debug.Log("falta " + p.recipe[i].item.name);
            }
        }

        if (haveAll)
        {
            for (int i = 0; i < p_recipes; i++)
            {
                FindObjectOfType<InventoryController>().RemoveItem(p.recipe[i].item, p.recipe[i].amount);

            }
        }

       
    }

}
