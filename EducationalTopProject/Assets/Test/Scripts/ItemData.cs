using UnityEngine;
namespace Test
{
    [CreateAssetMenu(fileName = "ItemData", menuName = "Test/ItemData")]

    public class ItemData : ScriptableObject
    {

        [SerializeField] private string _id;
        [SerializeField] private string _name;

        [SerializeField] private GameObject _prefab;
        [SerializeField] private Sprite _icon;

        public string Id => _id;
        public string Name => _name;
        public Sprite Icon => _icon;

        public GameObject Prefab => _prefab;
    }
}
