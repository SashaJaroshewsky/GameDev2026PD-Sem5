using System.Collections;
using UnityEngine;

namespace PD34
{
    [CreateAssetMenu(fileName = "ItemData", menuName = "PD34/ScriptableObjects/ItemData")]
    public class ItemData : ScriptableObject
    {
        [SerializeField] private string _id;
        [SerializeField] private string _name;

        [SerializeField] private GameObject _prefab;

        [SerializeField] private Sprite _sprite;

        public string Id => _id;
        public string Name => _name;

        public GameObject Prefab => _prefab;

        public Sprite Sprite => _sprite;

    }
}