using DG.Tweening;
using System;
using System.Collections;
using UnityEngine;

namespace Assets.Test.Scripts
{
    public class PickupFlyAnimation : MonoBehaviour
    {
        [SerializeField] private float _duration = 0.35f;

        [Tooltip("Куди цілитись відносно позиції гравця. Зазвичай трохи вище, щоб лізти в груди, а не в ноги.")]
        [SerializeField] private Vector3 _targetOffset = new Vector3(0f, 1f, 0f);

        public void Play(Transform target, Action onComplete)
        {
            // Предмет вже зібраний: колайдер і фізика більше не потрібні.
            // Без isKinematic Rigidbody продовжив би падати, борючись із нашим рухом.
            if (TryGetComponent(out Collider col)) col.enabled = false;
            if (TryGetComponent(out Rigidbody rb)) rb.isKinematic = true;

            Vector3 startPosition = transform.position;
            Vector3 startScale = transform.localScale;

            // Гравець рухається, тому кінцеву точку беремо ЩОКАДРУ, а не один раз на старті.
            // Інакше предмет прилетів би туди, де гравець був у момент підбору.
            // Твін тут «віртуальний»: DOTween лише дає t від 0 до 1 з потрібною кривою,
            // а позицію і масштаб ми виставляємо самі.
            DOVirtual.Float(0f, 1f, _duration, t =>
            {
                if (target != null)
                    transform.position = Vector3.LerpUnclamped(startPosition, target.position + _targetOffset, t);

                transform.localScale = Vector3.LerpUnclamped(startScale, Vector3.zero, t);
            })
                .SetEase(Ease.InBack)       // легкий «замах» назад, потім прискорення; для чистого «засмоктування» спробуйте Ease.InQuad
                .OnComplete(() => onComplete?.Invoke())
                .SetLink(gameObject);
        }
    }
}