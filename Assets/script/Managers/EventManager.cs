using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance { get; private set; }
    public event Action<ItemData> OnItemAdded;
    public event Action<ItemData> OnItemRemoved;
    public event Action<ItemData> OnItemSelected;
    public event Action OnInventoryChanged;
    public event Action<string>
    OnInteractionMessage;
    public event System.Action<ItemData>
    OnItemStolen;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
    public void ItemAdded(ItemData item)
    {
        OnItemAdded?.Invoke(item);
    }
    public void ItemRemoved(ItemData item)
    {
        OnItemRemoved?.Invoke(item);
    }
    public void ItemSelected(ItemData item)
    {
        OnItemSelected?.Invoke(item);
    }
    public void InventoryChanged()
    {
        OnInventoryChanged?.Invoke();
    }
    public void ShowInteractionMessage(string message)
    {
        OnInteractionMessage?.Invoke(message);
    }

    internal void ItemStolen(ItemData item)
    {
        OnItemStolen?.Invoke(item);
    }
    

}
