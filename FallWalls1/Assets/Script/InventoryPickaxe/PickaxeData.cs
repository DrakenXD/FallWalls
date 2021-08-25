using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "PickaxeData", menuName = "PickaxeData")]
public class PickaxeData : ScriptableObject, ISerializationCallbackReceiver
{
    public PickaxeController[] pickaxe;

    public Dictionary<PickaxeController, int> getId = new Dictionary<PickaxeController, int>();
    public Dictionary<int, PickaxeController> GetItem = new Dictionary<int, PickaxeController>();
    public void OnAfterDeserialize()
    {
        getId = new Dictionary<PickaxeController, int>();
        GetItem = new Dictionary<int, PickaxeController>();

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

