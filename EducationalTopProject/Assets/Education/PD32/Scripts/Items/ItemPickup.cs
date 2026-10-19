using UnityEngine;
namespace PD32.Scripts.Items
{
    [RequireComponent(typeof(Collider))]
    public class ItemPickup : MonoBehaviour
    {
        [SerializeField] private ItemData _itemData;

        [Min(1)] [SerializeField] private int _amount = 1;

        private void Reset()
        {
            GetComponent<Collider>().isTrigger = true;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent<InventoryHolder>(out InventoryHolder holder)) return;

            holder.Inventory.AddItem(_itemData, _amount);
            Destroy(gameObject);
        }
    }
}
