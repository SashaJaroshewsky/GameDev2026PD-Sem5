using PD31.Scripts;
using UnityEngine;

namespace PD31.Scripts
{
    public class InventoryHolder : MonoBehaviour
    {
        private Inventory _inventory = new Inventory();

        public Inventory Inventory => _inventory;
    }
}
