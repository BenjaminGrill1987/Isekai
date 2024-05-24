using Isekai.Input;
using Isekai.Interface;
using Isekai.Utility;
using UnityEngine;
using UnityEngine.InputSystem;

public class InitScene : MonoBehaviour
{
    [SerializeField] float _time;

    Timer _timer;
    Controlls _input;

    private void Start()
    {
        _input = new Controlls();
        _timer = new Timer(_time, ChangeScene);
        _input.UI.Submit.started += ChangeScene;
        _input.Enable();
    }

    private void FixedUpdate()
    {
        _timer.Tick();
    }

    private void ChangeScene(InputAction.CallbackContext context)
    {
        Gamestate.TryToChangeState(Gamestates.Menu);
    }

    private void ChangeScene()
    {
        Gamestate.TryToChangeState(Gamestates.Menu);
    }

    private void OnDisable()
    {
        _input.Disable();
    }
}
