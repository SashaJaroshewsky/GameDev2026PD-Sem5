using UnityEngine;

[CreateAssetMenu(fileName = "ItemDataBase", menuName = "Scriptable Objects/ItemDataBase")]
public class ItemDataBase : ScriptableObject
{
    [SerializeField]
    private ItemData[] _items;

    public ItemData[] Items => _items;
}
