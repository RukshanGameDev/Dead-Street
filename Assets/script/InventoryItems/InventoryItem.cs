using UnityEngine;
public class InventoryItem : MonoBehaviour
{
    [SerializeField]
    private ItemData itemData;
    public ItemData Data => itemData;
}
