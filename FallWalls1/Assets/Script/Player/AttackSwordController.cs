using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSwordController : MonoBehaviour
{
    public int damage;

    [SerializeField] private Transform attackPoint;
    [SerializeField] private float distanceAttack;
    [SerializeField] private Animator anim;
    

    public void ActivateAnimAttack(){
        anim.SetBool("Attack",true);
    }
    public void Attack(){
        Collider2D[] col = Physics2D.OverlapCircleAll(attackPoint.position,distanceAttack);
        foreach(Collider2D hit in col){
            if(hit.gameObject.CompareTag("Enemy")){
                hit.gameObject.GetComponent<EnemyController>().TakeDamage(damage);
                
            }
            anim.SetBool("Attack",false);
        }
    }
    private void OnDrawGizmosSelected() {
        Gizmos.color=Color.red;
        Gizmos.DrawWireSphere(attackPoint.position,distanceAttack);
    }
}
