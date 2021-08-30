using UnityEngine;

public class AttackController : MonoBehaviour
{
    public Pickaxe pickaxe;

    public void Attack()
    {
        int rdDamage = Random.Range(pickaxe.damageMin, pickaxe.damageMax);
        int rdDamageElement = Random.Range(pickaxe.damageElementsMin, pickaxe.damageElementsMax);

        FindObjectOfType<CreateWalls>().AttackWall(pickaxe.elements, rdDamage, rdDamageElement);
    }
}
