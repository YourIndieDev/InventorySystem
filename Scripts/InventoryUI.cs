using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

namespace Indie
{
    public class InventoryUI : MonoBehaviour
    {
        public Inventory inventory;
        public GameObject inventorySlotPrefab;
        public Transform inventoryPanel;

        private List<GameObject> slotUIs;

        private void Start()
        {
            slotUIs = new List<GameObject>();
            UpdateUI();
        }

        public void UpdateUI()
        {
            // Clear old UI elements
            foreach (var slotUI in slotUIs)
                Destroy(slotUI);

            slotUIs.Clear();

            // Add new UI elements for each slot in the inventory
            foreach (var slot in inventory.slots)
            {
                var slotUI = Instantiate(inventorySlotPrefab, inventoryPanel);
                var icon = slotUI.transform.Find("Icon").GetComponent<Image>();
                var quantityText = slotUI.transform.Find("Quantity").GetComponent<TMP_Text>();

                if (slot.item != null)
                {
                    icon.sprite = slot.item.icon;
                    icon.enabled = true;
                    quantityText.text = slot.quantity > 1 ? slot.quantity.ToString() : "";
                }
                else
                {
                    icon.enabled = false;
                    quantityText.text = "";
                }

                slotUIs.Add(slotUI);
            }
        }
    }
}
