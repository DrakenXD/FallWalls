using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Swords
{
    public string nameSwords;
    public int ID;

    public Sword sword;
    public bool Use;
    public Swords(string _nameSwords, int id, Sword _Swords, bool _use)
    {
        this.nameSwords = _nameSwords;
        this.ID = id;
        this.sword = _Swords;
        this.Use = _use;
    }
}
