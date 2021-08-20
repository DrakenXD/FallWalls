using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item",menuName ="Item/New")]
public class Item : ScriptableObject
{
    public int id;
    public string nameItem;
    public Sprite sprite;
    [TextArea]public string description;
    public int MaxStack;

}
