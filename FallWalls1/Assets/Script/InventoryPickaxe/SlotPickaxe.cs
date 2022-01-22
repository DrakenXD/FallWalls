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
  
    public void ADDSlot(Pickaxe _p)
    {
        p = _p;

        icon.sprite = _p.icon;
        txtName.SetText("" + _p.name);
        txtDmg.SetText("" + _p.damageMin);

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
        


    }

    public void purcharsed()
    {
        for (int i = 0; i < p.recipe.Length; i++) 
        {
            if (FindObjectOfType<InventoryController>().SearchItem(p.recipe[i].item,p.recipe[i].amount) 
            &&  PlayerPrefs.GetInt("SaveCoin") >= p.value)
            {
                
                screenPurcharsed.SetActive(true);
                buttonPurcharsed.SetActive(false);
                        
                Debug.Log($"teste1");

                FindObjectOfType<InventoryController>().AddPickaxe(p);

                FindObjectOfType<ShopPickaxeSlot>().RemoveCoins(p.value);

                for (int i2 = 0; i2 < p_recipes; i2++)
                {
                    FindObjectOfType<InventoryController>().RemoveItem(p.recipe[i2].item, p.recipe[i2].amount);
                    Debug.Log($"{i2}");
                }   
                Debug.Log("Comprou");
                          
            }
            else
            {
                
                Debug.Log("falta " + p.recipe[i].item.name);
            }
        }

        
       
    }

}
