using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Elements
{
    None,
    Lightning,
    Fire,
    Wind,
    Water,
}

[CreateAssetMenu(fileName = "Picareta", menuName ="Pickaxe/New")]
public class PickaxeController : ScriptableObject
{
    public new string name;
    public Sprite icon;
    [TextArea]public string description;
    public int damage;

    public Elements elements;
    public int damageElements;

    public void AttackElement(int dmg,TextMesh txt)
    {
        switch (elements)
        {
            case Elements.None:
                txt.color = Color.clear;
                break;
            case Elements.Lightning:
                txt.color = Color.yellow;
                break;
            case Elements.Fire:
                txt.color = Color.red;
                break;
            case Elements.Water:
                txt.color = Color.cyan;
                break;
            case Elements.Wind:
                txt.color = Color.gray;
                break;

        }
    }

}
