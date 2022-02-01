using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSwordController : MonoBehaviour
{
    [SerializeField] Sword s;

    [SerializeField] private Transform attackPoint;
    [SerializeField] private Animator anim;
    
    [SerializeField] private Sword firstSword;
    private void Start()
    {
        if(FindObjectOfType<InventoryController>().HaveSword()){
            s = FindObjectOfType<InventoryController>().GetSwordUsed();
        }else{
            s=firstSword;
        }
        
    }

    public void ActivateAnimAttack(){
        anim.SetBool("Attack",true);
    }
    public void Attack(){
        Collider2D[] col = Physics2D.OverlapCircleAll(attackPoint.position, s.range);
        
        foreach(Collider2D hit in col){
            if(hit.gameObject.CompareTag("Enemy")){
                
                hit.gameObject.GetComponent<EnemyController>().TakeDamage(s.elements, Random.RandomRange(s.damageMin,s.damageMax), 
                Random.RandomRange(s.damageElementsMin,s.damageElementsMax));              
            }
            anim.SetBool("Attack",false);
        }
    }
    private void OnDrawGizmosSelected() {
        Gizmos.color=Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, s.range);
    }
}
