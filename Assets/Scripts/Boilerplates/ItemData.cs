using UnityEngine;

[CreateAssetMenu(fileName = "ItemData",menuName ="Data/Item Data", order = 0)]
public class ItemData : ScriptableObject
{
    [SerializeField] private int _id;
    [SerializeField] private string _name, _description;
    [SerializeField] private Sprite _icon;

    public int GetId()
    {
        return _id;
    }

    public string GetName()
    {
        return _name;
    }

    public string GetDescription()
    {
        return _description;
    }

    public Sprite GetIcon()
    {
        return _icon;
    }
}
