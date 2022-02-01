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
    [SerializeField] private ElementsController elements;
    [SerializeField] private GameObject GameObjectTxtDamage;
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

    public void TakeDamage(Elements elements ,int dmg, int dmgElements){
        life-=dmg;

        life -= dmgElements;

        UILife.fillAmount = life / maxLife;

        GameObject txtdamage = Instantiate(GameObjectTxtDamage, new Vector3(transform.position.x, transform.position.y), Quaternion.identity);

        txtdamage.GetComponent<TextMesh>().text = "" + dmg;
        txtdamage.GetComponent<TextMesh>().fontSize = 50;

        Destroy(txtdamage, 3f);

        if (elements != Elements.None)
        {
            GameObject txtdamageElements = Instantiate(GameObjectTxtDamage, new Vector3(txtdamage.transform.position.x + .5f, txtdamage.transform.position.y + .5f, 5), Quaternion.identity);
            txtdamageElements.GetComponent<TextMesh>().fontSize = 60;
            txtdamageElements.GetComponent<TextMesh>().text = "" + dmgElements;

            for (int i = 0; i < this.elements.TypeSprites.Length; i++)
            {
                if (this.elements.TypeSprites[i].elements == elements)
                {
                    FindObjectOfType<SpriteElements>().SetSpriteElement(this.elements.TypeSprites[i].sprite);

                    txtdamageElements.GetComponent<TextMesh>().color = this.elements.TypeSprites[i].color;
                }
            }

            Destroy(txtdamageElements, 3f);

        }



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
