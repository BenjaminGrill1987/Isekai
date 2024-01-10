using System.Collections.Generic;
using UnityEngine;
using Isekai.Utility;


namespace Isekai.Itemsystem
{

    public class ItemDatabase : Singleton<ItemDatabase>
    {
        [SerializeField] private List<ItemData> _dataList = new List<ItemData>();

        public static ItemData GetItem(int id) => _Instance._dataList.Find(ItemData => ItemData.GetId() == id);

        public static ItemData GetItem(string name) => _Instance._dataList.Find(ItemData => ItemData.GetName() == name);
    }
}