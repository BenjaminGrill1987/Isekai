using System;

public class Transition
{
    public Transition(Func<bool> newBool, BaseState targetState)
    {
        _isTrue = newBool;
        _targetState = targetState;
    }

    private Func<bool> _isTrue;
    private BaseState _targetState;
    public Func<bool> IsTrue => _isTrue;
    public BaseState TargetState => _targetState;
}
