using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public int life;
    public bool isDeath;

    
    public void TakeDamage(int dmg)
    {
        life -= dmg;

        if (life <= 0)
        {
            FindObjectOfType<NewScene>().NextScene("SampleScene");
            SaveScore.instance.Save(SaveScore.TypeSave.Coin);
            isDeath = true;
        }
    }
}
