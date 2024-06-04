using UnityEngine;

public class PlayerEquipment : MonoBehaviour
{
    EquipmentData _weapon, _head, _body, _foot;

    public EquipmentData Waepon => _weapon;
    public EquipmentData Head => _head;
    public EquipmentData Body => _body;
    public EquipmentData Foot => _foot;

    public void EquipWeapon(EquipmentData newWeapon) => _weapon = newWeapon;
    public void EquipHead(EquipmentData newHead) => _head = newHead;
    public void EquipBody(EquipmentData newBody) => _body = newBody;
    public void EquipFoot(EquipmentData newFoot) => _foot = newFoot;
}
