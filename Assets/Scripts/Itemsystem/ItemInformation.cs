using Isekai.Interface;
using UnityEngine;

namespace Isekai.Itemsystem
{

    public abstract class ItemInformation : ScriptableObject
    {
        [SerializeField] private int _id;
        [SerializeField] private string _name, _description;
        [SerializeField] private Sprite _icon;
        [SerializeField] private ItemType _itemType;
        
        public int Id => _id;

        public string Name => _name;

        public string Description => _description;

        public Sprite Icon => _icon;

        public ItemType ItemType => _itemType;
    }
}