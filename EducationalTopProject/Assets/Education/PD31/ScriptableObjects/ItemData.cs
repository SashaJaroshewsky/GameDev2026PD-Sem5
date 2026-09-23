using UnityEngine;

namespace PD31.ScriptableObjects
{
    [CreateAssetMenu(fileName = "ItemData", menuName = "PD31/ScriptableObjects/ItemData")]
    public class ItemData : ScriptableObject
    {
        [SerializeField] private string _id;
        [SerializeField] private string _name;

        public string Id => _id;
        public string Name => _name;
    }
}
