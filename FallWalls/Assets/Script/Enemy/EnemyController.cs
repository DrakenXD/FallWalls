using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{   
    [Header("Status")]
    [SerializeField] private float maxLife;
    private float life;
    [SerializeField] private float maxSpeed;
    private float speed;
    [SerializeField] private int maxDamage;
    private int damage;

    [SerializeField] private int dropCoin;
    [SerializeField] private int dropExp;

    [Header("AttackController")]
    [SerializeField]private bool isAttacking;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float distanceAttack;
    private Transform  target;
    private Collider2D[] col;
    
    [Header("AttackTime")]
    [SerializeField]private float TimeAttack;
    private float t_attack;

    [Header("Components Unity")]
    [SerializeField] private Image UILife;
    [SerializeField] private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;

        life = maxLife;
        speed = maxSpeed;
        t_attack = TimeAttack;
        damage = maxDamage;
    }

    // Update is called once per frame
    void Update()
    {
        col = Physics2D.OverlapCircleAll(attackPoint.position,distanceAttack);

        //atacar
        if(isAttacking){

            anim.SetBool("Attack",true);
            transform.position = new Vector2(transform.position.x,transform.position.y);

        }else{
            //colidindo com o player
            foreach(Collider2D hit in col){
                if(hit.gameObject.CompareTag("Player")){
                    transform.position = new Vector2(transform.position.x,transform.position.y);
                
                    isAttacking = true;
                }
            }

            if(!isAttacking){
                //andando em direção ao player
                transform.Translate(Vector2.right * speed * Time.deltaTime);
            
                if(target.position.x > transform.position.x){
                    transform.localEulerAngles= new Vector3(0,0,0);
                }else if(target.position.x < transform.position.x){
                    transform.localEulerAngles= new Vector3(0,180,0);
                }
            }
            
        }
        
    }
    public void Attack(){
        foreach(Collider2D hit in col){
            if(hit.gameObject.CompareTag("Player")){
                hit.gameObject.GetComponent<PlayerController>().TakeDamage(damage);     
                FindObjectOfType<AudioController>().PlayAudio("Attack"); 
            }
        }
        
        
        isAttacking=false;
        anim.SetBool("Attack",false);
    }   

    public void TakeDamage(int dmg){
        life-=dmg;

        UILife.fillAmount = life / maxLife;

        if(life <= 0){
            UIBattle.instance.amountEnemy--;

            int rd = Random.Range(0,11);
            if(rd <=5){
                FindObjectOfType<AudioController>().PlayAudio("DeathBW"); 
            }else FindObjectOfType<AudioController>().PlayAudio("Death"); 
            
            FindObjectOfType<UIBattle>().UIUpdate();

            GameController.instance.AddCoin(dropCoin);
            GameController.instance.AddExpBattle(dropExp);
            
            Destroy(gameObject);
        } 
        
    }
    private void OnDrawGizmos() {
        Gizmos.color=Color.red;
        Gizmos.DrawWireSphere(attackPoint.position,distanceAttack);
    }
}
