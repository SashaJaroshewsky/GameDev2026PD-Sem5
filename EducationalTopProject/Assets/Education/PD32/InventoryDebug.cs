using UnityEngine;

//namespace PD32.gfjnds
//{
//    public class InventoryDebug : MonoBehaviour
//    {
//        [SerializeField] private InventoryHolder _inventoryHolder;
//        [SerializeField] private ItemData _itemToAdd;

//        private void OnEnable()
//        {
//            _inventoryHolder.Inventory.OnItemAdded += PrintInventory;
//        }

//        private void OnDisable()
//        {
//            _inventoryHolder.Inventory.OnItemAdded -= PrintInventory;
//        }



//        private void PrintInventory()
//        {
//            Debug.Log("Current Inventory:");
//            foreach (var item in _inventoryHolder.Inventory.GetItems())
//            {
//                Debug.Log($"Item: {item.Key.Name}, Quantity: {item.Value}");
//            }
//        }

//        //private void Update()
//        //{
//        //    if (Input.GetKeyDown(KeyCode.Space))
//        //    {
//        //        _inventoryHolder.Inventory.AddItem(_itemToAdd, 1);
//        //    }
//        //}
//    }
//}
