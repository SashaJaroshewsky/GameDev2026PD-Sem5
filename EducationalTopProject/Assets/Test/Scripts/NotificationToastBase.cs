using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Test.Scripts
{
    public abstract class NotificationToastBase : MonoBehaviour
    {
        [SerializeField] protected CanvasGroup _canvasGroup;
        [SerializeField] private Image _iconImage;
        [SerializeField] private TMP_Text _label;
        [SerializeField] protected float _showDuration = 1.2f;
        [SerializeField] protected float _fadeDuration = 0.2f;

        private string _displayName;
        private int _amount;
        private Action _onFinished;

        public void Play(string displayName, int amount, Sprite icon, Action onFinished)
        {
            _displayName = displayName;
            _amount = amount;
            _onFinished = onFinished;

            _iconImage.sprite = icon;
            _iconImage.enabled = icon != null;
            _canvasGroup.alpha = 0f;

            UpdateLabel();
            StartLifecycle();
        }

        public void AddAmount(int extra)
        {
            _amount += extra;
            UpdateLabel();
            OnAmountAdded();
            StartLifecycle();
        }

        /// <summary>Запустити (або перезапустити) показ: поява → пауза → зникнення → Finish().</summary>
        protected abstract void StartLifecycle();
        protected virtual void OnAmountAdded() { }

        /// <summary>Нащадок викликає це в кінці анімації: список прибирає запис, об'єкт знищується.</summary>
        protected void Finish()
        {
            _onFinished?.Invoke();
            Destroy(gameObject);
        }

        private void UpdateLabel() => _label.text = $"+{_amount} {_displayName}";
    }
}