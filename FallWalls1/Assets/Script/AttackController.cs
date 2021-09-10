using UnityEngine;

public class AttackController : MonoBehaviour
{
    public Pickaxe pickaxe;

    private void Start()
    {
        SetPickaxe(FindObjectOfType<InventoryController>().GetPickaxe());
    }

    public void Attack()
    {
        int rdDamage = Random.Range(pickaxe.damageMin, pickaxe.damageMax);
        int rdDamageElement = Random.Range(pickaxe.damageElementsMin, pickaxe.damageElementsMax);

        FindObjectOfType<CreateWalls>().AttackWall(pickaxe.elements, rdDamage, rdDamageElement);
    }


    public void SetPickaxe(Pickaxe _p)
    {
        pickaxe = _p;
    }
}
