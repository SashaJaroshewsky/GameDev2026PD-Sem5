using UnityEngine;

namespace PD32.Scripts
{
    public class InventoryHolder : MonoBehaviour
    {
        public Inventory Inventory { get; private set; } =  new Inventory();
        
    }
}
