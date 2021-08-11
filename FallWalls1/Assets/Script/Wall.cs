using UnityEngine;

[CreateAssetMenu(fileName ="Wall",menuName ="Wall/New")]
public class Wall : ScriptableObject
{
    [Header("          Settings")]
    public string nameWall;
    public float MaxLife;
    public Sprite[] spriteWall;
    public GameObject prefabWall;
    public GameObject prefabEffect;
    public float timeSpawn;

    [Header("          Level Spawn")]
    [Range(0, 999)] public int LevelSpawn;
}
