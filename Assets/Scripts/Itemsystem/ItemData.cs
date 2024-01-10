using UnityEngine;

namespace Isekai.Itemsystem
{

    [CreateAssetMenu(fileName = "ItemData", menuName = "Data/Item Data", order = 0)]
    public class ItemData : ScriptableObject
    {
        [SerializeField] private int _id;
        [SerializeField] private string _name, _description;
        [SerializeField] private Sprite _icon;

        public int GetId() => _id;

        public string GetName() => _name;

        public string GetDescription() => _description;

        public Sprite GetIcon() => _icon;
    }
}