using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour
{
    [SerializeField] private Wall wall;
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private GameObject txtDamage;
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

    public void TakeDamage(Elements elements,int dmg, int dmgElements)
    {
        life -= dmg;
        life -= dmgElements;

        StartCoroutine("AnimationDamage");

        FindObjectOfType<CreateWalls>().BarLife(life,wall.MaxLife);

        GameObject txtdamage = Instantiate(txtDamage, new Vector3(Random.Range(transform.position.x - 2f, transform.position.x + 2f), Random.Range(transform.position.y - .2f, transform.position.y + .2f), 5) , Quaternion.identity);
        txtdamage.GetComponent<TextMesh>().text = "" + dmg;

        if (elements!=Elements.None)
        {
            GameObject txtdamageElements = Instantiate(txtDamage, new Vector3(txtdamage.transform.position.x + .5f, txtdamage.transform.position.y + .5f, 5), Quaternion.identity);
            txtdamageElements.GetComponent<TextMesh>().fontSize = 40;
            txtdamageElements.GetComponent<TextMesh>().text = "" + dmgElements;

            switch (elements)
            {
                case Elements.Lightning:
                    txtdamageElements.GetComponent<TextMesh>().color = Color.yellow;
                    break;
                case Elements.Fire:
                    txtdamageElements.GetComponent<TextMesh>().color = Color.red;
                    break;
                case Elements.Water:
                    txtdamageElements.GetComponent<TextMesh>().color = Color.cyan;
                    break;
                case Elements.Wind:
                    txtdamageElements.GetComponent<TextMesh>().color = Color.gray;
                    break;

            }
        }

        if (life <= 0)
        {
            life = 0;

            GameController.instance.AddCoin(5);

            GameObject effect = Instantiate(wall.prefabEffect,transform.position,Quaternion.identity);

            FindObjectOfType<CreateWalls>().SearchWall();

            FindObjectOfType<CreateWalls>().UpdateVerifylevel();

            CreateWalls.AmountKillsToNextFase--;

            Destroy(txtdamage,3f);

            Destroy(effect,3f);

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
