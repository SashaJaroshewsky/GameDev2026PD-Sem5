using PD34;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PD34
{
    public class NotificationListView : MonoBehaviour
    {
        [SerializeField] private NotificationToastView _toastPrefab;

        private Dictionary<string, NotificationToastView> _activeToasts = new Dictionary<string, NotificationToastView>();

        public void ShowNotification(string name, int amount, Sprite icon)
        {
            if(_activeToasts.TryGetValue(name, out var notification))
            {
                notification.AddAmount(amount);
                return;
            }

            var toast = Instantiate(_toastPrefab, transform);
            toast.Play(name, amount, icon, () => _activeToasts.Remove(name));
            _activeToasts[name] = toast;
        }
    }
}