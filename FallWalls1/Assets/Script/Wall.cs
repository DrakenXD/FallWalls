using UnityEngine;

[CreateAssetMenu(fileName = "Wall", menuName = "Wall/New")]
public class Wall : ScriptableObject
{
    [Header("          Settings")]
    public string nameWall;
    public float MaxLife;
    public Sprite[] spriteWall;
    public GameObject prefabWall;
    public GameObject prefabEffect;
    public float timeSpawn;

    [Header("          Item Drop")]
    public Item[] itens;
    public int ItensMin;
    public int ItensMax;

    [Header("          Coin Earned")]
    public int CoinMin;
    public int CoinMax;

    [Header("          Exp Earned")]
    public int ExpMin;
    public int ExpMax;

    [Header("          Level Spawn")]
    [Range(0, 999)] public int LevelSpawn;
}
