using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "ItemData")]
public class ItemData : ScriptableObject, ISerializationCallbackReceiver
{
    public Item[] Item;

    public Dictionary<Item, int> getId = new Dictionary<Item, int>();
    public Dictionary<int, Item> GetItem = new Dictionary<int, Item>();
    public void OnAfterDeserialize()
    {
        getId = new Dictionary<Item, int>();
        GetItem = new Dictionary<int, Item>();

        for (int i = 0; i < Item.Length; i++)
        {
            getId.Add(Item[i], i);
            GetItem.Add(i, Item[i]);
        }
    }



    public void OnBeforeSerialize()
    {

    }
}
