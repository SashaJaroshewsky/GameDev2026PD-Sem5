using PD31.ScriptableObjects;
using UnityEngine;

namespace PD31.Scripts
{
    [RequireComponent(typeof(Collider))]
    public class ItemPickup : MonoBehaviour
    {
        [SerializeField] private ItemData _itemData;
        [Min(1)][SerializeField] private int _amount = 1;


        public void Reset()
        {
            GetComponent<Collider>().isTrigger = true;
        }

        private void OnTriggerEnter(Collider other)
        {
            var holder = other.GetComponent<InventoryHolder>();
            if (holder == null) return;

            holder.Inventory.Add(_itemData, _amount);

            Destroy(gameObject);
        }
    }
}
