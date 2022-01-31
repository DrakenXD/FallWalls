using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "SwordData", menuName = "SwordData")]
public class SwordData : ScriptableObject, ISerializationCallbackReceiver
{
    public Sword[] sword;

    public Dictionary<Sword, int> getId = new Dictionary<Sword, int>();
    public Dictionary<int, Sword> GetItem = new Dictionary<int, Sword>();
    public void OnAfterDeserialize()
    {
        getId = new Dictionary<Sword, int>();
        GetItem = new Dictionary<int, Sword>();

        for (int i = 0; i < sword.Length; i++)
        {
            getId.Add(sword[i], i);
            GetItem.Add(i, sword[i]);
        }
    }



    public void OnBeforeSerialize()
    {

    }
}

