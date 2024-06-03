using Isekai.Interface;
using Isekai.Utility;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMenu : MonoBehaviour
{
    [SerializeField] private GameObject _firstSelected, _inventory, _assigment, _equipment;

    private void OnEnable()
    {
        Gamestate.TryToChangeState(Gamestates.PlayerMenu);
        EventSystem.current.SetSelectedGameObject(_firstSelected);
    }

    public void OnInventoryClick()
    {
        Debug.Log("Open Inventory");
        _inventory.SetActive(true);
        _assigment.SetActive(false);
        _equipment.SetActive(false);
    }

    public void OnAssigmentClick()
    {
        Debug.Log("Open Assigment");
        _inventory.SetActive(false);
        _assigment.SetActive(true);
        _equipment.SetActive(false);
    }

    public void OnEquipmentClick()
    {
        Debug.Log("Open Equipment");
        _inventory.SetActive(false);
        _assigment.SetActive(false);
        _equipment.SetActive(true);
    }

    public void OnExitClick()
    {
        Gamestate.TryToChangeState(Gamestates.Quit);
        _inventory.SetActive(false);
        _assigment.SetActive(false);
        _equipment.SetActive(false);
    }

    private void OnDisable()
    {
        Gamestate.TryToChangeState(Gamestates.Play);        
    }
}
