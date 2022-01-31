using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor;
using UnityEngine;


[CreateAssetMenu(fileName = "InventorySword", menuName = "InventorySword")]
public class InventorySword : ScriptableObject, ISerializationCallbackReceiver
{



    public string SavePath;
    private SwordData swordData;
    public List<Swords> container = new List<Swords>();

    private void OnEnable()
    {
#if UNITY_EDITOR
        swordData = (SwordData)AssetDatabase.LoadAssetAtPath("Assets/Resources/SwordDataBase.asset", typeof(SwordData));
#else
        swordData = Resources.Load<SwordData>("SwordDataBase");
#endif
    }

    public void AddItem(Sword _w)
    {
        container.Add(new Swords(_w.name, swordData.getId[_w], _w, false));
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

    public bool ContainSword(Sword _s)
    {
        for (int i = 0; i < container.Count; i++)
        {
            if (container[i].sword == _s)
            {
                return true;
            }
        }
        return false;
    }
    public bool ContainWeaponUse(Sword _s)
    {
        for (int i = 0; i < container.Count; i++)
        {
            if (container[i].sword == _s)
            {
                if (container[i].Use)
                {
                    return true;
                }
            }
        }
        return false;
    }

    public Sword GetSwordUsed()
    {
        for (int i = 0; i < container.Count; i++)
        {
            if (container[i].Use)
            {
                return container[i].sword;
            }
        }

        return null;
    }
    public bool HaveSword(){
        for (int i = 0; i < container.Count; i++)
        {
            if (container[i].Use)
            {
                return true;
            }
        }

        return false;
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
    public void UseWeapon(Sword _W)
    {
        for (int i = 0; i < container.Count; i++)
        {
            if (container[i].sword == _W)
            {


                container[i].Use = true;
            }
        }
    }

    public void OnAfterDeserialize()
    {
        if(container.Count > 0){
            for (int i = 0; i < container.Count; i++)
            {
                container[i].sword = swordData.GetItem[container[i].ID];
            }
        }
    }

    public void OnBeforeSerialize()
    {
        
    }
}


