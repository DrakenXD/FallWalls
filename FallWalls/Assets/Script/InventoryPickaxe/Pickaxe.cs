using UnityEngine;


public enum Elements
{
    None,
    Lightning,
    Fire,
    Wind,
    Water,
}
[System.Serializable]
public class ItemRecipe
{
    public Item item;
    public int amount;
}

[CreateAssetMenu(fileName = "Picareta", menuName = "Pickaxe/New")]
public class Pickaxe : ScriptableObject
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
