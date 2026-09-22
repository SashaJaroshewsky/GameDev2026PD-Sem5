using UnityEngine;

namespace PD32.gfjnds
{
    [CreateAssetMenu(fileName = "ItemData", menuName = "33-35/ScriptableObjects/ItemData")]
    public class ItemData : ScriptableObject
    {
        public string Id;
        public string Name;

        public GameObject Prefab;

    }
}

