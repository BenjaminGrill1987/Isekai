using Isekai.Input;
using Isekai.Interface;
using Isekai.Utility;
using UnityEngine;
using UnityEngine.InputSystem;

public class InitScene : MonoBehaviour
{
    [SerializeField] float _time;

    Timer _timer;

    private void Start()
    {
        _timer = new Timer(_time, ChangeScene);
        InputManager.Input.UI.Submit.started += ChangeScene;
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
        InputManager.Input.UI.Submit.started -= ChangeScene;
    }
}
