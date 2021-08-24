using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public int life;
    public bool isDeath;

    public bool CanMove;

    public void TakeDamage(int dmg)
    {
        life -= dmg;

        if (life <= 0)
        {
            GameController.instance.ShowScreenDeath();

            SaveScore.instance.Save(SaveScore.TypeSave.Coin);

            if (GameController.instance.typeGamePlay == GameController.TypeGamePlay.Mining) 
            { 
                SaveScore.instance.Save(SaveScore.TypeSave.LevelMining);
                SaveScore.instance.Save(SaveScore.TypeSave.ExpMining);
                SaveScore.instance.Save(SaveScore.TypeSave.ExpMiningMark);
            } 
            else if(GameController.instance.typeGamePlay == GameController.TypeGamePlay.Battle) 
            {
                SaveScore.instance.Save(SaveScore.TypeSave.LevelBattle); 
            }

            isDeath = true;
        }
    }
}
