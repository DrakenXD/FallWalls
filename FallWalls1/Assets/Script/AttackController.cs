using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    public PickaxeController pickaxe;

    public void Attack()
    {
        int rdDamage = Random.Range(pickaxe.damageMin, pickaxe.damageMax);
        int rdDamageElement = Random.Range(pickaxe.damageElementsMin, pickaxe.damageElementsMax);

        FindObjectOfType<CreateWalls>().AttackWall(pickaxe.elements, rdDamage, rdDamageElement);
    }
}
