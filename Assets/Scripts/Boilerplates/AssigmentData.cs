using Isekai.Interface;
using Isekai.Itemsystem;
using UnityEngine;

[CreateAssetMenu(fileName = "Assigment Data", menuName = "Data/Assigment Data", order = 0)]
public class AssigmentData : ScriptableObject
{
    [SerializeField] private string _name, _descriptionText;
    [SerializeField] private int _assigmentValue, _assigmentReward, _id;
    [SerializeField] private AssigmentType _type;
    [SerializeField] private ItemInformation _itemData;

    public int GetID() => _id;
    public string Name => _name;
    public string DescriptionText => _descriptionText;
    public int AssigmentValue => _assigmentValue;
    public int AssigmentReward => _assigmentReward;
    public AssigmentType Type => _type;

    public ItemInformation GetItemData() => _itemData;
}
