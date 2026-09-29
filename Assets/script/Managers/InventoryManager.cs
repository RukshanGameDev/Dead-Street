using System;
using System.Collections.Generic;
using UnityEngine;


    public class InventoryManager : MonoBehaviour
    {
        public static InventoryManager Instance { get;  set; }
        [Header("Inventory")]
        [SerializeField]
        public int maxInventorySize = 3;
        public readonly List<ItemData> items =
        new List<ItemData>();
        private int selectedIndex = -1;
        public IReadOnlyList<ItemData> Items => items;
        public int SelectedIndex => selectedIndex;
        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
        }
        public bool AddItem(ItemData item)
        {
            if (item == null)
                return false;
            if (items.Count >= maxInventorySize)
            {
                EventManager.Instance
                .ShowInteractionMessage(
                "Inventory Full");
                return false;
            }
            items.Add(item);
            if (selectedIndex == -1)
            {
                selectedIndex = 0;
            }
            EventManager.Instance
            .InventoryChanged();
            EventManager.Instance
            .ItemAdded(item);
            return true;
        }
        public bool RemoveSelectedItem()
        {
            if (!HasSelectedItem())
                return false;
            ItemData removedItem =
            items[selectedIndex];
            items.RemoveAt(selectedIndex);
            if (items.Count == 0)
            {
                selectedIndex = -1;
            }
            else if (selectedIndex >= items.Count)
            {
                selectedIndex = items.Count - 1;
            }
            EventManager.Instance
            .InventoryChanged();
            EventManager.Instance
            .ItemRemoved(removedItem);
            return true;
        }
        public bool SelectItem(int index)
        {
            if (index < 0 || index >= items.Count)
                return false;
            selectedIndex = index;
            EventManager.Instance
            .ItemSelected(items[index]);
            EventManager.Instance
            .InventoryChanged();
            return true;
        }
        public ItemData GetSelectedItem()
        {
            if (!HasSelectedItem())
                return null;
            return items[selectedIndex];
        }
        public bool HasSelectedItem()
        {
            return selectedIndex >= 0 &&
            selectedIndex < items.Count;
        }

    internal ItemData RemoveRandomItem()
    {
        if (items.Count == 0)
            return null;
        int randomIndex =
            UnityEngine.Random.Range(
            0,
            items.Count);
        ItemData item =
            items[randomIndex];
        items.RemoveAt(randomIndex);
        if (items.Count == 0)
        {
            selectedIndex = -1;
        }
        else if (selectedIndex >= items.Count)
        {
            selectedIndex =
            items.Count - 1;
        }
        EventManager.Instance
        .InventoryChanged();
        EventManager.Instance
        .ItemRemoved(item);
        return item;
    }
    public bool CheckInventory()
    {
        if (items.Count >= maxInventorySize)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void ResetInventory()
    {
        items.Clear();

        selectedIndex = -1;

        EventManager.Instance.InventoryChanged();
    }
}
