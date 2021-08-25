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
    public int value;
    public int damageMin;
    public int damageMax;

    public Elements elements;
    public int damageElementsMin;
    public int damageElementsMax;


}
