using UnityEngine;

[CreateAssetMenu(fileName ="Wall",menuName ="Wall/New")]
public class Wall : ScriptableObject
{
    [Header("          Settings")]
    public string Name;
    public float MaxLife;
    public GameObject prefabWall;
    public GameObject prefabEffect;
    public float timeSpawn;
}
