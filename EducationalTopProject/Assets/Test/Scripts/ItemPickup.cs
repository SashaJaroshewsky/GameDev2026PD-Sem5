using System.Collections;
using Test;
using UnityEngine;

namespace Assets.Test.Scripts
{
    [RequireComponent(typeof(Collider))]
    public class ItemPickup : MonoBehaviour
    {
        [SerializeField] private ItemData _data;

        [Min(1)][SerializeField] private int _amount = 1;

        // Тепер об'єкт живе ще деякий час після підбору (поки летить), тож без цього прапорця
        // OnTriggerEnter міг би спрацювати вдруге і предмет додався б двічі.
        private bool _collected;

        private void Reset()
        {
            GetComponent<Collider>().isTrigger = true;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (_collected) return;
            if (!other.TryGetComponent<InventoryHolder>(out var holder)) return;

            _collected = true;

            // Логіка: предмет у інвентарі ОДРАЗУ. Політ нижче — суто візуальний.
            holder.Inventory.AddItem(_data, _amount);

            // Анімація необов'язкова: нема компонента — працює як раніше.
            if (TryGetComponent<PickupFlyAnimation>(out var fly))
                fly.Play(holder.transform, onComplete: () => Destroy(gameObject));
            else
                Destroy(gameObject);
        }
    }
}