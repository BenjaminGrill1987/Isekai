using Isekai.Input;
using Isekai.Interface;
using Isekai.Utility;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class Menu : MonoBehaviour
{
    [SerializeField] GameObject _start, _exit, _mapping, _mappingUI;
    Controlls _input;
    bool _active = false;

    private void OnEnable()
    {
        _input = new Controlls();
        _input.UI.Submit.started += CloseMapping;
        _input.Enable();
    }

    private void CloseMapping(InputAction.CallbackContext context)
    {
        if (!_active) return;

        _mappingUI.SetActive(false);
        _start.SetActive(true);
        _exit.SetActive(true);
        _mapping.SetActive(true);
        EventSystem.current.SetSelectedGameObject(_mapping);
        _active = false;
    }

    public void OnClickStart()
    {
        Gamestate.TryToChangeState(Gamestates.Play);
    }

    public void OnClickExit()
    {
        Gamestate.TryToChangeState(Gamestates.Quit);
    }

    public void OnClickMapping()
    {
        _active = true;
        _mappingUI.SetActive(true);
        _start.SetActive(false);
        _exit.SetActive(false);
        _mapping.SetActive(false);
    }

    private void OnDisable()
    {
        _input.Disable();
    }
}
