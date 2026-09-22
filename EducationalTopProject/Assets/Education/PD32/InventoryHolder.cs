using UnityEngine;

namespace PD32
{
    public class InventoryHolder : MonoBehaviour
    {
        public Inventory Inventory { get; private set; }

        private void Awake()
        {
            Inventory = new Inventory();
        }
    }
}
