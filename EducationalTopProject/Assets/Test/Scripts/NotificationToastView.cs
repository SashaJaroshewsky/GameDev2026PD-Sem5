using System.Collections;
using UnityEngine;

namespace Assets.Test.Scripts
{
    public class NotificationToastView : NotificationToastBase
    {
        private Coroutine _routine;

        protected override void StartLifecycle()
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

            Finish();
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
    }
}