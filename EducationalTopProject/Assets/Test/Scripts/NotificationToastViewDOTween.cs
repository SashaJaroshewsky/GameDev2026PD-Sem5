using DG.Tweening;
using System.Collections;
using UnityEngine;

namespace Assets.Test.Scripts
{
    public class NotificationToastViewDOTween : NotificationToastBase
    {
        [SerializeField] private Transform _popTarget;
        [SerializeField] private float _popStrength = 0.25f;
        [SerializeField] private float _popDuration = 0.3f;

        private Tween _popTween;
        private Vector3 _baseScale;

        private void Awake()
        {
            if (_popTarget == null) _popTarget = transform;
            _baseScale = _popTarget.localScale;
        }

        private Sequence _sequence;

        protected override void StartLifecycle()
        {
            // Аналог StopCoroutine: зупиняємо попередній показ. OnComplete при Kill НЕ викликається,
            // тому тост не знищується, а просто починає показ заново.
            _sequence?.Kill();

            _sequence = DOTween.Sequence()
                // DOFade стартує з ПОТОЧНОЇ прозорості — як і Fade(_canvasGroup.alpha, 1f) у корутині
                .Append(_canvasGroup.DOFade(1f, _fadeDuration).SetEase(Ease.OutCubic))
                .AppendInterval(_showDuration)
                .Append(_canvasGroup.DOFade(0f, _fadeDuration).SetEase(Ease.InCubic))
                .OnComplete(Finish)
                // Якщо об'єкт знищено раніше (зміна сцени тощо) — твін вбивається разом з ним
                .SetLink(gameObject);
        }

        protected override void OnAmountAdded()
        {
            // Якщо попередній поп ще триває, його обриває Kill посеред руху,
            // і масштаб міг застрягти десь між значеннями. Тому повертаємо базовий масштаб явно.
            _popTween?.Kill();
            _popTarget.localScale = _baseScale;

            // Поп змінює масштаб, а життєвий цикл — прозорість, тому твіни не заважають один одному.
            _popTween = _popTarget
                .DOPunchScale(_baseScale * _popStrength, _popDuration, vibrato: 6, elasticity: 0.5f)
                .SetLink(gameObject);
        }
    }
}