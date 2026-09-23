using PD31.ScriptableObjects;
using System.Text;
using UnityEngine;

namespace PD31.Scripts
{
    public class InventoryDebug : MonoBehaviour
    {
        [SerializeField] private InventoryHolder _holder;
        

        private void OnEnable()
        {
            _holder.Inventory.ItemAdded += OnItemAdded;
        }
        private void OnDisable()
        {
            _holder.Inventory.ItemAdded -= OnItemAdded;
        }


        private void OnItemAdded()
        {
            var text = new StringBuilder($"Inventory {gameObject.name} ");

            foreach(var item in _holder.Inventory.Items)
            {
                text.Append($"{item.Key.Name} x{item.Value}");
            }
            Debug.Log(text.ToString());
        }
    }
}
