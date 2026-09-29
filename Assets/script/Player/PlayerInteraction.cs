using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerInteraction : MonoBehaviour
{
    [Header("Interaction")]
    [SerializeField]
    private float interactionRadius = 2f;
    [Header("Placement")]
    [SerializeField]
    private Transform placementPoint;
    private InventoryItem nearbyItem;
   private PlayerController player;
    private void Awake()
    {
        player = GetComponent<PlayerController>();
    }
    private void Update()
    {
        DetectNearbyItem();
        if (Keyboard.current == null)
            return;
        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            player.StateMachine.ChangeState(new CollectState(player));
            PickupItem();

        }
        if (Keyboard.current.rKey.wasPressedThisFrame)
        {
            player.StateMachine.ChangeState(new PlacedState(player));
            PlaceSelectedItem();
        }
        if (Keyboard.current.digit1Key.wasPressedThisFrame)
        {
            InventoryManager.Instance.SelectItem(0);
        }
        if (Keyboard.current.digit2Key.wasPressedThisFrame)
        {
            InventoryManager.Instance.SelectItem(1);
        }
        if (Keyboard.current.digit3Key.wasPressedThisFrame)
        {
            InventoryManager.Instance.SelectItem(2);
        }
    }
    private void DetectNearbyItem()
    {
        nearbyItem = null;
        Collider[] colliders =
            Physics.OverlapSphere(
            transform.position,
            interactionRadius);
        foreach (Collider collider in colliders)
        {
            InventoryItem item =
            collider.GetComponent<InventoryItem>();
            if (item != null)
            {
                nearbyItem = item;
                Debug.Log("detect Nearby item");
                EventManager.Instance
                    .ShowInteractionMessage("Press E to Pick Up");
                return;
            }
        }
    }
    private void PickupItem()
    {
        if (nearbyItem == null)
        {
            EventManager.Instance
            .ShowInteractionMessage(
            "No item nearby");
            return;
        }
        bool added =
        InventoryManager.Instance
        .AddItem(nearbyItem.Data);
        if (!added)
            return;
        Destroy(nearbyItem.gameObject);
        nearbyItem = null;
    }
    private void PlaceSelectedItem()
    {
        ItemData selectedItem =
        InventoryManager.Instance
        .GetSelectedItem();
        if (selectedItem == null)
        {
            EventManager.Instance
            .ShowInteractionMessage(
            "Please select an item first");
            return;
        }
        if (selectedItem.prefab == null)
        {
            Debug.LogError(
            "Selected item has no prefab.");
            return;
        }
        var Placedobject = Instantiate(
        selectedItem.prefab,
        placementPoint.position,
        placementPoint.rotation);
        Placedobject.gameObject.SetActive(true);
        InventoryManager.Instance
        .RemoveSelectedItem();
        EventManager.Instance
        .ShowInteractionMessage(
        "Item Placed!");
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(
        transform.position,
        interactionRadius);
    }
}