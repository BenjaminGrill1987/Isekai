using System.Collections.Generic;
using UnityEngine;
using Isekai.Utility;


namespace Isekai.Itemsystem
{

    public class ItemDatabase : Singleton<ItemDatabase>
    {
        [SerializeField] private List<ItemInformation> _dataList = new List<ItemInformation>();

        public static ItemInformation GetItem(int id) => _Instance._dataList.Find(ItemInformation => ItemInformation.Id == id);

        public static ItemInformation GetItem(string name) => _Instance._dataList.Find(ItemInformation => ItemInformation.Name == name);
    }
}