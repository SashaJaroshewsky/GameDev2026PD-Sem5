using System;
using System.Collections.Generic;
using Test;
using UnityEngine;

namespace Assets.Test.Scripts
{
    public class Inventory
    {
        private Dictionary<ItemData, int> _items;
        public event Action<ItemData, int> ItemAdded;

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

            ItemAdded?.Invoke(item, quantity);
        }
    }
}