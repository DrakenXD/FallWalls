using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


[CreateAssetMenu(fileName = "InventoryPicaxe", menuName = "InventoryPickaxe")]
public class InventoryPickaxe : ScriptableObject, ISerializationCallbackReceiver
{



    public string SavePath;
    private PickaxeData pickaxedata;
    public List<Pickaxe> container = new List<Pickaxe>();

    private void OnEnable()
    {
#if UNITY_EDITOR
        pickaxedata = (PickaxeData)AssetDatabase.LoadAssetAtPath("Assets/Resources/DataBase.asset", typeof(PickaxeData));
#else
        pickaxedata = Resources.Load<PickaxeData>("DataBase");
#endif
    }

    public void AddItem(PickaxeController _w)
    {
        container.Add(new Pickaxe(pickaxedata.getId[_w], _w, false));
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

    public bool ContainWeapon(PickaxeController _p)
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
    public bool ContainWeaponUse(PickaxeController _w)
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

    public PickaxeController WeaponAttack()
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
    public void UseWeapon(PickaxeController _W)
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

    }


}

[System.Serializable]
public class Pickaxe
{
    public int ID;

    public PickaxeController pickaxe;
    public bool Use;
    public Pickaxe(int id, PickaxeController _pickaxe, bool _use)
    {
        this.ID = id;
        this.pickaxe = _pickaxe;
        this.Use = _use;
    }

}
