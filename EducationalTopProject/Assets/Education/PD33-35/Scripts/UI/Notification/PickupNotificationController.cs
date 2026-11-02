using PD3335.ScriptableObjects;
using PD3335.Scripts.Inventory;
using PD3335.Scripts.UI.Notification;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Assets.Education.PD33_35.Scripts.UI.Notification
{
    internal class PickupNotificationController: MonoBehaviour
    {
        [SerializeField] private NotificationListView _notificationListView;
        [SerializeField] private InventoryHolder _inventoryHolder;
        private void OnEnable()
        {
            _inventoryHolder.Inventory.OnItemAdded += HandleItemAdded;
        }
        private void OnDisable()
        {
            _inventoryHolder.Inventory.OnItemAdded -= HandleItemAdded;
        }
        private void HandleItemAdded(ItemData item, int quantity)
        {
            _notificationListView.ShowNotification(item.Id, item.Name, quantity, item.Sprite);
        }
    }
}
