using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PD3335.Scripts.UI.Notification
{

    public class NotificationToastView : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private Image _iconImage;
        [SerializeField] private TMP_Text _label;

        [SerializeField] private float _fadeDuration = 0.5f;
        [SerializeField] private float _showDuration = 2f;

        private string _displayName;
        private int _displayAmount;

        private Coroutine _coroutine;

        private Action _onComplete;


        public void Play(string name, int amount, Sprite icon, Action onComplete)
        {
            _displayName = name;
            _displayAmount = amount;
            _onComplete = onComplete;

            _iconImage.sprite = icon;
            _iconImage.enabled = icon != null;
            _canvasGroup.alpha = 0f;

            UpdateLabel();
            StartLifeCycle();
        }

        public void AddAmount(int amount)
        {
            _displayAmount += amount;
            UpdateLabel();

            StartLifeCycle();
        }

        private void UpdateLabel()
        {
            _label.text = $"{_displayName} x{_displayAmount}";
        }

        private void StartLifeCycle()
        {
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
            }
            _coroutine = StartCoroutine(LifeCycle());

        }

        private IEnumerator LifeCycle()
        {
            yield return Fade(_canvasGroup.alpha, 1f);
            yield return new WaitForSeconds(_showDuration);
            yield return Fade(_canvasGroup.alpha, 0f);

            _onComplete?.Invoke();
            Destroy(gameObject);
        }

        private IEnumerator Fade(float from, float to)
        {
            float elapsedTime = 0f;
            while (elapsedTime < _fadeDuration)
            {
                elapsedTime += Time.deltaTime;
                _canvasGroup.alpha = Mathf.Lerp(from, to, elapsedTime / _fadeDuration);
                yield return null;
            }
            _canvasGroup.alpha = to;
        }
    }
}
