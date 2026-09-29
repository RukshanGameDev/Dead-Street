using NUnit.Framework.Interfaces;
using UnityEngine;
public class EnemyCombat : MonoBehaviour
{
    [SerializeField]
    private InventoryManager playerInventory;
    private EnemyController enemy;
    private void Awake()
    {
        enemy =
        GetComponent<EnemyController>();
    }
    public void OnAttackHit()
    {
        if (playerInventory == null)
        {
            Debug.LogWarning(
            "Player inventory is not assigned.");
            return;
        }
        if (!enemy.IsPlayerInAttackRange())
            return;
        ItemData stolenItem =
        playerInventory.RemoveRandomItem();
        if (stolenItem == null)
        {
            EventManager.Instance
            .ShowInteractionMessage(
            "Enemy could not steal an item.");
            
            return;
        }
        if (enemy.Inventory != null)
        {
            enemy.Inventory.AddItem(
            stolenItem);
        }
        EventManager.Instance
        .ItemStolen(stolenItem);
       
    }
}
