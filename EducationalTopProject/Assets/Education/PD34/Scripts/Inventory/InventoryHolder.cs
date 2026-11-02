using System.Collections;
using UnityEngine;

namespace PD34
{
    public class InventoryHolder : MonoBehaviour
    {
        private Inventory _inventory = new Inventory();

        public Inventory Inventory => _inventory;

    }
}