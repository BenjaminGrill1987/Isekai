using Isekai.Interface;
using Isekai.Utility;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMenu : MonoBehaviour
{
    [SerializeField] private GameObject _firstSelected, _inventory, _assigment;

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
    }

    public void OnAssigmentClick()
    {
        Debug.Log("Open Assigment");
        _inventory.SetActive(false);
        _assigment.SetActive(true);
    }

    public void OnExitClick()
    {
        Debug.Log("Exit Application");
        _inventory.SetActive(false);
        _assigment.SetActive(false);
    }

    private void OnDisable()
    {
        Gamestate.TryToChangeState(Gamestates.Play);        
    }
}
