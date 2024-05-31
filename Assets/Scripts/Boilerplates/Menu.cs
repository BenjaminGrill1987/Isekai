using Isekai.Interface;
using Isekai.Utility;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class Menu : MonoBehaviour
{
    [SerializeField] GameObject _start, _exit, _mapping, _mappingUI;
    bool _active = false;


    private void OnEnable()
    {
        InputManager.Input.UI.Submit.performed += StartClosingMapping;
    }

    private void StartClosingMapping(InputAction.CallbackContext context)
    {
        if (!_active) return;
        StartCoroutine(WaitFrame());
    }

    private void CloseMapping()
    {
        _mappingUI.SetActive(false);
        _start.SetActive(true);
        _exit.SetActive(true);
        _mapping.SetActive(true);
        EventSystem.current.SetSelectedGameObject(_start);
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

    private IEnumerator WaitFrame()
    {
        var framecount = 1;

        while (framecount > 0)
        {
            framecount--;
            yield return null;
        }
        CloseMapping();
    }

    private void OnDisable()
    {
        InputManager.Input.UI.Submit.performed -= StartClosingMapping;
    }
}
