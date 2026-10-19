using UnityEngine;

namespace PD32.Scripts
{
    public class InventoryDebug : MonoBehaviour
    {
        [SerializeField] private InventoryHolder _inventoryHolder;

        private void OnEnable()
        {
            _inventoryHolder.Inventory.OnItemAdded += PrintInventory;
        }

        private void OnDisable()
        {
            _inventoryHolder.Inventory.OnItemAdded -= PrintInventory;
        }



        private void PrintInventory()
        {
            Debug.Log("Current Inventory:");
            foreach (var item in _inventoryHolder.Inventory.GetItems())
            {
                Debug.Log($"Item: {item.Key.Name}, Quantity: {item.Value}");
            }
        }

       
    }
}
