using PD3335.ScriptableObjects;
using System.Text;
using UnityEngine;

namespace PD3335.Scripts.Inventory
{
    public class InventoryDebug : MonoBehaviour
    {
        [SerializeField] private InventoryHolder _inventoryHolder;
        public void Awake()
        {
            _inventoryHolder.Initialize();
        }
        private void OnEnable()
        {
            //if (_inventoryHolder.Inventory == null) return;
            _inventoryHolder.Inventory.OnItemAdded += HandleItemAdded;
        }
        private void OnDisable()
        {
            _inventoryHolder.Inventory.OnItemAdded -= HandleItemAdded;
        }

        private void HandleItemAdded()
        {
            var text = new StringBuilder($"Inventory {_inventoryHolder.gameObject.name}:");
            foreach (var item in _inventoryHolder.Inventory.Items)
            {
                text.AppendLine($"Item: {item.Key.Name}, Quantity: {item.Value}");
            }

            Debug.Log(text.ToString());
        }
    }
}
