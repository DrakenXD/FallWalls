using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour
{
    [SerializeField] private Wall wall;
    [SerializeField] private SpriteRenderer sprite;
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

    public void TakeDamage(int dmg)
    {
        life -= dmg;

        StartCoroutine("AnimationDamage");

        FindObjectOfType<CreateWalls>().BarLife(life,wall.MaxLife);

        if (life <= 0)
        {
            GameController.instance.AddCoin(5);

            GameObject effect = Instantiate(wall.prefabEffect,transform.position,Quaternion.identity);

            FindObjectOfType<CreateWalls>().SearchWall();

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
