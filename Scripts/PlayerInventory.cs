using UnityEngine;

namespace Indie
{
    public class PlayerInventory : MonoBehaviour
    {
        [SerializeField] private Inventory inventory;
        [SerializeField] private InventoryUI inventoryUI;

        private void Awake()
        {
            inventory = GetComponent<Inventory>();
            inventoryUI = FindObjectOfType<InventoryUI>();
        }

        public void PickUpItem(Item item, int quantity)
        {
            if (inventory.AddItem(item, quantity))
            {
                inventoryUI.UpdateUI();
                Debug.Log($"{quantity}x {item.itemName} added to inventory.");
            }
            else
            {
                Debug.Log("Inventory full.");
            }
        }

        public void DropItem(Item item, int quantity)
        {
            if (inventory.RemoveItem(item, quantity))
            {
                inventoryUI.UpdateUI();
                Debug.Log($"{quantity}x {item.itemName} removed from inventory.");
            }
            else
            {
                Debug.Log("Item not found or insufficient quantity.");
            }
        }
    }
}
