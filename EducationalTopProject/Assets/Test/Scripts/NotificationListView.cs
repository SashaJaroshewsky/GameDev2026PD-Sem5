using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Test.Scripts
{
    public class NotificationListView : MonoBehaviour
    {
        [SerializeField] private NotificationToastBase _toastPrefab;

        private readonly Dictionary<string, NotificationToastBase> _active = new();

        public void Show(string key, string displayName, int amount, Sprite icon = null)
        {
            if (_active.TryGetValue(key, out var existing) && existing != null)
            {
                existing.AddAmount(amount);
                return;
            }

            var toast = Instantiate(_toastPrefab, transform);
            _active[key] = toast;
            toast.Play(displayName, amount, icon, onFinished: () => _active.Remove(key));
        }
    }
}