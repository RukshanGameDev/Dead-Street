using UnityEngine;
using UnityEngine.UI;
public class InventoryUI : MonoBehaviour
{
    [SerializeField]
    private Image[] slotImages;
    [SerializeField]
    private GameObject[] selectionIndicators;
    private void OnEnable()
    {
        EventManager.Instance
        .OnInventoryChanged += RefreshUI;
    }
    private void OnDisable()
    {
        if (EventManager.Instance == null)
            return;
        EventManager.Instance
        .OnInventoryChanged -= RefreshUI;
    }
    private void Start()
    {
        RefreshUI();
    }
    private void RefreshUI()
    {
        var inventory =
        InventoryManager.Instance;
        for (int i = 0; i < slotImages.Length; i++)
        {
            if (i < inventory.Items.Count)
            {
                ItemData item =
                inventory.Items[i];
                slotImages[i].sprite =
                item.icon;
                slotImages[i].enabled = true;
            }
            else
            {
                slotImages[i].sprite = null;
                slotImages[i].enabled = false;
            }
            if (selectionIndicators != null &&
            i < selectionIndicators.Length)
            {
                selectionIndicators[i]
                .SetActive(
                i == inventory.SelectedIndex);
            }
        }
    }
}
