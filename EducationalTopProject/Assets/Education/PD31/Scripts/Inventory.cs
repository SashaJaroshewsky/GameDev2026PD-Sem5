using PD31.ScriptableObjects;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace PD31.Scripts
{

    public class Inventory 
    {
        private Dictionary<ItemData, int> _items = new ();

        public IEnumerable<KeyValuePair<ItemData, int>> Items => _items;
        public event Action ItemAdded;



        public bool Add(ItemData item, int count)
        {
            if (item == null) return false;

            if (_items.ContainsKey(item))
            {
                _items[item] += count;
            }
            else
            {
                _items[item] = count;
            }
            ItemAdded?.Invoke();
            return true;
        }
    }
}
