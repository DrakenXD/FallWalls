using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    public PickaxeController pickaxe;

    public void Attack()
    {
        FindObjectOfType<CreateWalls>().AttackWall(pickaxe.elements,pickaxe.damage, pickaxe.damageElements);
    }
}
