using UnityEngine;
using Isekai.Itemsystem;

public class Inventory : MonoBehaviour
{
    [SerializeField] private GameObject _itemPanel;
    [SerializeField] private Transform _content;

    private void OnEnable()
    {
        foreach (var entry in InventorySystem.GetInventory())
        {
            var itemPanel = Instantiate(_itemPanel, _content);
            itemPanel.GetComponent<ItemPanel>().BuildPanel(entry.Key.Icon, entry.Value);
        }
    }

    private void OnDisable()
    {
        foreach (Transform child in _content)
        {
            Destroy(child.gameObject);
        }
    }
}
