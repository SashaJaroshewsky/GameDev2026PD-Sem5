using PD34;
using System;
using System.Collections;
using UnityEngine;

namespace PD34
{
    public class PickupNotificationController : MonoBehaviour
    {
        [SerializeField] private NotificationListView _notificationList;
        [SerializeField] private InventoryHolder _inventoryHolder;

        private void OnEnable()
        {
            _inventoryHolder.Inventory.OnItemAdded += HandleItemAdded;
        }

        private void OnDisable()
        {
            _inventoryHolder.Inventory.OnItemAdded -= HandleItemAdded;
        }

        private void HandleItemAdded(ItemData data, int amount)
        {
            _notificationList.ShowNotification(data.Name, amount, data.Sprite);
        }
    }
}