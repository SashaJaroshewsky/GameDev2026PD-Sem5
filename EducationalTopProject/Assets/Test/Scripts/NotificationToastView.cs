using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Test.Scripts
{
    public class NotificationToastView : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private Image _iconImage;
        [SerializeField] private TMP_Text _label;
        [SerializeField] private float _showDuration = 1.2f;
        [SerializeField] private float _fadeDuration = 0.2f;

        private string _displayName;
        private int _amount;
        private Coroutine _routine;
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
            RestartLifecycle();
        }


        private void UpdateLabel() => _label.text = $"+{_amount} {_displayName}";
        private void RestartLifecycle()
        {
            if (_routine != null) StopCoroutine(_routine);
            _routine = StartCoroutine(Lifecycle());
        }

        private IEnumerator Lifecycle()
        {
            // Fade-in стартує з поточної прозорості — якщо тост саме зникав, перехід лишається плавним
            yield return Fade(_canvasGroup.alpha, 1f);
            yield return new WaitForSeconds(_showDuration);
            yield return Fade(1f, 0f);

            _onFinished?.Invoke();
            Destroy(gameObject);
        }

        private IEnumerator Fade(float from, float to)
        {
            float t = 0f;
            while (t < _fadeDuration)
            {
                t += Time.deltaTime;
                _canvasGroup.alpha = Mathf.Lerp(from, to, t / _fadeDuration);
                yield return null;
            }
            _canvasGroup.alpha = to;
        }

        public void AddAmount(int extra)
        {
            _amount += extra;
            UpdateLabel();
            RestartLifecycle();
        }
    }
}