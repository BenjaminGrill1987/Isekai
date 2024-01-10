using Isekai.Input;
using Isekai.Interface;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using Isekai.Utility;

public class AssigmentLetter : MonoBehaviour, IInteraction
{
    [SerializeField] private GameObject _assigmentBoard, _content, _assigmentPanel;

    private Controlls _input;

    private bool _canBeInteract = false;

    public bool CanBeInteract => _canBeInteract;

    private void Awake()
    {
        _input = new Controlls();
    }

    private void OnEnable()
    {
        _input.Enable();
        _input.UI.Cancel.performed += Cancel;
    }

    private void OnDisable()
    {
        _input.UI.Cancel.performed -= Cancel;
        _input.Disable();
    }

    public void ChangeCanBeInteract(bool newState)
    {
        _canBeInteract = newState;
    }

    public void Submit()
    {
        if (!_canBeInteract) return;
        _assigmentBoard.SetActive(true);

        Debug.Log("Aktiv");
        for (int i = 0; i < 3; i++)
        {
            var panel = Instantiate(_assigmentPanel, _content.transform);
            panel.GetComponent<PanelController>().InitPanel(AssigmentDatabase.GetRandomAssigment());
            if (EventSystem.current.currentSelectedGameObject == null)
            {
                EventSystem.current.SetSelectedGameObject(panel);
            }
            Gamestate.TryToChangeState(Gamestates.Assigment);
        }
    }

    public void Cancel(InputAction.CallbackContext context)
    {
        foreach (Transform child in _content.transform)
        {
            Destroy(child.gameObject);
        }
        Debug.Log("Deaktiviert");
        Gamestate.TryToChangeState(Gamestates.Play);
        _assigmentBoard.SetActive(false);
    }
}