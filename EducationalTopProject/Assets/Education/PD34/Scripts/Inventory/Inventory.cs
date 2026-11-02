using System;
using System.Collections.Generic;
using UnityEngine;

namespace PD34
{
    public class Inventory
    {
        private Dictionary<ItemData, int> _items;
        public event Action<ItemData, int> OnItemAdded;

        public IEnumerable<KeyValuePair<ItemData, int>> Items => _items;

        public Inventory()
        {
            _items = new Dictionary<ItemData, int>();
        }

        public void AddItem(ItemData item, int quantity)
        {
            if (_items.ContainsKey(item))
            {
                _items[item] += quantity;
            }
            else
            {
                _items[item] = quantity;
            }

            OnItemAdded?.Invoke(item, quantity);
        }
    }
}
