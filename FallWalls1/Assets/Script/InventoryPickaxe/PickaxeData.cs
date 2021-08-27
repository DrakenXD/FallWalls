using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "PickaxeData", menuName = "PickaxeData")]
public class PickaxeData : ScriptableObject, ISerializationCallbackReceiver
{
    public Pickaxe[] pickaxe;

    public Dictionary<Pickaxe, int> getId = new Dictionary<Pickaxe, int>();
    public Dictionary<int, Pickaxe> GetItem = new Dictionary<int, Pickaxe>();
    public void OnAfterDeserialize()
    {
        getId = new Dictionary<Pickaxe, int>();
        GetItem = new Dictionary<int, Pickaxe>();

        for (int i = 0; i < pickaxe.Length; i++)
        {
            getId.Add(pickaxe[i], i);
            GetItem.Add(i, pickaxe[i]);
        }
    }



    public void OnBeforeSerialize()
    {

    }
}

