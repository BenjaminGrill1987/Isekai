public abstract class BaseStateMachine
{
    protected BaseState _currentState;
    protected PlayerController _player;


    protected void ChangeState(BaseState newState)
    {
        if (_currentState != null)
        {
            _currentState.OnExit();
        }

        _currentState = newState;

        _currentState.OnEntry();
    }

    public void Execute()
    {
        if (_currentState == null) return;

        _currentState.OnExecute();
        CheckTransition();
    }

    private void CheckTransition()
    {
        foreach (Transition transition in _currentState.Transitions)
        {
            if (transition.IsTrue())
            {
                ChangeState(transition.TargetState);
                return;
            }
        }
    }

    protected abstract void DefineTransition();
}
