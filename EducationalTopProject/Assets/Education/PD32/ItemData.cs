using UnityEngine;
namespace PD32
{
    [CreateAssetMenu(fileName = "ItemData", menuName = "PD32/ScriptableObjects/ItemData")]
    public class ItemData : ScriptableObject
    {
         [SerializeField] private string _id;
         [SerializeField] private string _name;

        public string Id => _id;
        public string Name => _name;

    }
}
