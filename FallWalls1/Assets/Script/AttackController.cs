using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    

    public void Attack()
    {
        FindObjectOfType<CreateWalls>().AttackWall(10);
    }
}
