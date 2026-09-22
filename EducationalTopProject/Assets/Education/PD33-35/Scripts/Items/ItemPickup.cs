
using PD3335.ScriptableObjects;
using PD3335.Scripts.Inventory;
using UnityEngine;
using UnityEngine.AdaptivePerformance;

namespace PD3335.Scripts.Items
{
    [RequireComponent(typeof(Collider))]
    public class ItemPickup : MonoBehaviour
    {
        [SerializeField] private ItemData _data;

        [Min(1)][SerializeField] private int _amount = 1;

        private void Reset()
        {
            GetComponent<Collider>().isTrigger = true;
        }

        private void OnTriggerEnter(Collider other) 
        {


            if (!other.TryGetComponent<InventoryHolder>(out var holder)) return;
            //var holder = other.GetComponent<InventoryHolder>();
            //if (holder == null) return;

            holder.Inventory.AddItem(_data, _amount);
            Destroy(gameObject);
        }
    }
}
