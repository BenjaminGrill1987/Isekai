using Isekai.Interface;
using Isekai.Itemsystem;
using UnityEngine;

[CreateAssetMenu(fileName = "EquipmentData", menuName = "Data/Equipment Data", order = 0)]
public class EquipmentData : ItemInformation
{
    [SerializeField] EquipmentType _equipmentType;
    [SerializeField] int _damage, _armor;


    public EquipmentType Type => _equipmentType;
    public int Damage => _damage;
    public int Armor => _armor;
}
