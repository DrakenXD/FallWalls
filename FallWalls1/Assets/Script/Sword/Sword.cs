using UnityEngine;




[CreateAssetMenu(fileName = "Espadas", menuName = "Swords/New")]
public class Sword : ScriptableObject
{
    public new string name;
    public Sprite icon;
    [TextArea] public string description;

    [Header("          Recipe")]
    public ItemRecipe[] recipe;
    public int value;

    public int damageMin;
    public int damageMax;

    public Elements elements;
    public int damageElementsMin;
    public int damageElementsMax;


}
