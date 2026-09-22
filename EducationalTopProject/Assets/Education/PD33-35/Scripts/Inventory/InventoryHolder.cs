using UnityEngine;

namespace PD3335.Scripts.Inventory
{
    public class InventoryHolder : MonoBehaviour
    {
        private Inventory _inventory;

        public Inventory Inventory => _inventory;

        public void Initialize()
        {
            _inventory = new Inventory();
        }

       

    }
}
