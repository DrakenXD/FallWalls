 using UnityEngine;

public class AttackPickaxeController : MonoBehaviour
{
    public Pickaxe pickaxe;

    private void Start()
    {
        if(FindObjectOfType<InventoryController>().HavePickaxe()){
            pickaxe = FindObjectOfType<InventoryController>().GetPickaxeUsed();
        }
        
    }

    public void Attack()
    {
        int rdDamage = Random.Range(pickaxe.damageMin, pickaxe.damageMax);
        int rdDamageElement = Random.Range(pickaxe.damageElementsMin, pickaxe.damageElementsMax);

        FindObjectOfType<CreateWalls>().AttackWall(pickaxe.elements, rdDamage, rdDamageElement);
    }


  
}
