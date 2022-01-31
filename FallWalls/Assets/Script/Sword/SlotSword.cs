using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SlotSword : MonoBehaviour
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

    private Sword s;
    [SerializeField] private int s_recipes;
  
    public void ADDSlot(Sword _s)
    {
        s = _s;

        icon.sprite = _s.icon;
        txtName.SetText("" + _s.name);
        txtDmg.SetText("" + _s.damageMin);

        for (int i = 0; i < _s.recipe.Length; i++) 
        {
            RecipesGameObject[i].SetActive(true);
            RecipesIcon[i].sprite = _s.recipe[i].item.sprite;
            txtRecipesAmount[i].SetText("" + _s.recipe[i].amount);

            
        }

        s_recipes = _s.recipe.Length;

        txtCoins.SetText("" + _s.value);

        if (FindObjectOfType<InventoryController>().SeachSword(_s))
        {
            screenPurcharsed.SetActive(true);
            buttonPurcharsed.SetActive(false);
        }


        if (PlayerPrefs.GetInt("SaveCoin") >= _s.value) txtCoins.color = Color.green;
        


    }

    public void purcharsed()
    {
        for (int i = 0; i < s.recipe.Length; i++) 
        {
            if (FindObjectOfType<InventoryController>().SearchItem(s.recipe[i].item,s.recipe[i].amount) 
            &&  PlayerPrefs.GetInt("SaveCoin") >= s.value)
            {
                
                screenPurcharsed.SetActive(true);
                buttonPurcharsed.SetActive(false);
                        
                Debug.Log($"teste1");

                FindObjectOfType<InventoryController>().AddSword(s);

                FindObjectOfType<ShopSwordSlot>().RemoveCoins(s.value);

                for (int i2 = 0; i2 < s_recipes; i2++)
                {
                    FindObjectOfType<InventoryController>().RemoveItem(s.recipe[i2].item, s.recipe[i2].amount);
                    Debug.Log($"{i2}");
                }   
                Debug.Log("Comprou");
                          
            }
            else
            {
                
                Debug.Log("falta " + s.recipe[i].item.name);
            }
        }

        
       
    }

}
