using UnityEngine;

namespace Indie
{
    [CreateAssetMenu(fileName = "NewItem", menuName = "Inventory/Item")]
    public class Item : ScriptableObject
    {
        public string itemName; // Name of the item
        public Sprite icon;     // Icon to display in the UI
        public bool isStackable; // Determines if item can be stacked
        public int maxStack;    // Maximum stack size

        // You can expand this with additional properties like rarity, weight, or description
    }
}
