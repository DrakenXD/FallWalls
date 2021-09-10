using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor;
using UnityEngine;


[CreateAssetMenu(fileName = "InventoryPicaxe", menuName = "InventoryPickaxe")]
public class InventoryPickaxe : ScriptableObject, ISerializationCallbackReceiver
{



    public string SavePath;
    private PickaxeData pickaxedata;
    public List<Pickaxes> container = new List<Pickaxes>();

    private void OnEnable()
    {
#if UNITY_EDITOR
        pickaxedata = (PickaxeData)AssetDatabase.LoadAssetAtPath("Assets/Resources/PickaxeDataBase.asset", typeof(PickaxeData));
#else
        pickaxedata = Resources.Load<PickaxeData>("PickaxeDataBase");
#endif
    }

    public void AddItem(Pickaxe _w)
    {
        container.Add(new Pickaxes(_w.name, pickaxedata.getId[_w], _w, false));
    }

    public void Save()
    {
        string saveData = JsonUtility.ToJson(this, true);
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(string.Concat(Application.persistentDataPath, SavePath));

        bf.Serialize(file, saveData);
        file.Close();
    }

    public void Load()
    {
        if (File.Exists(string.Concat(Application.persistentDataPath, SavePath)))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(string.Concat(Application.persistentDataPath, SavePath), FileMode.Open);
            JsonUtility.FromJsonOverwrite(bf.Deserialize(file).ToString(), this);
            file.Close();
        }
    }

    public bool ContainPickaxe(Pickaxe _p)
    {
        for (int i = 0; i < container.Count; i++)
        {
            if (container[i].pickaxe == _p)
            {
                return true;
            }
        }
        return false;
    }
    public bool ContainWeaponUse(Pickaxe _w)
    {
        for (int i = 0; i < container.Count; i++)
        {
            if (container[i].pickaxe == _w)
            {
                if (container[i].Use)
                {
                    return true;
                }
            }
        }
        return false;
    }

    public Pickaxe GetPickaxe()
    {
        for (int i = 0; i < container.Count; i++)
        {
            if (container[i].Use)
            {
                return container[i].pickaxe;
            }
        }

        return null;
    }

    public void DisableWeapon()
    {
        for (int i = 0; i < container.Count; i++)
        {
            if (container[i].Use == true)
            {
                container[i].Use = false;
            }
        }

    }
    public void UseWeapon(Pickaxe _W)
    {
        for (int i = 0; i < container.Count; i++)
        {
            if (container[i].pickaxe == _W)
            {


                container[i].Use = true;
            }
        }
    }

    public void OnAfterDeserialize()
    {
        for (int i = 0; i < container.Count; i++)
        {
            container[i].pickaxe = pickaxedata.GetItem[container[i].ID];
        }
    }

    public void OnBeforeSerialize()
    {
        Debug.Log("");
    }
}

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
