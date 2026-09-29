using UnityEngine;
[CreateAssetMenu(
 fileName = "NewItem",
 menuName = "Game/Inventory/Item Data")]
public class ItemData : ScriptableObject
{
    [Header("Item Information")]
    public string itemId;
    public string itemName;
    [Header("UI")]
    public Sprite icon;
    [Header("World")]
    public GameObject prefab;
}
