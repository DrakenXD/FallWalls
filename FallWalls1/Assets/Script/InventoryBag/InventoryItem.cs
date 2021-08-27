using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

[CreateAssetMenu(fileName = "InventoryItem", menuName = "InventoryItem")]
public class InventoryItem : ScriptableObject, ISerializationCallbackReceiver
{
    public string SavePath;
    private ItemData itemdata;
    public List<InvItem> container = new List<InvItem>();

    private void OnEnable()
    {
#if UNITY_EDITOR
        itemdata = (ItemData)AssetDatabase.LoadAssetAtPath("Assets/Resources/ItemDataBase.asset", typeof(ItemData));
#else
        itemdata = Resources.Load<ItemData>("ItemDataBase");
#endif
    }

    public void AddItem(Item _i, int amount)
    {
        bool have = false;

        for (int i = 0; i < container.Count; i++) 
        {
            if (container[i].item ==  _i)
            {
                container[i].amount += amount;
                have = true;
            }
            

        }
        if (!have)
        {
            container.Add(new InvItem(_i.name, itemdata.getId[_i], _i, amount));
        }
    }


    public void RemoveItem(Item _i, int amount)
    {
        

        for (int i = 0; i < container.Count; i++)
        {
            if (container[i].item == _i)
            {
                if (container[i].amount >= amount)
                {
                    container[i].amount -= amount;
                }

                if (container[i].amount <= 0)
                {
                    container.Remove(container[i]);
                }
            }


        }
        FindObjectOfType<InventoryItemSlot>().UpdateSlots();
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

    public bool ContainWeapon(Item _I)
    {
        for (int i = 0; i < container.Count; i++)
        {
            if (container[i].item == _I)
            {
                return true;
            }
        }
        return false;
    }






    public void OnAfterDeserialize()
    {
        for (int i = 0; i < container.Count; i++)
        {
            container[i].item = itemdata.GetItem[container[i].ID];
        }
    }

    public void OnBeforeSerialize()
    {

    }

}

[System.Serializable]
public class InvItem
{
    public string nameItem;
    public int ID;
    public Item item;
    public int amount;
    public InvItem(string _nameItem ,int id, Item _item, int _amount)
    {
        this.nameItem = _nameItem;
        this.ID = id;
        this.item = _item;
        this.amount = _amount;
    }

}
