using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PD34
{
    public class NotificationToastView : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private Image _icon;
        [SerializeField] private TMP_Text _lable;

        [SerializeField] private float _fadeDuration = 1f;
        [SerializeField] private float _showDuration = 2f;

        private string _displayName;
        private int _displayAmount;

        private Coroutine _coroutine;

        public Action Complited;

        public void Play(string name, int amount, Sprite icon, Action action)
        {
            _displayName = name;
            _displayAmount = amount;

            _icon.sprite = icon;
            _icon.enabled = icon != null;
            Complited = action;

            _canvasGroup.alpha = 0f;
            UpdateLable();
            StartLifeCycle();
        }

        public void AddAmount(int amount)
        {
            _displayAmount += amount;
            UpdateLable();

            StartLifeCycle();
        }



        private void UpdateLable()
        {
            _lable.text = $"{_displayName} x{_displayAmount}";
        }

        private void StartLifeCycle()
        {
            if (_coroutine != null)
                StopCoroutine(_coroutine);

            _coroutine = StartCoroutine(LifeCycle());

        }

        private IEnumerator LifeCycle()
        {
            yield return Fade(_canvasGroup.alpha, 1f);
            yield return new WaitForSeconds(_showDuration);
            yield return Fade(_canvasGroup.alpha, 0f);

            Complited.Invoke();
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
