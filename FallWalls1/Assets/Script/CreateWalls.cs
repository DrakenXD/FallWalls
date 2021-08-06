using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CreateWalls : MonoBehaviour
{
    [SerializeField] private int level;

    [SerializeField] private Wall[] TypeWalls;
    [SerializeField] private float timespawn;
    [SerializeField] private GameObject LastWall;

    [SerializeField] private int AmountWallCreated;
    [SerializeField] private int indexWall;

    [Header("Attack")]
    [SerializeField] private GameObject[] TotalWalls;
    [SerializeField] private Transform target;
    [SerializeField] private GameObject Attackwall;
    [SerializeField] private float reiniciarwave = 3f;

    [Header("UI")]
    [SerializeField] private Image barLife;
    [SerializeField] private TextMeshProUGUI txtName;
    [SerializeField] private TextMeshProUGUI txtLife;
    [SerializeField] private TextMeshProUGUI txtLevel;


    private void Awake()
    {
        level = 1;

        target = GameObject.FindGameObjectWithTag("Player").transform;

        txtLevel.SetText(level+" :level");
    }

    private void Start()
    {
        SearchWall();
    }

    // Update is called once per frame
    void Update()
    {
        if (indexWall == AmountWallCreated && TotalWalls.Length <= 0)
        {
            if (reiniciarwave <= 0)
            {
                level ++;
                indexWall = 0;
                reiniciarwave = 3f;
                txtLevel.SetText(level + " :level");
            }
            else reiniciarwave -= Time.deltaTime;
        }

        if (timespawn <= 0 && indexWall < AmountWallCreated)
        {


            for (int i = 1; i < TypeWalls.Length; i++)
            {
                if (TypeWalls[i].MinLevel <= level && TypeWalls[i].MaxLevel >= level)
                {
                    CreateWall(i);

                    timespawn = TypeWalls[i].timeSpawn;
                }
            }
            

            indexWall++;
        }
        else
        {
            timespawn -= Time.deltaTime;
        }
    }

    private void LateUpdate()
    {
        TotalWalls = GameObject.FindGameObjectsWithTag("Wall");
    }

    public void AttackWall(int dmg)
    {
        
        GameObject nearestWall = null;

        foreach (GameObject _wall in TotalWalls)
        {
            GameObject Findwall = GameObject.FindGameObjectWithTag("Wall");

            if (Vector2.Distance(Findwall.transform.position, target.position) <= 20f)
            {
                nearestWall = Findwall;
            }
        }

        if (nearestWall != null)
        {
            Attackwall = nearestWall;
          
            Attackwall.GetComponent<WallController>().TakeDamage(dmg);


            BarLife(Attackwall.GetComponent<WallController>().life, Attackwall.GetComponent<WallController>().GetMaxLife());
            TxtName(Attackwall.GetComponent<WallController>().GetName());
        }
        else
        {
            Attackwall = null;
        }

        
    }
    public void SearchWall()
    {
        StartCoroutine(TimeTosearch());
    }
    private IEnumerator TimeTosearch()
    {
        yield return new WaitForSeconds(.1f);
        GameObject nearestWall = null;

        foreach (GameObject _wall in TotalWalls)
        {
            GameObject Findwall = GameObject.FindGameObjectWithTag("Wall");

            if (Vector2.Distance(Findwall.transform.position, target.position) <= 20f)
            {
                nearestWall = Findwall;
            }
        }

        if (nearestWall != null)
        {
            Attackwall = nearestWall;

            BarLife(Attackwall.GetComponent<WallController>().life, Attackwall.GetComponent<WallController>().GetMaxLife());

            TxtName(Attackwall.GetComponent<WallController>().GetName());

           
        }
        else
        {
            Attackwall = null;
        }
    }
    public void CreateWall(int index)
    {
        GameObject cloneWall = Instantiate(TypeWalls[index].prefabWall, transform.position, Quaternion.identity);
        LastWall = cloneWall;
        SearchWall();
    }


   
    public void TxtName(string name)
    {
        txtName.SetText(""+name);
    }
    public void BarLife(float lifeMin, float lifeMax)
    {
        barLife.fillAmount = lifeMin/lifeMax;
        txtLife.SetText(lifeMin + "/" + lifeMax);
    }
}
