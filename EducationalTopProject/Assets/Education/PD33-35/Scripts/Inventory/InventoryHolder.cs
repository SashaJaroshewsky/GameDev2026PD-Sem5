using UnityEngine;

namespace PD3335.Scripts.Inventory
{
    public class InventoryHolder : MonoBehaviour
    {
        private Inventory _inventory = new Inventory();

        public Inventory Inventory => _inventory;

    }
}
