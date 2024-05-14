using System.Collections.Generic;

public abstract class BaseState
{
    private List<Transition> _transitions = new List<Transition>();

    public List<Transition> Transitions => _transitions;

    public abstract void OnEntry();

    public abstract void OnExecute();

    public abstract void OnExit();

    public void AddTransition(System.Func<bool> newBool, BaseState targetState)
    {
        _transitions.Add(new Transition(newBool, targetState));
    }
}
