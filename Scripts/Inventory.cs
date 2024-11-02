using System.Collections.Generic;
using UnityEngine;

namespace Indie
{
    public class Inventory : MonoBehaviour
    {
        public int inventorySize = 20;
        public List<InventorySlot> slots;

        private void Awake()
        {
            slots = new List<InventorySlot>(inventorySize);
            for (int i = 0; i < inventorySize; i++)
                slots.Add(new InventorySlot(null, 0)); // Initialize empty slots
        }

        public bool AddItem(Item item, int quantity = 1)
        {
            // Try to add to an existing stack first if stackable
            foreach (var slot in slots)
            {
                if (slot.CanAddToSlot(item) && slot.quantity + quantity <= item.maxStack)
                {
                    slot.AddQuantity(quantity);
                    return true;
                }
            }

            // Add to a new slot if there's an empty one
            foreach (var slot in slots)
            {
                if (slot.item == null)
                {
                    slot.item = item;
                    slot.quantity = quantity;
                    return true;
                }
            }

            // Inventory is full
            return false;
        }

        public bool RemoveItem(Item item, int quantity = 1)
        {
            foreach (var slot in slots)
            {
                if (slot.item == item)
                {
                    if (slot.quantity >= quantity)
                    {
                        slot.quantity -= quantity;
                        if (slot.quantity == 0)
                            slot.ClearSlot();
                        return true;
                    }
                }
            }
            // Item not found or insufficient quantity
            return false;
        }

        public bool HasItem(Item item, int quantity = 1)
        {
            int totalQuantity = 0;
            foreach (var slot in slots)
            {
                if (slot.item == item)
                    totalQuantity += slot.quantity;

                if (totalQuantity >= quantity)
                    return true;
            }
            return false;
        }

        // Additional utility methods can be added for sorting, displaying inventory, etc.
    }
}
