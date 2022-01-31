using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Pickaxes
{
    public string namePickaxe;
    public int ID;

    public Pickaxe pickaxe;
    public bool Use;
    public Pickaxes(string _namePickaxe, int id, Pickaxe _pickaxe, bool _use)
    {
        this.namePickaxe = _namePickaxe;
        this.ID = id;
        this.pickaxe = _pickaxe;
        this.Use = _use;
    }
}
