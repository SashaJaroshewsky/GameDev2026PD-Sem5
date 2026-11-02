

using Test;
using UnityEngine;

namespace Assets.Test.Scripts
{
    public class PickupNotificationController : MonoBehaviour
    {
        [SerializeField] private InventoryHolder _holder;
        [SerializeField] private NotificationListView _view;

        private void OnEnable() => _holder.Inventory.ItemAdded += HandleItemAdded;
        private void OnDisable() => _holder.Inventory.ItemAdded -= HandleItemAdded;

        private void HandleItemAdded(ItemData item, int amount)
        {
            _view.Show(item.Id, item.Name, amount, item.Icon);
        }
    }
}
