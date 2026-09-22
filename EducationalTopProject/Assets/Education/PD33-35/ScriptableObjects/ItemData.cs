using UnityEngine;

namespace PD3335.ScriptableObjects
{
    [CreateAssetMenu(fileName = "ItemData", menuName = "PD33-35/ScriptableObjects/ItemData")]
    public class ItemData : ScriptableObject
    {
        [SerializeField] private string _id;
        [SerializeField] private string _name;

        [SerializeField] private GameObject _prefab;

        public string Id => _id;
        public string Name => _name;

        public GameObject Prefab => _prefab;

    }
}
