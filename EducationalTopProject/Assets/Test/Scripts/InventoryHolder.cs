using System.Collections;
using UnityEngine;

namespace Assets.Test.Scripts
{
    public class InventoryHolder : MonoBehaviour
    {
        private Inventory _inventory = new Inventory() ;

        public Inventory Inventory => _inventory;

        

    }
}