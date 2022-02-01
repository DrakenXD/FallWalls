using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    public bool isDeath;

    [SerializeField] private float Maxlife;
    [SerializeField] private float life;
    [SerializeField] private Animator anim;

    [Header("Battle")]
    
    [SerializeField] private Image barLife;
    public bool CanMove;
    public bool right;
    [SerializeField] private Collider2D col;
    
    [SerializeField] private Joystick joystick;
    private void Start() {
       life = Maxlife;
    }
    private void Update() {
        if(GameController.instance.typeGamePlay == TypeGamePlay.Battle){
            if(joystick.Horizontal > 0.2f){
                Moviment();
               
                transform.localEulerAngles = new Vector3(0,0,0); 
            }else if(joystick.Horizontal < -0.2f){
                Moviment();
               
                transform.localEulerAngles = new Vector3(0,180,0); 
            }else if(joystick.Horizontal < 0.2f && joystick.Horizontal > -0.2f){
                anim.SetBool("Move",false);
            } 
        }
    } 
    private void Moviment(){
        transform.Translate(Vector3.right * 2 * Time.deltaTime);
        anim.SetBool("Move",true);
    }
    public void TakeDamage(int dmg)
    {
        life -= dmg;

        if(barLife != null) barLife.fillAmount = life / Maxlife;

        if (life <= 0)
        {
            GameController.instance.ShowScreenDeath();
            
            FindObjectOfType<AudioController>().PlayAudio("Death");

           

            if (GameController.instance.typeGamePlay == TypeGamePlay.Mining)
            {   
                FindObjectOfType<InventoryController>().Save();
            
                SaveScore.instance.Save(SaveScore.TypeSave.LevelMining);
                SaveScore.instance.Save(SaveScore.TypeSave.ExpMining);
                SaveScore.instance.Save(SaveScore.TypeSave.ExpMiningMark);
            }
            else if (GameController.instance.typeGamePlay == TypeGamePlay.Battle)
            {
                SaveScore.instance.Save(SaveScore.TypeSave.LevelBattle);
                SaveScore.instance.Save(SaveScore.TypeSave.Coin);
                SaveScore.instance.Save(SaveScore.TypeSave.ExpBattle);
                SaveScore.instance.Save(SaveScore.TypeSave.ExpBattleMark);    

                // faltar salvar itens    
            }

            

            col.enabled = true;

            isDeath = true;
        }else FindObjectOfType<AudioController>().PlayAudio("TakeDamage");
    }
}
