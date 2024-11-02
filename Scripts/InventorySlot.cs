using System.Collections.Generic;
using UnityEngine;

namespace Indie
{
    [System.Serializable]
    public class InventorySlot
    {
        public Item item; // Reference to the item
        public int quantity; // Quantity of the item in this slot

        public InventorySlot(Item newItem, int newQuantity)
        {
            item = newItem;
            quantity = newQuantity;
        }

        public bool CanAddToSlot(Item newItem)
        {
            return item == newItem && item.isStackable;
        }

        public void AddQuantity(int amount)
        {
            quantity += amount;
        }

        public void ClearSlot()
        {
            item = null;
            quantity = 0;
        }
    }
}
