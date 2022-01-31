using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private Transform[] spawnpoint;
    [SerializeField] private float TimeSpawn;
    private float t_spawn;

    [SerializeField] private int amountEnemy;
    public bool nextWave;
    public Wave[] wave;
    

    private void Update() {     
        if(nextWave){
            if(t_spawn <= 0){
                
                Spawn();
            }else t_spawn -= Time.deltaTime;
        }

             
    }
    
    private void LateUpdate() {
        if(UIBattle.instance.amountEnemy <= 0){
            nextWave=true;           
        }    
    }

    private void Spawn(){
          
        if(UIBattle.instance.amountEnemy <= 0){
            UIBattle.instance.amountEnemy = wave[UIBattle.instance.wave].Enemy.amount;
            
            UIBattle.instance.MaxAmountEnemy= wave[UIBattle.instance.wave].Enemy.amount;

            UIBattle.instance.wave++;

            UIBattle.instance.UIUpdate();

            amountEnemy = 0;              
        }     
        
        if(wave[UIBattle.instance.wave].Enemy.amount > amountEnemy){

            GameObject enemy = wave[UIBattle.instance.wave].Enemy.
            enemyObject[Random.Range(0,wave[UIBattle.instance.wave].Enemy.enemyObject.Length)];
            
            Instantiate(enemy,spawnpoint[Random.Range(0,spawnpoint.Length)].position,Quaternion.identity);

            t_spawn =TimeSpawn;

            amountEnemy++;
        }

        if(wave[UIBattle.instance.wave].Enemy.amount == amountEnemy){
            nextWave=false;
        }

    }

}
   
    [System.Serializable]
    public class Wave{
        public int Numberwave;
        public AmountEnemy Enemy;
    }
    [System.Serializable]
    public class AmountEnemy{
        public GameObject[] enemyObject;
        public int amount;
    }
