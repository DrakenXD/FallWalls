using System.Collections;
using UnityEngine;



public class WallController : MonoBehaviour
{
    [SerializeField] private Wall wall;
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private GameObject txtDamage;
    [SerializeField] private ElementsController elements;
    

    public float life;
    public const float speed = 1.5f;


    private void Start()
    {
        life = wall.MaxLife;

        sprite.sprite = wall.spriteWall[Random.Range(0, wall.spriteWall.Length)];
    }

    private void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    public void TakeDamage(Elements elements, int dmg, int dmgElements)
    {

        life -= dmg;
        life -= dmgElements;

        StartCoroutine("AnimationDamage");

        

        GameObject txtdamage = Instantiate(txtDamage, new Vector3(Random.Range(transform.position.x - 2f, transform.position.x + 2f), Random.Range(transform.position.y - .2f, transform.position.y + .2f), 5), Quaternion.identity);
        txtdamage.GetComponent<TextMesh>().text = "" + dmg;

        Destroy(txtdamage, 3f);

        if (elements != Elements.None)
        {
            GameObject txtdamageElements = Instantiate(txtDamage, new Vector3(txtdamage.transform.position.x + .5f, txtdamage.transform.position.y + .5f, 5), Quaternion.identity);
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

        if (life <= 0)
        {
            int rdCoin = Random.Range(wall.CoinMin, wall.CoinMax);
            int rdExp = Random.Range(wall.ExpMin, wall.ExpMax);

            //adicionar item no inventario
            FindObjectOfType<InventoryController>().AddItem(wall.itens[Random.Range(0,wall.itens.Length)], 
                Random.Range(wall.ItensMin, wall.ItensMax));

            //adicionar item na HUD do final
            FindObjectOfType<GameController>().AddItem(wall.itens[Random.Range(0, wall.itens.Length)], 
                Random.Range(wall.ItensMin, wall.ItensMax));


            GameController.instance.AddExpMining(rdExp);

            life = 0;

            GameObject effect = Instantiate(wall.prefabEffect, transform.position, Quaternion.identity);

            CreateWalls.AmountKillsToNextFase--;

            FindObjectOfType<CreateWalls>().UpdateVerifylevel();

            Destroy(effect, 3f);

            Destroy(gameObject);

            
        }
    }

    private IEnumerator AnimationDamage()
    {
        sprite.color = Color.red;
        yield return new WaitForSeconds(.1f);
        sprite.color = Color.white;
    }



    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerController>().TakeDamage(1);
            Destroy(gameObject);
        }
    }
    public float GetPositionY()
    {
        return transform.position.y;
    }
    public string GetName()
    {
        return wall.nameWall;
    }
    public float GetMaxLife()
    {
        return wall.MaxLife;
    }
}
