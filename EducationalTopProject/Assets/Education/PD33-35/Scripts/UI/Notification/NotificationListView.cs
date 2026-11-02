using System.Collections.Generic;
using UnityEngine;

namespace PD3335.Scripts.UI.Notification
{
    public class NotificationListView : MonoBehaviour
    {
        [SerializeField] private NotificationToastView _toastPrefab;

        private Dictionary<string, NotificationToastView> _activeToasts = new Dictionary<string, NotificationToastView>();

        public void ShowNotification(string key, string name, int amount, Sprite icon)
        {
            if (_activeToasts.TryGetValue(key, out var existing))
            {
                existing.AddAmount(amount);
                return;
            }
            var toast = Instantiate(_toastPrefab, transform);
            toast.Play(name, amount, icon, () => _activeToasts.Remove(key));
            _activeToasts[key] = toast;
        }
    }
}
