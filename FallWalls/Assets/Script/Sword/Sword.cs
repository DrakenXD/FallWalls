using UnityEngine;




[CreateAssetMenu(fileName = "Espadas", menuName = "Swords/New")]
public class Sword : ScriptableObject
{  
    [Header("          Settings")]
    public new string name;
    public Sprite icon;
    [TextArea] public string description;
    public float range;
    public int damageMin;
    public int damageMax;

    
    [Header("          Elements")]
    public Elements elements;
    public int damageElementsMin;
    public int damageElementsMax;


    [Header("          Recipe")]
    public ItemRecipe[] recipe;
    

    [Header("          Shop")]
    public int value;

}
