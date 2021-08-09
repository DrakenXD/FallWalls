using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CreateWalls : MonoBehaviour
{

    [SerializeField] private Wall[] TypeWalls;
    [SerializeField] private float timespawn;
    [SerializeField] private GameObject LastWall;

    [SerializeField] private int AmountWallCreated;
    [SerializeField] private int indexWall;

    [Header("Attack")]
    [SerializeField] private GameObject[] TotalWalls;
    [SerializeField] private Transform target;
    [SerializeField] private GameObject Attackwall;
    [SerializeField] private float ReiniciarWave=3;
    [SerializeField] private float R_wave;

    [Header("UI")]
    [SerializeField] private Image barLife;
    [SerializeField] private TextMeshProUGUI txtName;
    [SerializeField] private TextMeshProUGUI txtLife;
    [SerializeField] private TextMeshProUGUI txtLevel;

    [Header("NextFase")]
    [SerializeField] private GameObject I_NextFase;
    [SerializeField] private GameObject I_BackFase;


    private void Awake()
    {
        SaveScore.instance.levelInGame = 1;

        SaveScore.instance.Load(SaveScore.TypeSave.Level);

        target = GameObject.FindGameObjectWithTag("Player").transform;

        txtLevel.SetText(SaveScore.instance.levelInGame + " :level");
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
            if (R_wave <= 0)
            {
              
                indexWall = 0;
                R_wave = ReiniciarWave;
           
            }
            else R_wave -= Time.deltaTime;
        }

        if (timespawn <= 0 && indexWall < AmountWallCreated)
        {


            for (int i = 1; i < TypeWalls.Length; i++)
            {
                if (TypeWalls[i].LevelSpawn == SaveScore.instance.levelInGame)
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

    public void Nextlevel()
    {
        SaveScore.instance.levelInGame++;

        SaveScore.instance.Save(SaveScore.TypeSave.Level);

        txtLevel.SetText(SaveScore.instance.levelInGame + " :level");
    }

    private void LateUpdate()
    {
        TotalWalls = GameObject.FindGameObjectsWithTag("Wall");
    }

    public void AttackWall(Elements elements, int dmg, int dmgElements)
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
          
            Attackwall.GetComponent<WallController>().TakeDamage(elements,dmg,dmgElements);


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
